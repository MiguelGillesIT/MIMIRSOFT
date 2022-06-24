using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        private Dictionary<string,NetworkInterface> UpAdapters  = new Dictionary<string, NetworkInterface>();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load available network adaptater's into "Carte reseau" tool strip and make them available
            InitializeNetWorkAdaptater();
            MakeNetWorkAdaptaterToolStripCheckable();
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
                                            MessageBox.Show("Address disponible: " + reply.Address.ToString());

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

        
    }
}