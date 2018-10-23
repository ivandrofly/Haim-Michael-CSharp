using System;
using System.Net;

namespace WebClient_Getting_HTTP_Headers
{
    class Program
    {
        static void Main()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Proxy = null;
                    //client.DownloadString("http://www.jacado.com");
                    // This will printout metadata
                    client.DownloadString("http://subscene.com/subtitles/the-walking-dead-fourth-season/english/867979");
                    Console.WriteLine(client.ResponseHeaders.ToString());
                    foreach (string name in client.ResponseHeaders.Keys)
                    {
                        Console.WriteLine(name + " = " + client.ResponseHeaders[name]);
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Status);
                }
            }
            Console.ReadLine();
        }
    }
}
