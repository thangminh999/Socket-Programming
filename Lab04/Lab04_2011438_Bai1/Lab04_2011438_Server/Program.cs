using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace Lab04_2011438_Server
{
    class Program
    {
        private static void Main()
        {
            var listener = new TcpListener(IPAddress.Any, 1308);
            listener.Start(10);
            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream) { AutoFlush = true };
                var text = reader.ReadLine();
                var response = text.ToUpper();
                writer.WriteLine(response);
                client.Close();
            }

        }
    }
}
