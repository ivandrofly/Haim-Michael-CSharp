using System;

namespace String.Equals_and____Operator
{
    internal class Program
    {
        private static void Main()
        {
            string a = "abc";
            string b = "Abc";
            // THIS
            Console.WriteLine("A == B => " + (a == b));
            Console.WriteLine("A.Equals(B) => " + (a.Equals(b, StringComparison.OrdinalIgnoreCase)));
        }

        private void StringJoin(string s)
        {
            string[] vec = { "blue", "red", "green" };

            string str = string.Join("...", vec);
            Console.WriteLine();
        }
    }
}