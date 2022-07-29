using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ComponentModel;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private Dictionary<string,NetworkInterface> UpAdapters  = new Dictionary<string, NetworkInterface>();

        private string selectedAdaptaterName = "";
        private string[] currentDeviceNetworkIPAddress;
        private string currentDeviceWildCardMask;
        private Device currentDevice = new Device();
        private string currentDeviceDefaultGatewayIPAddress;

        private List<Device> onlineDevices = new List<Device>();
        private List<Device> offlineDevices = new List<Device>();

       
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load available network adaptater's into "Carte reseau" tool strip and make them available
            InitializeNetWorkAdaptater();
            MakeNetWorkAdaptaterToolStripCheckable();
            timer1.Interval = 1000 * 30;
            //timer1.Interval = Int32.Parse(sToolStripMenuItem.Text.Substring(0,1)) * 1000 * 60;

        }

        public void MakeNetWorkAdaptaterToolStripCheckable()
        {
            foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
            {
                item.CheckOnClick = true;
            }
        }
        
        //Add network adaptater into Upadaptater dictionnary and in "Carte Reseau" Tool Strip
        public void InitializeNetWorkAdaptater()
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
                                UpAdapters.Add(adapter.Name, adapter);
                                NetAdaptToolStripMenuItem.DropDown.Items.Add(adapter.Name);
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
                for (int i = 0; i <= listView1.Items.Count + 1; i++)
                {
                    listView1.Items.RemoveAt(0);
                }
            }
            
        }
        private void NetAdaptToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (selectedAdaptaterName != e.ClickedItem.ToString())
            {
                ClearNetworkListView();
                selectedAdaptaterName = e.ClickedItem.ToString();
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in UpAdapters[selectedAdaptaterName].GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        currentDevice.IpAddress = unicastIPAddressInformation.Address.ToString();
                        currentDevice.MacAddress = NetworkUtility.getMacAddressOfAdaptater(UpAdapters[selectedAdaptaterName]).ToUpper();
                        currentDevice.DomainName = NetworkUtility.getDnsNameOfIpAddress(currentDevice.IpAddress);
                        currentDevice.AdaptatorConstructor = NetworkUtility.findNicConstructor(currentDevice.MacAddress);
                        currentDevice.Info = "Votre Machine";
                        currentDevice.MacAddress = currentDevice.MacAddress.Substring(0, 2) + "-" + currentDevice.MacAddress.Substring(2, 2) + "-" + currentDevice.MacAddress.Substring(4, 2) + "-" + currentDevice.MacAddress.Substring(6, 2) + "-" + currentDevice.MacAddress.Substring(8, 2) + "-" + currentDevice.MacAddress.Substring(10, 2);


                        currentDeviceNetworkIPAddress = NetworkUtility.getSubnetAddress(unicastIPAddressInformation.Address.ToString(), unicastIPAddressInformation.IPv4Mask.ToString()).Split('.');
                        currentDeviceWildCardMask = NetworkUtility.getWildCardMask(unicastIPAddressInformation.IPv4Mask.ToString());
                        currentDeviceDefaultGatewayIPAddress = NetworkUtility.getIPV4DefaultGatewayAdressOfAdaptater(UpAdapters[selectedAdaptaterName]);
                    }
                }
            }
            else if (selectedAdaptaterName == e.ClickedItem.ToString())
            {
                selectedAdaptaterName = "";
            }
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {    
            if (selectedAdaptaterName != "")
            {
                startBtn.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                startBtn.Enabled = true;
            }
            else
            { 
                MessageBox.Show("Aucune carte réseau sélectionnée","Alerte",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            startBtn.Enabled = true;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void completedPing(object sender, PingCompletedEventArgs e)
        {
            string ipAdress = (string)e.Reply.Address.ToString();
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (ipAdress != currentDevice.IpAddress)
                {
                    string macAddress = NetworkUtility.getMacAddress(ipAdress).ToUpper();
                    Device onlineDevice = new Device(ipAdress, macAddress, NetworkUtility.getDnsNameOfIpAddress(ipAdress), NetworkUtility.findNicConstructor(macAddress));
                    if (ipAdress == currentDeviceDefaultGatewayIPAddress)
                    {
                        onlineDevice.Info = "Votre routeur";
                    }

                    onlineDevices.Add(onlineDevice);
                    UpdateNetworkListView(onlineDevice, onlineDevices.IndexOf(onlineDevice));
                    

                }
                else
                {
                    onlineDevices.Add(currentDevice);
                    UpdateNetworkListView(currentDevice, onlineDevices.IndexOf(currentDevice));
                }
            }
            
        }


        delegate void UpdateNetworkListViewDelegate(Device device,int index);

        void UpdateNetworkListView(Device device, int index)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UpdateNetworkListViewDelegate(UpdateNetworkListView), device,index);
                return;
            }

            this.listView1.Items.Add(new ListViewItem(new String[] { device.IpAddress, device.DomainName, device.MacAddress, device.Info, device.AdaptatorConstructor, "", DateTime.Now.ToString() }));
            listView1.Items[index].ImageIndex = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            int addressNumber = NetworkUtility.getNumberOfAvailableAddresses(currentDeviceWildCardMask);
            for (int i = 1; i < addressNumber; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    Ping pingSender = new Ping();
                    string ipAddress = NetworkUtility.generateIpAddress(currentDeviceNetworkIPAddress, i);
                    pingSender.PingCompleted += new PingCompletedEventHandler(completedPing);
                    pingSender.SendAsync(ipAddress, 50);
                }

            }
          
        }
    }
}
