using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebClient_Submission_Form
{
    class Program
    {
        static void Main()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    System.Collections.Specialized.NameValueCollection collection =
                        new System.Collections.Specialized.NameValueCollection();
                    collection.Add("numA", "43");
                    collection.Add("numB", "32");
                    client.Proxy = null;
                    // http://www.abelski.com/courses/csharps/sumform.php
                    // http://www.lifemichael.com/
                    byte[] result = client.UploadValues("http://www.subscene.com", "POST", collection);
                    System.IO.File.WriteAllBytes("results.html", result);
                    System.Diagnostics.Process.Start("results.html");
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Status);
                }
            }
        }
    }
}
