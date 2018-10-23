using System;
using System.IO;
using System.Net;

namespace WebClient_Demo
{
    class Program
    {
        static void Main()
        {
            using (WebClient web = new WebClient())
            {
                // Note: thr.pdf will ce save in save directory
                web.DownloadFile("http://www.abelski.com/courses/csharp/intruduction.pdf", "thr.pdf");
                if (File.Exists("thr.pdf"))
                    System.Diagnostics.Process.Start("thr.pdf");
                else
                    Console.WriteLine("File not found!");
            }
        }
    }
}
