using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ComponentModel;
using SharpPcap;
using System.Net;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter1;
        private ListViewColumnSorter lvwColumnSorter3;

        private Dictionary<string,NetworkInterface> UpAdapters  = new Dictionary<string, NetworkInterface>();
        private Dictionary<string, ICaptureDevice> UpPacketCaptureDevice = new Dictionary<string, ICaptureDevice>();

        private string selectedAdaptaterName = "";
        private string selectedRefreshTime = "";

        private string[] currentDeviceNetworkIPAddress;
        private string currentDeviceWildCardMask;
        private Device currentDevice = new Device();
        private string currentDeviceDefaultGatewayIPAddress;
        private ICaptureDevice currentPacketCaptureDevice;
        public List<Device> detectedDevices = new List<Device>();

        delegate void UpdateNetworkListViewDelegate(String ipAdress);
        delegate void UpdateUnavailableDetectedDevice(String ipAdress);
        delegate void UpdateAvailableDetectedDevice(String ipAdress);
        delegate void AddNewPacket(RawCapture rawPacket, DateTime time);

        public static Device deviceDetails = new Device() ;
        public static int packetIndex = 0;

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter1 = new ListViewColumnSorter();
            lvwColumnSorter3 = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter1;
            this.listView3.ListViewItemSorter = lvwColumnSorter3;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load available network adaptater's into "Carte reseau" tool strip and make them available
            AddNetworkAndPacketCaptureAdaptater();
            MakeNetWorkAdaptaterToolStripCheckable();
            
            timer1.Interval = Int32.Parse(sToolStripMenuItem.Text.Substring(0,2)) * 1000;

        }

        public void MakeNetWorkAdaptaterToolStripCheckable()
        {
            foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
            {
                item.CheckOnClick = true;
            }
        }
        
        //Add network adaptater into Upadaptater dictionnary and in "Carte Reseau" Tool Strip
        public void AddNetworkAndPacketCaptureAdaptater()
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if(adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            if(adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                            {
                                if (!UpAdapters.ContainsKey(adapter.Name))
                                {
                                    if (!UpPacketCaptureDevice.ContainsKey(adapter.Name))
                                    {
                                        foreach (ICaptureDevice device in CaptureDeviceList.Instance)
                                        {
                                            if (device.ToString().Contains("FriendlyName: " + adapter.Name))
                                            {
                                                UpPacketCaptureDevice.Add(adapter.Name,device);
                                                UpAdapters.Add(adapter.Name, adapter);
                                                NetAdaptToolStripMenuItem.DropDown.Items.Add(adapter.Name);
                                            }
                                        }   
                                    }  
                                } 
                            }   
                        }
                    }
                }
            }

        }        

        //A set of elements to add programmatically 

        public void ClearNetworkListView()
        {
            if(listView1.Items.Count > 0)
            {
                listView1.Items.Clear(); 
            }
            
        }

        public void ClearPacketCaptureListView()
        {
            if (listView3.Items.Count > 0)
            {
                listView3.Items.Clear();
            }
        }

        private void NetAdaptToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (selectedAdaptaterName != e.ClickedItem.ToString())
            {
                detectedDevices.Clear();
                ClearNetworkListView();
                backgroundWorker1.CancelAsync();
                selectedAdaptaterName = e.ClickedItem.ToString();

                foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
                {
                    if(item.Text != selectedAdaptaterName)
                    {
                        item.Checked = false;
                    }
                }

                foreach (UnicastIPAddressInformation unicastIPAddressInformation in UpAdapters[selectedAdaptaterName].GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        currentDevice.IpAddress = unicastIPAddressInformation.Address.ToString();
                        currentDevice.MacAddress = NetworkAnalysisUtility.getMacAddressOfAdaptater(UpAdapters[selectedAdaptaterName]).ToUpper();
                        currentDevice.DomainName = NetworkAnalysisUtility.getDnsNameOfIpAddress(currentDevice.IpAddress);
                        currentDevice.AdaptatorConstructor = NetworkAnalysisUtility.findNicConstructor(currentDevice.MacAddress);
                        currentDevice.Info = "Votre Machine";
                        currentDevice.MacAddress = currentDevice.MacAddress.Substring(0, 2) + "-" + currentDevice.MacAddress.Substring(2, 2) + "-" + currentDevice.MacAddress.Substring(4, 2) + "-" + currentDevice.MacAddress.Substring(6, 2) + "-" + currentDevice.MacAddress.Substring(8, 2) + "-" + currentDevice.MacAddress.Substring(10, 2);
                        currentDevice.FirstDetection = DateTime.Now.ToString();
                        currentDevice.LastDetection = DateTime.Now.ToString();

                        currentDeviceNetworkIPAddress = NetworkAnalysisUtility.getSubnetAddress(unicastIPAddressInformation.Address.ToString(), unicastIPAddressInformation.IPv4Mask.ToString()).Split('.');
                        currentDeviceWildCardMask = NetworkAnalysisUtility.getWildCardMask(unicastIPAddressInformation.IPv4Mask.ToString());
                        currentDeviceDefaultGatewayIPAddress = NetworkAnalysisUtility.getIPV4DefaultGatewayAdressOfAdaptater(UpAdapters[selectedAdaptaterName]);
                    }
                }
                currentPacketCaptureDevice = UpPacketCaptureDevice[selectedAdaptaterName];
            }
            else if (selectedAdaptaterName == e.ClickedItem.ToString())
            {
                detectedDevices.Clear();
                ClearNetworkListView();
                selectedAdaptaterName = "";
                currentDevice = new Device();
                currentDeviceNetworkIPAddress = new string [0];
                currentDeviceWildCardMask = "";
                currentDeviceDefaultGatewayIPAddress = "";
                currentPacketCaptureDevice = null;   
            }
            
        }

        private void device_OnPacketArrival(object sender, PacketCapture e)
        {
            var time = e.Header.Timeval.Date;
            var rawPacket = e.GetPacket();
            addNewPacketToList(rawPacket, time);
        }

        private void périodeDeRafraîchissementToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (selectedRefreshTime != e.ClickedItem.ToString())
            {
                if (e.ClickedItem.ToString() == "10 sec")
                {
                    sToolStripMenuItem1.Checked = false;
                    sToolStripMenuItem2.Checked = false;
                }
                else if (e.ClickedItem.ToString() == "20 sec")
                {
                    sToolStripMenuItem.Checked = false;
                    sToolStripMenuItem1.Checked = false;
                }
                else if (e.ClickedItem.ToString() == "15 sec")
                {
                    sToolStripMenuItem.Checked = false;
                    sToolStripMenuItem2.Checked = false;
                }

                selectedRefreshTime = e.ClickedItem.ToString();
                timer1.Interval = Int32.Parse(selectedRefreshTime.Substring(0, 2)) * 1000;
            }
            else
            {
                selectedRefreshTime = "";
            }
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            if (selectedAdaptaterName != "")
            {
                if (backgroundWorker1.IsBusy == false)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                if(currentPacketCaptureDevice.Started == false)
                {
                    currentPacketCaptureDevice.Open(DeviceModes.Promiscuous, 200);
                    currentPacketCaptureDevice.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);
                    currentPacketCaptureDevice.StartCapture();
                }
            }
            else
            {
                MessageBox.Show("Aucune carte réseau sélectionnée.", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        //Stop analysis
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();  
            }
            if (currentPacketCaptureDevice.Started == true)
            {
                currentPacketCaptureDevice.StopCapture();
                currentPacketCaptureDevice.Close();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter1.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter1.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter1.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter1.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter1.SortColumn = e.Column;
                lvwColumnSorter1.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void listView3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter3.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter3.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter3.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter3.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter3.SortColumn = e.Column;
                lvwColumnSorter3.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView3.Sort();
        }

        private void completedPing(object sender, PingCompletedEventArgs e)
        {
            string ipAdress = (string)e.Reply.Address.ToString();
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                UpdateNetworkListView(ipAdress);
            }
            
        }

        void UpdateNetworkListView(string ipAdress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UpdateNetworkListViewDelegate(UpdateNetworkListView), ipAdress);
                return;
                
            }
            
            if (ipAdress != currentDevice.IpAddress)
            {
                string macAddress = NetworkAnalysisUtility.getMacAddress(ipAdress).ToUpper();
                Device onlineDevice = new Device(ipAdress, macAddress, NetworkAnalysisUtility.getDnsNameOfIpAddress(ipAdress), NetworkAnalysisUtility.findNicConstructor(macAddress), "",DateTime.Now.ToString(), DateTime.Now.ToString());
                if (ipAdress == currentDeviceDefaultGatewayIPAddress)
                {
                    onlineDevice.Info = "Votre routeur";
                }
                detectedDevices.Add(onlineDevice);
                this.listView1.Items.Add(new ListViewItem(new String[] { onlineDevice.IpAddress, onlineDevice.DomainName, onlineDevice.MacAddress, onlineDevice.Info, onlineDevice.AdaptatorConstructor, onlineDevice.FirstDetection, onlineDevice.LastDetection }));
                this.listView1.Items[detectedDevices.IndexOf(onlineDevice)].ImageIndex = 1;
            }
            else
            {
                detectedDevices.Add(currentDevice);
                this.listView1.Items.Add(new ListViewItem(new String[] { currentDevice.IpAddress, currentDevice.DomainName, currentDevice.MacAddress, currentDevice.Info, currentDevice.AdaptatorConstructor, currentDevice.FirstDetection, currentDevice.LastDetection }));
                this.listView1.Items[detectedDevices.IndexOf(currentDevice)].ImageIndex = 1;
            }
            
            
        }

        void UpdateUnavailableDevice(String ipAdress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UpdateUnavailableDetectedDevice(UpdateUnavailableDevice), ipAdress);
                return;
            }
            Device foundDevice = detectedDevices.Find(device => device.IpAddress == ipAdress);
            this.listView1.Items[detectedDevices.IndexOf(foundDevice)].ImageIndex = 0;
            this.listView1.Items[detectedDevices.IndexOf(foundDevice)].SubItems[6].Text = DateTime.Now.ToString();
            
        }

        void UpdateAvailableDevice(String ipAdress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UpdateAvailableDetectedDevice(UpdateAvailableDevice), ipAdress);
                return;
            }
            Device foundDevice = detectedDevices.Find(device => device.IpAddress == ipAdress);
            this.listView1.Items[detectedDevices.IndexOf(foundDevice)].ImageIndex = 1;
            this.listView1.Items[detectedDevices.IndexOf(foundDevice)].SubItems[6].Text = DateTime.Now.ToString();
        }

        void addNewPacketToList(RawCapture rawPacket, DateTime time)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AddNewPacket(addNewPacketToList), rawPacket, time);
                return;
            }

            var frame = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            string packetTime = "";
            string frameType = "";
            string frameLength = "";
            string srcMacAddr = "";
            string dstMacAddr = "";
            string ethernetPacketType = "";
            string srcIPAddr = "";
            string dstIPAddr = "";
            string srcPort = "";
            string dstPort = "";
            string protocol = "";

            if (frame != null)
            {
                packetIndex++;
                frameLength = frame.TotalPacketLength.ToString();
                frameType = rawPacket.LinkLayerType.ToString();
                protocol = frameType;
                /*switch (time.Month)
                {
                    case 1:
                        packetTime = time.Day + " Janvier " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 2:
                        packetTime = time.Day + " Février " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 3:
                        packetTime = time.Day + " Mars " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 4:
                        packetTime = time.Day + " Avril " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 5:
                        packetTime = time.Day + " Mai " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 6:
                        packetTime = time.Day + " Juin " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 7:
                        packetTime = time.Day + " Juillet " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 8:
                        packetTime = time.Day + " Août " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 9:
                        packetTime = time.Day + " Septembre " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 10:
                        packetTime = time.Day + " Octobre " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 11:
                        packetTime = time.Day + " Novembre " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                    case 12:
                        packetTime = time.Day + " Décembre " + time.Year + ", " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        break;
                }*/
                packetTime = time.Day+ "/"+ time.Month + "/" + time.Year + " " + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;

                var ethernetPacket = frame.Extract<PacketDotNet.EthernetPacket>();
                if (ethernetPacket != null)
                {

                    srcMacAddr = ethernetPacket.DestinationHardwareAddress.ToString();
                    //srcMacConstructor = NetworkAnalysisUtility.findNicConstructorforPcap(srcMacAddr);
                    dstMacAddr = ethernetPacket.SourceHardwareAddress.ToString();
                    //dstMacConstructor = NetworkAnalysisUtility.findNicConstructorforPcap(dstMacAddr);
                    ethernetPacketType = ethernetPacket.Type.ToString();

                    if (ethernetPacketType == "Arp")
                    {
                        var arpPacket = ethernetPacket.Extract<PacketDotNet.ArpPacket>();
                        if (arpPacket != null)
                        {
                            /*string senderMacAddr = arpPacket.SenderHardwareAddress.ToString();
                            string senderIPAddress = arpPacket.SenderProtocolAddress.ToString();
                            string targetMacAddr = arpPacket.TargetHardwareAddress.ToString();
                            string targetIPAddress = arpPacket.TargetProtocolAddress.ToString();
                            string operation = arpPacket.Operation.ToString();
                            string protocolType = arpPacket.ProtocolAddressType.ToString();
                            string hardWareType = arpPacket.HardwareAddressType.ToString();
                            int hardwareSize = arpPacket.HardwareAddressLength;
                            int protocolSize = arpPacket.ProtocolAddressLength;

                            Console.WriteLine("3. ARP (Address Resolution Protocol)");
                            Console.WriteLine("HardWare Type : " + hardWareType);
                            Console.WriteLine("Protocol Type : "+ protocolType);
                            Console.WriteLine("Hardware Size : "+ hardwareSize);
                            Console.WriteLine("Protocol Size : "+ protocolSize);
                            Console.WriteLine("Operation : " + operation);
                            Console.WriteLine("Sender Mac Address : {0}_{1}", NetworkAnalysisUtility.findNicConstructorforPcap(senderMacAddr), senderMacAddr.Substring(6, 6));
                            Console.WriteLine("Sender IP Address : " + senderIPAddress);

                            if(targetMacAddr != "000000000000")
                            {
                                Console.WriteLine("Target Mac Address : {0}_{1}", NetworkAnalysisUtility.findNicConstructorforPcap(targetMacAddr), targetMacAddr.Substring(6, 6));
                            }
                            else
                            {
                                Console.WriteLine("Target Mac Address : {0}", targetMacAddr);
                            }
                            Console.WriteLine("Target IP Address : " + targetIPAddress);*/

                            srcIPAddr = arpPacket.SenderProtocolAddress.ToString();
                            dstIPAddr = arpPacket.TargetProtocolAddress.ToString();
                            srcMacAddr = arpPacket.SenderHardwareAddress.ToString();
                            dstMacAddr = arpPacket.TargetHardwareAddress.ToString();
                            protocol = "ARP";

                        }
                    }
                    else if (ethernetPacketType == "IPv4")
                    {

                        var ipv4Packet = ethernetPacket.Extract<PacketDotNet.IPPacket>();
                        if (ipv4Packet != null)
                        {

                            srcIPAddr = ipv4Packet.SourceAddress.ToString();
                            dstIPAddr = ipv4Packet.DestinationAddress.ToString();
                            protocol = "IPV4";
                            /*string version = ipv4Packet.Version.ToString();
                            int headerLength = ipv4Packet.HeaderLength;
                            int totalLength = ipv4Packet.TotalLength;*/

                            /*string ttl = ipv4Packet.TimeToLive.ToString();
                            string hop = ipv4Packet.HopLimit.ToString();
                            string nextProtocol = ipv4Packet.Protocol.ToString();*/
                            /*Console.WriteLine("4. Internet Protocol Version 4");
                            Console.WriteLine("Version : " + version);
                            Console.WriteLine("Header Length : " + headerLength);
                            Console.WriteLine("Total Length : " + totalLength);
                            Console.WriteLine("Protocol : " + nextProtocol);
                            Console.WriteLine("TTL : " + ttl);
                            Console.WriteLine("Hop limit : " + hop);
                            Console.WriteLine("Source Address : " + srcIp);
                            Console.WriteLine("Destination Address : " + dstIp);*/

                        }
                        var icmpPacket = ethernetPacket.Extract<PacketDotNet.IcmpV4Packet>();
                        if (icmpPacket != null)
                        {
                            string operation = icmpPacket.TypeCode.ToString();
                            string chekcsum = icmpPacket.Checksum.ToString();
                            bool validChecksum = icmpPacket.ValidIcmpChecksum;
                            string Id = icmpPacket.Id.ToString();
                            string sequence = icmpPacket.Sequence.ToString();
                            protocol = "ICMPV4";
                        }

                        var tcpPacket = ethernetPacket.Extract<PacketDotNet.TcpPacket>();
                        if (tcpPacket != null)
                        {
                            srcPort = tcpPacket.SourcePort.ToString();
                            dstPort = tcpPacket.DestinationPort.ToString();
                            /*string checksum = tcpPacket.Checksum.ToString();
                            string checksumValid = tcpPacket.ValidChecksum.ToString();
                            bool isAckPacket = tcpPacket.Acknowledgment;
                            bool isRstPacket = tcpPacket.Reset;
                            string ackNmber = tcpPacket.AcknowledgmentNumber.ToString();
                            bool isCongestionWindowsReduced = tcpPacket.CongestionWindowReduced;
                            bool isFinishedPacket = tcpPacket.Finished;
                            bool isPushPacket = tcpPacket.Push;
                            string sequenceNumber = tcpPacket.SequenceNumber.ToString();
                            bool isSynchronize = tcpPacket.Synchronize;
                            bool isUrgent = tcpPacket.Urgent;
                            bool isNonce = tcpPacket.NonceSum;
                            bool isECN_Echo = tcpPacket.ExplicitCongestionNotificationEcho;
                            int length = tcpPacket.TotalPacketLength;
                            string tcpWindows = tcpPacket.WindowSize.ToString();*/

                            /*Console.WriteLine("Source Port : " + srcPort);
                            Console.WriteLine("Destination Port : " + dstPort);
                            Console.WriteLine("Sequence Number : " + sequenceNumber);
                            Console.WriteLine("Length : " + length);
                            Console.WriteLine("Ack number : " + ackNmber);
                            Console.WriteLine("isAckPacket : " + isAckPacket);
                            Console.WriteLine("isRstPacket" + isRstPacket);
                            Console.WriteLine("isCongestionWindowsReduced" + isCongestionWindowsReduced);
                            Console.WriteLine("isFinishedPacket" + isFinishedPacket);
                            Console.WriteLine("isPushPacket" + isPushPacket);
                            Console.WriteLine("isSynchronize" + isSynchronize);
                            Console.WriteLine("isUrgent" + isUrgent);
                            Console.WriteLine("isNonce" + isNonce);
                            Console.WriteLine("isECN_Echo" + isECN_Echo);
                            Console.WriteLine("Window Size : " + tcpWindows);
                            Console.WriteLine("Checksum : " + checksum);
                            Console.WriteLine("Checksum is Valid : " + checksumValid);*/
                            protocol = "TCPV4";
                        }
                        var udpPacket = ethernetPacket.Extract<PacketDotNet.UdpPacket>();
                        if (udpPacket != null)
                        {

                            dstPort = udpPacket.DestinationPort.ToString();
                            srcPort = udpPacket.SourcePort.ToString();
                            /*bool isValidCheckSum = udpPacket.ValidChecksum;
                            string checkSum = udpPacket.Checksum.ToString();
                            string length = udpPacket.Length.ToString();
                            Console.WriteLine("Source Port : " + srcPort);
                            Console.WriteLine("Destination Port : " + dstPort);
                            Console.WriteLine("Length : " + length);
                            Console.WriteLine("Checksum : " + checkSum);
                            Console.WriteLine("IsValid checksum : " + isValidCheckSum);*/
                            protocol = "UDPV4";
                        }


                    }
                    else if (ethernetPacketType == "IPv6")
                    {

                        var ipv6Packet = ethernetPacket.Extract<PacketDotNet.IPPacket>();
                        if (ipv6Packet != null)
                        {

                            srcIPAddr = ipv6Packet.SourceAddress.ToString();
                            srcIPAddr = ipv6Packet.DestinationAddress.ToString();
                            protocol = "IPV6";
                            /*string version = ipv6Packet.Version.ToString();
                            int payloadLength = ipv6Packet.PayloadLength;
                            string ttl = ipv6Packet.TimeToLive.ToString();
                            string hop = ipv6Packet.HopLimit.ToString();
                            string nextProtocol = ipv6Packet.Protocol.ToString();*/

                            /*Console.WriteLine("4. Internet Protocol Version 6");
                            Console.WriteLine("Version : " + version);
                            Console.WriteLine("Payload Length : " + payloadLength);
                            Console.WriteLine("Next Protocol : " + nextProtocol);
                            Console.WriteLine("Hop Limit : " + hop);
                            Console.WriteLine("Source Address : " + srcIp);
                            Console.WriteLine("Destination Address : " + dstIp);
                            Console.WriteLine("TTL : "+ ttl);*/

                        }
                        var icmp6Packet = frame.Extract<PacketDotNet.IcmpV6Packet>();
                        if (icmp6Packet != null)
                        {
                            protocol = "ICMPV6";
                            /*string code = icmp6Packet.Code.ToString();
                            string Icmp6type = icmp6Packet.Type.ToString();
                            string chekcsum = icmp6Packet.Checksum.ToString();
                            bool validChecksum = icmp6Packet.ValidIcmpChecksum;*/
                            /*Console.WriteLine("Type : " + Icmp6type);
                            Console.WriteLine("Code : " + code);
                            Console.WriteLine("Checksum : " + chekcsum);
                            Console.WriteLine("isValidChecksem : " + validChecksum);*/

                        }
                        var tcpPacket = ethernetPacket.Extract<PacketDotNet.TcpPacket>();
                        if (tcpPacket != null)
                        {
                            protocol = "TCPV6";
                            srcPort = tcpPacket.SourcePort.ToString();
                            dstPort = tcpPacket.DestinationPort.ToString();
                            /*string checksum = tcpPacket.Checksum.ToString();
                            string checksumValid = tcpPacket.ValidChecksum.ToString();
                            bool isAckPacket = tcpPacket.Acknowledgment;
                            bool isRstPacket = tcpPacket.Reset;
                            string ackNmber = tcpPacket.AcknowledgmentNumber.ToString();
                            bool isCongestionWindowsReduced = tcpPacket.CongestionWindowReduced;
                            bool isFinishedPacket = tcpPacket.Finished;
                            bool isPushPacket = tcpPacket.Push;
                            string sequenceNumber = tcpPacket.SequenceNumber.ToString();
                            bool isSynchronize = tcpPacket.Synchronize;
                            bool isUrgent = tcpPacket.Urgent;
                            bool isNonce = tcpPacket.NonceSum;
                            bool isECN_Echo = tcpPacket.ExplicitCongestionNotificationEcho;
                            int length = tcpPacket.TotalPacketLength;
                            string tcpWindows = tcpPacket.WindowSize.ToString();*/

                            /*Console.WriteLine("Source Port : " + srcPort);
                            Console.WriteLine("Destination Port : " + dstPort);
                            Console.WriteLine("Sequence Number : " + sequenceNumber);
                            Console.WriteLine("Length : " + length);
                            Console.WriteLine("Ack number : " + ackNmber);
                            Console.WriteLine("isAckPacket : " + isAckPacket);
                            Console.WriteLine("isRstPacket" + isRstPacket);
                            Console.WriteLine("isCongestionWindowsReduced" + isCongestionWindowsReduced);
                            Console.WriteLine("isFinishedPacket" + isFinishedPacket);
                            Console.WriteLine("isPushPacket" + isPushPacket);
                            Console.WriteLine("isSynchronize" + isSynchronize);
                            Console.WriteLine("isUrgent" + isUrgent);
                            Console.WriteLine("isNonce" + isNonce);
                            Console.WriteLine("isECN_Echo" + isECN_Echo);
                            Console.WriteLine("Window Size : " + tcpWindows);
                            Console.WriteLine("Checksum : " + checksum);
                            Console.WriteLine("Checksum is Valid : " + checksumValid);*/
                        }
                        var udpPacket = ethernetPacket.Extract<PacketDotNet.UdpPacket>();
                        if (udpPacket != null)
                        {
                            protocol = "UDPV6";
                            dstPort = udpPacket.DestinationPort.ToString();
                            srcPort = udpPacket.SourcePort.ToString();
                            /*bool isValidCheckSum = udpPacket.ValidChecksum;
                            string length = udpPacket.Length.ToString();
                            string checkSum = udpPacket.Checksum.ToString();

                            Console.WriteLine("Source Port : " + srcPort);
                            Console.WriteLine("Destination Port : " + dstPort);
                            Console.WriteLine("Length : " + length);
                            Console.WriteLine("Checksum : " + checkSum);
                            Console.WriteLine("IsValid checksum : " + isValidCheckSum);*/
                        }

                    }
                }
                
                this.listView3.Items.Add(new ListViewItem(new String[] { packetIndex.ToString(), srcIPAddr, dstIPAddr, srcMacAddr, dstMacAddr, srcPort, dstPort, protocol, frameLength, packetTime }));
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                if (selectedAdaptaterName != "")
                {
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
                
            }
            
            AddNetworkAndPacketCaptureAdaptater();
            MakeNetWorkAdaptaterToolStripCheckable();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int addressNumber = NetworkAnalysisUtility.getNumberOfAvailableAddresses(currentDeviceWildCardMask);
            for (int i = 1; i < addressNumber; i++)
            {
                if (worker.CancellationPending != true)
                {
                    // Perform a time consuming operation and report progress.
                    string ipAddress = NetworkAnalysisUtility.generateIpAddress(currentDeviceNetworkIPAddress, i);
                    if (detectedDevices.Exists(device => device.IpAddress == ipAddress))
                    {
                        Ping pingSender = new Ping();
                        PingReply reply = pingSender.Send(ipAddress, 100);
                        if (reply.Status == IPStatus.Success)
                        {
                            UpdateAvailableDevice(ipAddress);
                        }
                        else
                        {
                            Ping pingAgain = new Ping();
                            PingReply replyAgain = pingSender.Send(ipAddress, 1000);
                            if (!(reply.Status == IPStatus.Success))
                            {
                                UpdateUnavailableDevice(ipAddress);
                            }
                           
                        }
                    }
                    else
                    {
                        Ping pingSender = new Ping();
                        pingSender.PingCompleted += new PingCompletedEventHandler(completedPing);
                        pingSender.SendAsync(ipAddress, 50);
                        
                    }

                }
                else
                {
                    e.Cancel = true;
                    break;
                }
             
            }  
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                deviceDetails.IpAddress = listView1.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
                deviceDetails.DomainName = listView1.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
                deviceDetails.MacAddress = listView1.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
                deviceDetails.Info = listView1.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
                deviceDetails.AdaptatorConstructor = listView1.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
                deviceDetails.FirstDetection = listView1.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
                deviceDetails.LastDetection = listView1.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');
                deviceDetailForm detailForm = new deviceDetailForm();
                detailForm.Show();

            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                saveBtn.Enabled = true;
                detailBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }
            else
            {
                saveBtn.Enabled = false;
                detailBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
           
        }

        private void listView3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView3.SelectedItems.Count == 1)
            {
                saveBtn.Enabled = true;
                detailBtn.Enabled = true;
            }
            else
            {
                saveBtn.Enabled = false;
                detailBtn.Enabled = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "c:\\";
            String saveInfo = "///////////////////////////////////////////////// \n";

            if (tabControl1.SelectedIndex == 0)
            {
                saveFileDialog.Title = "Sauvegarder un périphérique";
                String ipAddress = listView1.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
                String macAdress = listView1.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
                String deviceName = listView1.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
                String deviceInfo = listView1.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
                String deviceConstructor = listView1.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
                String firstDetection = listView1.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
                String lastDetection = listView1.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');


                saveInfo += "Adresse IP --> " + ipAddress + "  \n";
                saveInfo += "Adresse MAC --> " + macAdress + "  \n";
                saveInfo += "Périphérique --> " + deviceName + "  \n";
                saveInfo += "Information --> " + deviceInfo + "  \n";
                saveInfo += "Constructeur --> " + deviceConstructor + "  \n";
                saveInfo += "Premiere Détection --> " + firstDetection + "  \n";
                saveInfo += "Dernière Détection --> " + lastDetection + "  \n";
            }
            else if (tabControl1.SelectedIndex == 1){
                
            }
            else if (tabControl1.SelectedIndex == 2){
                saveFileDialog.Title = "Sauvegarder un packet";
                String index = listView3.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
                String ipAddressSrc = listView3.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
                String ipAddressDst = listView3.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
                String macAddressSrc = listView3.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
                String macAddresDst = listView3.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
                String portSrc = listView3.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
                String portDst = listView3.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');
                String protocol = listView3.SelectedItems[0].SubItems[7].ToString().Substring(18).Trim('}');
                String length = listView3.SelectedItems[0].SubItems[8].ToString().Substring(18).Trim('}');
                String ArrivalTime = listView3.SelectedItems[0].SubItems[9].ToString().Substring(18).Trim('}');

                saveInfo += "Index --> " + index + "  \n";
                saveInfo += "Adresse IP Source --> " + ipAddressSrc + "  \n";
                saveInfo += "Adresse IP Destination --> " + ipAddressDst + "  \n";
                saveInfo += "Adresse MAC Source --> " + macAddressSrc + "  \n";
                saveInfo += "Adresse MAC Destination --> " + macAddresDst + "  \n";
                saveInfo += "Port Source --> " + portSrc + "  \n";
                saveInfo += "Port Distant --> " + portDst + "  \n";
                saveInfo += "Protocole --> " + protocol + "  \n";
                saveInfo += "Taille --> " + length + "  \n";
                saveInfo += "Temps d'arrivée --> " + ArrivalTime + "  \n";
            }

            saveInfo += "///////////////////////////////////////////////// \n";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, saveInfo);
            }

        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            String clipBoardInfo = "///////////////////////////////////////////////// \n";

            if (tabControl1.SelectedIndex == 0)
            {
                String ipAddress = listView1.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
                String macAdress = listView1.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
                String deviceName = listView1.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
                String deviceInfo = listView1.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
                String deviceConstructor = listView1.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
                String firstDetection = listView1.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
                String lastDetection = listView1.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');


                clipBoardInfo += "Adresse IP --> " + ipAddress + "  \n";
                clipBoardInfo += "Adresse MAC --> " + macAdress + "  \n";
                clipBoardInfo += "Périphérique --> " + deviceName + "  \n";
                clipBoardInfo += "Information --> " + deviceInfo + "  \n";
                clipBoardInfo += "Constructeur --> " + deviceConstructor + "  \n";
                clipBoardInfo += "Premiere Détection --> " + firstDetection + "  \n";
                clipBoardInfo += "Dernière Détection --> " + lastDetection + "  \n";
            }
            else if(tabControl1.SelectedIndex == 1)
            {

            }else if (tabControl1.SelectedIndex == 2)
            {
                String index = listView3.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
                String ipAddressSrc = listView3.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
                String ipAddressDst = listView3.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
                String macAddressSrc = listView3.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
                String macAddresDst = listView3.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
                String portSrc = listView3.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
                String portDst = listView3.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');
                String protocol = listView3.SelectedItems[0].SubItems[7].ToString().Substring(18).Trim('}');
                String length = listView3.SelectedItems[0].SubItems[8].ToString().Substring(18).Trim('}');
                String ArrivalTime = listView3.SelectedItems[0].SubItems[9].ToString().Substring(18).Trim('}');

                clipBoardInfo += "Index --> " + index + "  \n";
                clipBoardInfo += "Adresse IP Source --> " + ipAddressSrc + "  \n";
                clipBoardInfo += "Adresse IP Destination --> " + ipAddressDst + "  \n";
                clipBoardInfo += "Adresse MAC Source --> " + macAddressSrc + "  \n";
                clipBoardInfo += "Adresse MAC Destination --> " + macAddresDst + "  \n";
                clipBoardInfo += "Port Source --> " + portSrc + "  \n";
                clipBoardInfo += "Port Distant --> " + portDst + "  \n";
                clipBoardInfo += "Protocole --> " + protocol + "  \n";
                clipBoardInfo += "Taille --> " + length + "  \n";
                clipBoardInfo += "Temps d'arrivée --> " + ArrivalTime + "  \n";
            }
                
            
            clipBoardInfo += "///////////////////////////////////////////////// \n";

            Clipboard.SetDataObject(clipBoardInfo);

        }

        private String PadCenter(string original, int totalWidth, char paddingChar = ' ')
        {
            int spaces = totalWidth - original.Length;
            int padLeft = spaces / 2 + original.Length;
            return original.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }

        private void saveElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Sauvegarder un périphérique";
                saveFileDialog.InitialDirectory = "c:\\";

                String saveInfo = "+-----+-----------------+--------------------+-------------------------------+---------------------+----------------------------------+---------------------+---------------------+ \n";
                saveInfo += "|     |                 |                    |                               |                     |                                  |                     |                     | \n";
                saveInfo += "|  N° |   Adresse IP    |     Adresse MAC    |         Périphérique          |     Information     |           Constructeur           |  Premiere Détection |  Dernière Détection | \n";
                saveInfo += "|     |                 |                    |                               |                     |                                  |                     |                     | \n";
                saveInfo += "+-----+-----------------+--------------------+-------------------------------+---------------------+----------------------------------+---------------------+---------------------+ \n";
                
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    String ipAddress = listView1.SelectedItems[i].SubItems[0].ToString().Substring(18).Trim('}');
                    String macAdress = listView1.SelectedItems[i].SubItems[2].ToString().Substring(18).Trim('}');
                    String deviceName = listView1.SelectedItems[i].SubItems[1].ToString().Substring(18).Trim('}');
                    String deviceInfo = listView1.SelectedItems[i].SubItems[3].ToString().Substring(18).Trim('}');
                    String deviceConstructor = listView1.SelectedItems[i].SubItems[4].ToString().Substring(18).Trim('}');
                    String firstDetection = listView1.SelectedItems[i].SubItems[5].ToString().Substring(18).Trim('}');
                    String lastDetection = listView1.SelectedItems[i].SubItems[6].ToString().Substring(18).Trim('}');

                    saveInfo += "|" + PadCenter((i + 1).ToString(),5) + "|" + PadCenter(ipAddress,17) + "|" + PadCenter(macAdress,20) + "|" + PadCenter(deviceName,31) + "|" + PadCenter(deviceInfo,21) + "|" + PadCenter(deviceConstructor,34) + "|" + PadCenter(firstDetection,21) + "|" + PadCenter(lastDetection,21) + "| \n";
                    saveInfo += "+-----+-----------------+--------------------+-------------------------------+---------------------+----------------------------------+---------------------+---------------------+ \n";
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, saveInfo);
                }
            }

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                detectedDevices.Clear();
                ClearNetworkListView();

            }else if (tabControl1.SelectedIndex == 1)
            {
                
            }else if (tabControl1.SelectedIndex == 2)
            {
                ClearPacketCaptureListView();
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            detectedDevices.RemoveAt(listView1.SelectedItems[0].Index);
            listView1.SelectedItems[0].Remove();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            deviceSearchForm deviceSearchFm = new deviceSearchForm(this);
            deviceSearchFm.Show();
        }

       
    } 
}
