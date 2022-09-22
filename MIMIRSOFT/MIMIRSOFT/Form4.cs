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
    public partial class packetSearchForm : Form
    {
        private Form1 form1;
        public packetSearchForm(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
        }

        private void packetSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
