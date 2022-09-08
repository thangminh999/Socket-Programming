using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] buff = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string welcome = "Hello server";
            buff = Encoding.ASCII.GetBytes(welcome);
            serverSocket.SendTo(buff, buff.Length, SocketFlags.None, ipep);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;
            buff = new byte[1024];
            int recv = serverSocket.ReceiveFrom(buff, ref Remote);
            Console.WriteLine("Dang goi cau chao len Server...", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(buff, 0, recv));
            //
            string input, stringData;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                serverSocket.SendTo(Encoding.ASCII.GetBytes(input), Remote);
                buff = new byte[1024];
                recv = serverSocket.ReceiveFrom(buff, ref Remote);
                stringData = Encoding.ASCII.GetString(buff, 0, recv); Console.WriteLine(stringData);
            }
            Console.WriteLine("Dang dong client");
            Console.ReadLine();
            //
            serverSocket.Close();
        }
    }
}
