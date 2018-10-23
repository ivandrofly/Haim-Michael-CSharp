using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_PadLeft_and_PadRight
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Ivan";
            Console.WriteLine("..." + str.PadLeft(12, '#') + "...");
            Console.WriteLine("..." + str.PadRight(12, '#') + "...");

            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("Left << " + "ivandro".PadLeft(10) + " >> Right");
            Console.WriteLine("Left << " + "ivandro".PadRight(10) + " >> Right");

            Console.ReadLine();
        }
    }
}
