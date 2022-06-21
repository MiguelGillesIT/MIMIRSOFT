using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MIMIRSOFT
{
    public partial class Form1 : Form
    {
        //private Dictionary<string,NetworkInterface> UpAdapters;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
                                //UpAdapters.Add(adapter.Name, adapter);
                                NetAdaptToolStripMenuItem.DropDown.Items.Add(adapter.Name);
                            }   
                        }
                    }
                }
            }

        }
  
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
                        //UpAdapters[item.Text]
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune carte réseau sélectionnée");
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(startBtn.Enabled == false)
            {
                startBtn.Enabled = true;
            }
        }

        
    }
}