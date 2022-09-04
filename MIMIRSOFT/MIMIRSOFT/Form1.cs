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
        private string selectedRefreshTime = "";

        private string[] currentDeviceNetworkIPAddress;
        private string currentDeviceWildCardMask;
        private Device currentDevice = new Device();
        private string currentDeviceDefaultGatewayIPAddress;
        
        public List<Device> detectedDevices = new List<Device>();

        delegate void UpdateNetworkListViewDelegate(String ipAdress);
        delegate void UpdateUnavailableDetectedDevice(String ipAdress);
        delegate void UpdateAvailableDetectedDevice(String ipAdress);

        public static Device deviceDetails = new Device() ;

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load available network adaptater's into "Carte reseau" tool strip and make them available
            AddNetworkAdaptater();
            MakeNetWorkAdaptaterToolStripCheckable();
            
            timer1.Interval = Int32.Parse(sToolStripMenuItem.Text.Substring(0,2)) * 1000;

        }

        void NetworkAnalysis()
        {
            int addressNumber = NetworkAnalysisUtility.getNumberOfAvailableAddresses(currentDeviceWildCardMask);
            for (int i = 1; i < addressNumber; i++)
            {
                // Perform a time consuming operation and report progress.
                string ipAddress = NetworkAnalysisUtility.generateIpAddress(currentDeviceNetworkIPAddress, i);
                if (detectedDevices.Exists(device => device.IpAddress == ipAddress))
                {
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(ipAddress, 200);
                    if (reply.Status == IPStatus.Success)
                    {
                        UpdateAvailableDevice(ipAddress);
                    }
                    else
                    {
                        UpdateUnavailableDevice(ipAddress);
                    }
                }
                else
                {
                    Ping pingSender = new Ping();
                    pingSender.PingCompleted += new PingCompletedEventHandler(completedPing);
                    pingSender.SendAsync(ipAddress, 200);
                }
            }
        }

        public void MakeNetWorkAdaptaterToolStripCheckable()
        {
            foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
            {
                item.CheckOnClick = true;
            }
        }
        
        //Add network adaptater into Upadaptater dictionnary and in "Carte Reseau" Tool Strip
        public void AddNetworkAdaptater()
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
                                    UpAdapters.Add(adapter.Name, adapter);
                                    NetAdaptToolStripMenuItem.DropDown.Items.Add(adapter.Name);
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
            }
        }

        private void p�riodeDeRafra�chissementToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
            
            if (backgroundWorker1.IsBusy != true)
            {
                if (selectedAdaptaterName != "")
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Aucune carte r�seau s�lectionn�e.", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                if (selectedAdaptaterName != "")
                {
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
                
            }
            
            AddNetworkAdaptater();
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
                        PingReply reply = pingSender.Send(ipAddress, 200);
                        if (reply.Status == IPStatus.Success)
                        {
                            UpdateAvailableDevice(ipAddress);
                        }
                        else
                        {
                            UpdateUnavailableDevice(ipAddress);
                        }
                    }
                    else
                    {
                        Ping pingSender = new Ping();
                        pingSender.PingCompleted += new PingCompletedEventHandler(completedPing);
                        pingSender.SendAsync(ipAddress, 200);
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String ipAddress = listView1.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
            String macAdress = listView1.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
            String deviceName = listView1.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
            String deviceInfo = listView1.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
            String deviceConstructor = listView1.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
            String firstDetection = listView1.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
            String lastDetection = listView1.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');
            
            String clipBoardInfo = "///////////////////////////////////////////////// \n";
            clipBoardInfo += "Adresse IP --> " + ipAddress  + "  \n";
            clipBoardInfo += "Adresse MAC --> " + macAdress + "  \n";
            clipBoardInfo += "P�riph�rique --> " + deviceName + "  \n";
            clipBoardInfo += "Information --> " + deviceInfo + "  \n";
            clipBoardInfo += "Constructeur --> " + deviceConstructor + "  \n";
            clipBoardInfo += "Premiere D�tection --> " + firstDetection + "  \n";
            clipBoardInfo += "Derni�re D�tection --> " + lastDetection + "  \n";
            clipBoardInfo += "///////////////////////////////////////////////// \n";

            Clipboard.SetDataObject(clipBoardInfo);
            
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Sauvegarder un p�riph�rique";
            saveFileDialog.InitialDirectory = "c:\\";

            String ipAddress = listView1.SelectedItems[0].SubItems[0].ToString().Substring(18).Trim('}');
            String macAdress = listView1.SelectedItems[0].SubItems[2].ToString().Substring(18).Trim('}');
            String deviceName = listView1.SelectedItems[0].SubItems[1].ToString().Substring(18).Trim('}');
            String deviceInfo = listView1.SelectedItems[0].SubItems[3].ToString().Substring(18).Trim('}');
            String deviceConstructor = listView1.SelectedItems[0].SubItems[4].ToString().Substring(18).Trim('}');
            String firstDetection = listView1.SelectedItems[0].SubItems[5].ToString().Substring(18).Trim('}');
            String lastDetection = listView1.SelectedItems[0].SubItems[6].ToString().Substring(18).Trim('}');

            String saveInfo = "///////////////////////////////////////////////// \n";
            saveInfo += "Adresse IP --> " + ipAddress + "  \n";
            saveInfo += "Adresse MAC --> " + macAdress + "  \n";
            saveInfo += "P�riph�rique --> " + deviceName + "  \n";
            saveInfo += "Information --> " + deviceInfo + "  \n";
            saveInfo += "Constructeur --> " + deviceConstructor + "  \n";
            saveInfo += "Premiere D�tection --> " + firstDetection + "  \n";
            saveInfo += "Derni�re D�tection --> " + lastDetection + "  \n";
            saveInfo += "///////////////////////////////////////////////// \n";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, saveInfo);
            }
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
                saveFileDialog.Title = "Sauvegarder un p�riph�rique";
                saveFileDialog.InitialDirectory = "c:\\";

                String saveInfo = "+-----+-----------------+--------------------+-------------------------------+---------------------+----------------------------------+---------------------+---------------------+ \n";
                saveInfo += "|     |                 |                    |                               |                     |                                  |                     |                     | \n";
                saveInfo += "|  N� |   Adresse IP    |     Adresse MAC    |         P�riph�rique          |     Information     |           Constructeur           |  Premiere D�tection |  Derni�re D�tection | \n";
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
            detectedDevices.Clear();
            ClearNetworkListView();
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
