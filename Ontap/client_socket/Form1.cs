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

namespace client_socket
{
    public partial class Form1 : Form
    {
        private byte[] Buff = new byte[10000];
        private Socket Server { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
        delegate void SetText(string message);
        private void SetTextViewChat(string message)
        {
            if (txt_ViewChat.InvokeRequired)
            {
                SetText d = new SetText(SetTextViewChat);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                txt_ViewChat.Text += message +Environment.NewLine;
            }
        }
        public void Receive(object cl)//client
        {
            string message = string.Empty;
            Socket client = cl as Socket;
            int rec = 0;
            while ((rec = client.Receive(Buff, 0, Buff.Length, SocketFlags.None)) > 0)
            {
                message = Encoding.ASCII.GetString(Buff, 0, rec);
                SetTextViewChat(message );
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txt_Port.Text);
            IPEndPoint epEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Connect(epEndpoint);
            if (Server.Connected)
            {
                MessageBox.Show("Kết nối thành công");
                Thread tc = new Thread(Receive);
                tc.Start(Server);
            }
            else
            {
                MessageBox.Show("kết nối không thành công");

            }
            
            
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            SetTextViewChat(txt_Input.Text);
            byte[] sendbuff = Encoding.ASCII.GetBytes(txt_Input.Text);
            
            Server.Send(sendbuff, 0, sendbuff.Length, SocketFlags.None);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.Close();
        }
    }
}
