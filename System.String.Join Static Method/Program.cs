using System;
using System.Text;

namespace System.String.Join_Static_Method
{
    class Program
    {
        static void Main()
        {
            string[] vec = { "bue", "red", "brown", "yellow", "white" };
            string str = string.Join("...", vec);
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
