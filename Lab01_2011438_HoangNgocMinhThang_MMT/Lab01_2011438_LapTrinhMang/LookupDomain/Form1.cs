using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LookupDomain /* Bai 3 - Win Form */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string GetOcetOne(string[] ocet)
        {
            return ocet[1];
        }
        static string GetSubnetMask(string ipaddress)
        {
            int ip = int.Parse(ipaddress);
            if (ip >= 0 && ip <= 127)return "255.0.0.0";
            if (ip > 127 && ip <= 191)
            {
                return "255.255.0.0";
            }
            else{ return "255.255.255.0"; }
            return "";
        }
        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .FirstOrDefault();
        }
        public string GetHostInfomation(string host)
        {
            string information = "";
            try
            {
                System.Net.IPHostEntry hostInfo = Dns.GetHostEntry(host);
                information += hostInfo.HostName + '\n';
                Console.WriteLine("Dia Chi IP");
                string[] s;
                foreach (IPAddress item in hostInfo.AddressList)
                {
                    information += item.ToString() + '\n';
                    s = item.ToString().Split('.');
                    information += GetSubnetMask(GetOcetOne(s)) + '\n';
                    information += GetDefaultGateway().ToString() + '\n';
                }
            }
            catch (Exception){ Console.WriteLine($"Khong phan giai duoc ten mien {host} "); }
            return information;
        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            TextBox domain = sender as TextBox;
            Label information = new Label();
            information.Text += GetHostInfomation(domain.Text);
            information.Enabled = true;
            information.Width = 500;
            information.Height = 500;


            this.Controls.Add(information);
        }
    }
}
