using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeNetWorkAdaptater();

        }

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
                            if(adapter.Name != "Loopback Pseudo-Interface 1"){

                                carteRéseauToolStripMenuItem.DropDown.Items.Add(adapter.Name);

                            }
                            
                        }

                    }
                }
            }
        }
    
    }
}