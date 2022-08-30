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
    public partial class deviceDetailForm : Form
    {
        public deviceDetailForm()
        {
            InitializeComponent();
            
            ipAdressTbx.Text = Form1.deviceDetails.IpAddress;
            macAddressTbx.Text = Form1.deviceDetails.MacAddress;
            dvcNameTbx.Text = Form1.deviceDetails.DomainName;
            dvcInfoTbx.Text = Form1.deviceDetails.Info;
            dvcConstructorTbx.Text = Form1.deviceDetails.AdaptatorConstructor;
            fDetectionTbx.Text = Form1.deviceDetails.FirstDetection;
            lDetectionTbx.Text = Form1.deviceDetails.LastDetection;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
