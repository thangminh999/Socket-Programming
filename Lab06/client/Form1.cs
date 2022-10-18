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
using System.Net.Sockets;
using System.Threading;
namespace client
{
    public partial class Form1 : Form
    {
        static byte[] buff = new byte[1048];
        TcpClient client = new TcpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect(IPAddress.Loopback, 8000);
                Button a = new Button();
                this.Controls.Add(a);
                if (client.Connected)
                {
                    Thread thread1 = new Thread(recvie);
                    thread1.Start();
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtViewMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtViewMessage.Text += text;
            }
        }
        public void recvie()
        {
            NetworkStream ns = client.GetStream();
            string data = string.Empty;
            int rec;
            while ((rec = ns.Read(buff, 0, buff.Length)) > 0)
            {
                data = ASCIIEncoding.UTF8.GetString(buff, 0, rec);
                SetText(data + Environment.NewLine);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream ns = client.GetStream();
            byte[] buff = ASCIIEncoding.UTF8.GetBytes(txtEnter.Text);
            ns.Write(buff, 0, buff.Length);
            txtViewMessage.Text += txtEnter.Text + Environment.NewLine;
        }
    }
}
