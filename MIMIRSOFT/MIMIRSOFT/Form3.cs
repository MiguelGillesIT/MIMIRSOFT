using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIMIRSOFT
{
    public partial class deviceSearchForm : Form
    {
        private Form1 form1;

        public deviceSearchForm()
        {
            InitializeComponent();
        }

        public deviceSearchForm(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if(form1.listView1.Items.Count > 0)
            {
                if (searchTbx.Text != "")
                {
                    //ListViewItem foundItem = new ListViewItem();
                    List<Device> foundDevices = new List<Device>();
                    if (fullStringCbx.Checked == true && caseSensCbx.Checked == true)
                    {
                        foundDevices = form1.detectedDevices.Where(device => device.IpAddress == searchTbx.Text || device.MacAddress == searchTbx.Text || device.DomainName == searchTbx.Text || device.Info == searchTbx.Text || device.FirstDetection == searchTbx.Text || device.LastDetection == searchTbx.Text || device.AdaptatorConstructor == searchTbx.Text).ToList();
                    }
                    else if (fullStringCbx.Checked == true && caseSensCbx.Checked == false)
                    {
                        foundDevices = form1.detectedDevices.Where(device => device.IpAddress.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.MacAddress.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.DomainName.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.Info.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.FirstDetection.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.LastDetection.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase) || device.AdaptatorConstructor.Equals(searchTbx.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                    else if (fullStringCbx.Checked == false && caseSensCbx.Checked == true)
                    {
                        foundDevices = form1.detectedDevices.Where(device => device.IpAddress.Contains(searchTbx.Text) || device.MacAddress.Contains(searchTbx.Text) || device.DomainName.Contains(searchTbx.Text) || device.Info.Contains(searchTbx.Text) || device.FirstDetection.Contains(searchTbx.Text) || device.LastDetection.Contains(searchTbx.Text) || device.AdaptatorConstructor.Contains(searchTbx.Text)).ToList();
                    }
                    else
                    {
                        foundDevices = form1.detectedDevices.Where(device => device.IpAddress.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.MacAddress.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.DomainName.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.Info.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.FirstDetection.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.LastDetection.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase) || device.AdaptatorConstructor.Contains(searchTbx.Text, StringComparison.InvariantCultureIgnoreCase)).ToList();
                    }

                    foreach (Device device in foundDevices)
                    {
                        int index = form1.detectedDevices.IndexOf(device);
                        form1.listView1.Items[index].BackColor = Color.Gainsboro;
                    }
                    this.Close();

                }
            }
            
        }
 
    }
}
