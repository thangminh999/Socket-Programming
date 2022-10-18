using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace Lab06
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        static byte[] buff = new byte[1048];
        static List<TcpClient> clients = new List<TcpClient>();
        static TcpListener server = new TcpListener(IPAddress.Any, 8000);
        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            Button a = new Button();
            this.Controls.Add(a);
            Thread thread1 = new Thread(acceptClient);
            thread1.Start();
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
        private void SetText1(string text)
        {
        
            if (this.txtViewMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtStatus.Text += text;
            }
        }
        public void acceptClient()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                string clientIPAddress = "Dia chi IP cua ban la: " + IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())+ " Port :"+IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString()); 

                SetText1(clientIPAddress);
                Thread thread1 = new Thread(recvie);
                thread1.Start(client);
            }


        }
        public void recvie(object clients)
        {
            TcpClient client = clients as TcpClient;
            NetworkStream ns = client.GetStream();
            int rec;
            string data = string.Empty;

            while ((rec = ns.Read(buff, 0, buff.Length)) > 0)
            {
                data = ASCIIEncoding.UTF8.GetString(buff, 0, rec);

                SetText(data + Environment.NewLine);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();
        }
    }
}
