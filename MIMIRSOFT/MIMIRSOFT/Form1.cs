using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private Dictionary<string,NetworkInterface> UpAdapters  = new Dictionary<string, NetworkInterface>();
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
            InterfaceContentsToImplement();
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

        //Check if almost one network adaptater has been selected
        public Boolean IsChoosenAdaptaters()
        {
            foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
            {
                if (item.Checked == true)
                {
                    return true;
                }
            }
            return false;
        }

        //A set of elements to add programmatically 
        public void InterfaceContentsToImplement()
        {
            listView1.Items.Add(new ListViewItem(new String[] { "192.168.1.1", "192.168.1.1", "192.168.1.1", "192.168.1.14", "192.168.1.1", "192.168.1.1", "192.168.1.1" }));
            listView1.Items.Add(new ListViewItem(new String[] { "192.168.1.2", "192.168.1.2", "192.168.1.3", "192.168.1.2", "192.168.1.5", "192.168.1.2", "192.168.1.2" }));
            listView1.Items.Add(new ListViewItem(new String[] { "192.168.1.3", "192.168.1.1", "192.168.1.2", "192.168.1.3", "192.168.1.3", "192.168.1.3", "192.168.1.3" }));
            listView1.Items.Add(new ListViewItem(new String[] { "192.168.1.4", "192.168.1.4", "192.168.1.4", "192.168.1.1", "192.168.1.8", "192.168.1.4", "192.168.1.4" }));
            listView1.Items[0].ImageIndex = 0;
            listView1.Items[1].ImageIndex = 1;
            listView1.Items[2].ImageIndex = 0;
            listView1.Items[3].ImageIndex = 1;
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            
            if (IsChoosenAdaptaters())
            {
                startBtn.Enabled = false;
                foreach (ToolStripMenuItem item in NetAdaptToolStripMenuItem.DropDownItems)
                {
                    if (item.Checked == true)
                    {
                        if(iPV4ToolStripMenuItem.Checked == true)
                        {
                            foreach (UnicastIPAddressInformation unicastIPAddressInformation in UpAdapters[item.Text].GetIPProperties().UnicastAddresses)
                            {
                                if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    string[] networkIPAddress = NetworkUtility.getSubnetAddress(unicastIPAddressInformation.Address.ToString(), unicastIPAddressInformation.IPv4Mask.ToString()).Split('.');
                                    string wildCardMask = NetworkUtility.getWildCardMask(unicastIPAddressInformation.IPv4Mask.ToString());
                                    int addressNumber = NetworkUtility.getNumberOfAvailableAddresses(wildCardMask);
                                    Ping pingSender = new Ping();
                                    PingReply reply;
                                    for (int i = 0; i < addressNumber; i++)
                                    {
                                        string ipAddress = NetworkUtility.generateIpAddress(networkIPAddress, i);
                                        reply = pingSender.Send(ipAddress, 50);
                                        if (reply.Status == IPStatus.Success)
                                        {
                                            MessageBox.Show(reply.Address.ToString()); 
                                           /* string[] row = { reply.Address.ToString(),"" ,"" ,"" ,"" ,"" ,"" };
                                            listView1.Items.Add(new ListViewItem(row));*/

                                        }
                                    }


                                }

                            }

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune carte réseau sélectionnée");
            }
        }

        //Stop analysis
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(startBtn.Enabled == false)
            {
                startBtn.Enabled = true;
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
    }
}