using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = null;

            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:1300/simpleserver/"); // will be listening to this url
                listener.Start();

                while (true)
                {
                    Console.WriteLine("Waiting...");
                    HttpListenerContext contenct = listener.GetContext(); // request connection...
                    string msg = "Hello";

                    contenct.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                    contenct.Response.StatusCode = (int)HttpStatusCode.OK;

                    using (Stream stream = contenct.Response.OutputStream)
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(msg);
                    }
                    Console.WriteLine("Msg sent...");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Status);
            }
        }
    }
}

// NOTE: once the server is up and running open the browser and enter the url address
// which is: http://localhost:1300/simpleserver/