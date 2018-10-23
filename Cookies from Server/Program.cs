using System;
using System.Net;

namespace Cookies_from_Server
{
    class Program
    {
        static void Main()
        {
            try
            {
                CookieContainer container = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.bing.com");
                request.Proxy = null;
                request.CookieContainer = container;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    foreach (Cookie cookie in response.Cookies)
                    {
                        Console.WriteLine("Name = " + cookie.Name);
                        Console.WriteLine("Value = " + cookie.Value);
                        Console.WriteLine("Path = " + cookie.Path);
                        Console.WriteLine("Doamin = " + cookie.Domain);
                        Console.WriteLine();
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
