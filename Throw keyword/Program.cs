using System;

namespace Throw_keyword
{
    internal class Program
    {
        public static double Compute(double a, double b)
        {
            if (b == 0)
                throw new NoneZeroArgumentException();
            return a / b;
        }

        private static void Main()
        {
            try
            {
                double c = 0;
                c = Compute(4, 3);
                Console.WriteLine(c);

                c = Compute(5, 0);
                Console.WriteLine(c);
            }
            catch (NoneZeroArgumentException)
            {
                Console.WriteLine("Can't devide by zero!");
            }
            Console.ReadLine();
        }
    }

    public class NoneZeroArgumentException : ApplicationException
    {
    }
}