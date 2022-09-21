using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Lab04_2011438
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee empl = new Employee();
            empl.EmployeeID = 1;
            empl.LastName = "Nguyen";
            empl.FirstName = "Van A";
            empl.YearsService = 12;
            empl.Salary = 3500000;

            TcpClient client;
            try{ client = new TcpClient("127.0.0.1", 9050); }
            catch(SocketException)
            {
                Console.WriteLine("ERROR ! Khong the ket noi voi Server");
                return;
            }

            NetworkStream ns = client.GetStream();
            byte[] data = empl.GetBytes();
            int size = empl.size;
            byte[] packsize = new byte[2];
            Console.WriteLine("Kich thuoc goi tin = {0}", size);
            packsize = BitConverter.GetBytes(size);
            ns.Write(packsize, 0, 2);
            ns.Write(data, 0, size);
            ns.Flush();
            //
            ns.Close();
            client.Close();
        }
    }
}
