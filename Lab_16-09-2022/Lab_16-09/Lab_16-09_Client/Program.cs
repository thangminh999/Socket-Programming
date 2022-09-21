using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_16_09_Client
{
    internal class Program
    {
        static void Main(string[] args)//client
        {
            IPEndPoint ServerEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(ServerEndpoint);

            if (serverSocket.Connected)
            {
                while (true)
                {
                    string data = Console.ReadLine();
                    byte[] dataSize = ASCIIEncoding.UTF8.GetBytes(data);
                    int sent = SendData(serverSocket, dataSize);

                }
            }
            Console.ReadKey();
        }
        public static int SendData(Socket s, byte[] buff)
        {
            int total = 0;
            int size = buff.Length;
            int dataleft = size;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            int sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(buff, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }
        public static byte[] ReceiveData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(datasize, 0);
            int datalef = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = s.Receive(data, total, datalef, SocketFlags.None);
                total += recv;
                datalef -= recv;
            }
            return data;
        }
    }
}
