using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace Lab01_2011438_LapTrinhMang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtDomain_DoubleClick(object sender, EventArgs e)
        {
            TextBox domain = sender as TextBox;
            Label information = new Label();
            information.Text += Lab01_2011438_LapTrinhMang.Program.GetHostInfomation(domain.Text);
            this.Controls.Add(information);
        }
    }
}
