using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] buff = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(ipep);
            Console.WriteLine("Dang cho Client ket noi den...");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = serverSocket.ReceiveFrom(buff, ref Remote);
            Console.WriteLine("Da ket noi voi client: {0}", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(buff, 0, recv));
            string welcome = "Da goi cau chao len Server...";
            buff = Encoding.ASCII.GetBytes(welcome);
            serverSocket.SendTo(buff, buff.Length, SocketFlags.None, Remote);
            //
            while (true)
            {
                buff = new byte[1024];
                recv = serverSocket.ReceiveFrom(buff, ref Remote);
                Console.WriteLine(Encoding.ASCII.GetString(buff, 0, recv));
                serverSocket.SendTo(buff, recv, SocketFlags.None, Remote);
            }
        }
    }
}
