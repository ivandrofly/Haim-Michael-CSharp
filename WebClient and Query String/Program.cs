using System;
using System.Net;

namespace WebClient_and_Query_String
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Proxy = null;
                    client.QueryString.Add("productId", "207573");
                    client.QueryString.Add("productId", "2216");
                    client.QueryString.Add("productId", "500");
                    client.QueryString.Add("productId", "20");
                    client.DownloadFile("http://handango.com/catalog/productDetails.jsp", "classicroulette.html");
                    System.Diagnostics.Process.Start("classicroulette.html");
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Status);
                }
            }
            Console.ReadLine();
        }
    }
}
