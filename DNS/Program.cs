using System;
using System.Net;

namespace DNS
{
    class Program
    {
        static void Main()
        {
            GetLocalComputers();
            string[] domains = { "www.google.com", "www.bing.com", "www.subscene.com", "www.facebook.com", "www.legendas.tv", "localhost" };
            foreach (string domain in domains)
            {
                Console.WriteLine("DNS: {0}", domain);

                foreach (IPAddress ip in Dns.GetHostAddresses(domain))
                {
                    Console.WriteLine(ip.ToString());
                }
                Console.WriteLine("=========================");
            }

            PingHost();
            Console.ReadLine(); // wait here
        }

        public static void PingHost()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            var result = ping.Send("81.2.199.57");

            Console.WriteLine("Computer hostname: {0}", Dns.GetHostName());
            Console.WriteLine(result.Status);
        }

        public static void GetLocalComputers()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            for (int i = 2; i <= 10; i++)
            {
                try
                {
                    var r = ping.Send("192.168.1." + i.ToString());
                    var s  = Dns.GetHostEntry("192.168.1." + i.ToString());
                    Console.WriteLine(s.HostName);
                    Console.WriteLine(r.Buffer.Length);
                    Console.WriteLine(r.Status);
                }
                catch { }
            }
        }
    }
}
