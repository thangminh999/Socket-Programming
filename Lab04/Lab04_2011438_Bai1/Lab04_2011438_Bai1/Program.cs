using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Lab04_2011438_Bai1
{
    class Program
    {
        private static void Main()
        {
            Console.Write("IP Address: ");
            var ip = IPAddress.Parse(Console.ReadLine());
            while (true)
            {
                Console.Write("#Log >>> ");
                var text = Console.ReadLine();
                var client = new TcpClient();
                client.Connect(ip, 1308);
                var stream = client.GetStream();
                var writer = new StreamWriter(stream) { AutoFlush = true };
                var reader = new StreamReader(stream);
                writer.WriteLine(text);
                var response = reader.ReadLine();
                //
                client.Close();
                Console.WriteLine(response);
            }

        }
    }
}
