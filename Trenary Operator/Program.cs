using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trenary_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numA = 12, numB = 15;
            int numC = (numA > numB) ? numA : numB;
            Console.WriteLine("The greater number is: {0}, between {1} and {2}", numC, numA, numB);
            Console.ReadLine();
        }
    }
}
