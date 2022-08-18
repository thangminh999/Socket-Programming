using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_2011438_LapTrinhMang
{
    class Program /*  Bai 1 - 2  */
    {
        static void Main(string[] args)
        {
            Console.WriteLine($" {GetDefaultGateway().ToString()}");
            string[] domain = { "www.google.com", "www.youtube.com", "www.dlu.edu.vn", "www.ovh.com", "www.vietnix.vn" };
            foreach (string item in domain)
            {
                Console.WriteLine($"Phan giai ten mien {item}");
                GetHostInfo(item);
            }
            Console.Read();
        }
        static string GetOcetOne(string[] ocet)
        {
            return ocet[0];
        }
        static string GetSubnetMask(string ipaddress)
        {
            int ip = int.Parse(ipaddress);
            if (ip >= 0 && ip <= 127) return "255.0.0.0";
            if (ip > 127 && ip <= 191)
            {
                return "255.255.0.0";
            }
            else{ return "255.255.255.0"; }
            return "";
        }
        static void GetHostInfo(string host)
        {
            try
            {
                System.Net.IPHostEntry hostInfo = Dns.GetHostEntry(host);
                Console.WriteLine($"Ten mien {hostInfo.HostName}");
                Console.WriteLine("Dia Chi IP");
                string[] s;
                foreach (IPAddress item in hostInfo.AddressList)
                {
                    Console.WriteLine(item.ToString());
                    s = item.ToString().Split('.');
                    Console.WriteLine($"dia chi subnetmask {GetSubnetMask(GetOcetOne(s))}");
                    GetDefaultGateway();
                }
            }
            catch (Exception){ Console.WriteLine($"Khong phan giai duoc ten mien {host} "); }
        }
        public static string GetHostInfomation(string host)
        {
            string information = "";
            try
            {
                System.Net.IPHostEntry hostInfo = Dns.GetHostEntry(host);
                information += hostInfo.HostName + '\n';
                Console.WriteLine("Dia Chi IP");
                string[] s;
                foreach (IPAddress item in hostInfo.AddressList)
                {
                    information += item.ToString() + '\n';
                    s = item.ToString().Split('.');
                    information += GetSubnetMask(GetOcetOne(s)) + '\n';
                    information += GetDefaultGateway().ToString() + '\n';
                }
            }
            catch (Exception){ Console.WriteLine($"Khong phan giai duoc ten mien {host} "); }
            return information;
        }
        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }
    }
}
