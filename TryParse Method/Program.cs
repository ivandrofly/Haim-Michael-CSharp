using System;

namespace TryParse_Method
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int num;
            string strA = "23%";
            string strB = "45";
            bool succeeded;

            succeeded = int.TryParse(strA, out num);
            if (succeeded)
            {
                Console.WriteLine("Paraing strA succeeded! the value of num is: " + num);
            }
            else
            {
                Console.WriteLine("parsin strB failed!");
            }

            succeeded = int.TryParse(strB, out num);
            if (succeeded)
            {
                Console.WriteLine("parsing strB succeeded! the value of num is: " + num);
            }
            else
            {
                Console.WriteLine("Parsing strB failed!");
            }
        }
    }
}