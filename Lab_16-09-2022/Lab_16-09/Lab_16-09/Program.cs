using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_16_09
{
    internal class Program
    {
        static void Main(string[] args)//Server 
        {
            string data = "";
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);
            Socket clientSocket = serverSocket.Accept();
            while (true)
            {
                data = ASCIIEncoding.UTF8.GetString(ReceiveData(clientSocket));
                Console.WriteLine(Process(data));
            }
            Console.ReadKey();

        }
        public static string Process(string data)//78 + 9
        {
            int result = 0;
            int number1, number2;
            string[] listText = data.Trim().Split(' ');
            if (listText.Length <= 0)
            {
                return "#############";
            }
            else
            {

                if (!int.TryParse(listText[0], out number1) || !int.TryParse(listText[2], out number2))
                {
                    return "vui long nhap Khong hop le";
                }
                switch (listText[1])
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
                    case "*":
                        result = number1 * number2;
                        break;
                    case "/":
                        result = number1 / number2;
                        break;
                    default:
                        result = -1;
                        break;
                }
            }
            return result.ToString();
        }
        public int SendData(Socket s, byte[] buff)
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
