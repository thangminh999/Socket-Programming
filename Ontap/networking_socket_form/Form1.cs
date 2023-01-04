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

namespace networking_socket_form
{
    public partial class frm_Server : Form
    {
        private byte[] Buff = new byte[10000];
        public Socket Server { get; set; }
        public List<Socket> Clients;
        public frm_Server()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            int port;
           
            if (int.TryParse(txt_Port.Text,out port))
            {
                IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Any, port);
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Bind(ipEndpoint);
                Server.Listen(-1);
                Thread tc = new Thread(acceptClients);
                tc.Start(Server);
                
                
                Clients = new List<Socket>();
                MessageBox.Show("Server Khởi tạo thành công");
            }
            else
            {
                MessageBox.Show(" Điền thông tin  hợp lệ");
            }
            
        }
        delegate void SetText(string message);
        private void  SetTextViewChat(string message)
        {
            if (txt_ViewChat.InvokeRequired)
            {
                SetText d = new SetText(SetTextViewChat);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                txt_ViewChat.Text += message+Environment.NewLine ;
            }
        }

        private void acceptClients(object sv)//server
        {
            Socket server = sv as Socket;
           
                while(true)
                {
                    Socket client = server.Accept();
                    SetTextViewChat(client.RemoteEndPoint.ToString());
                    Clients.Add(client);
                    Thread tc = new Thread(Receive);
                    tc.Start(client);
                    Thread check = new Thread(CheckConnect);
                    check.Start();
                }
            
          

        }
        public void Receive(object cl)//client
        {
            string message = string.Empty;
            Socket client = cl as Socket;
            int rec = 0;
            while ((rec=client.Receive(Buff,0,Buff.Length,SocketFlags.None))>0)
            {
                message = Encoding.ASCII.GetString(Buff, 0, rec);
                SetTextViewChat(message);
            }
        }
        private void btn_End_Click(object sender, EventArgs e)
        {
            if (Server is null)
            {
                MessageBox.Show("Kết thúc");
                
                return;
            }
            else
            {
                Server.Close();
                Clients.Clear();
                Server = null;
                Clients = null;
                
                MessageBox.Show("Kết thúc");

            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (Clients is null)
            {
                return;
            }
            string message = txt_Input.Text.Trim();
            byte[] buffSend = Encoding.ASCII.GetBytes(message);
            SetTextViewChat(message);
            
            foreach (Socket item in Clients)
            {
                
                if (item.Connected)
                {
                    item.Send(buffSend, 0, buffSend.Length,SocketFlags.None);
                }
            }
        }
        private void CheckConnect()
        {
            Flags:
                foreach (Socket item in Clients)
                {
                    if (!item.IsConnected())
                    {
                        SetTextViewChat($"disconnect from {item.RemoteEndPoint.ToString()} ");
                        Clients.Remove(item);
                        break;
                    }
                    
                }
            Thread.Sleep(5000);
            goto Flags;
           
        }
        
    }
    static class SocketExtensions
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
    }

}
