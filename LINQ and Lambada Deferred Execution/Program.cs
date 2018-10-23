using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_and_Lambada_Deferred_Execution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] vec = { "ivandro", "ismael", "gomes", "jao" };
            var names = new List<string>();

            foreach (string strt in vec)
            {
                names.Add(strt);
            }

            // THIS WILL BE CALLED ONLY AT INTERACTION TIME
            var sequence = names.Where(n => n.Length > 5);
            names.Add("Programmer");
            foreach (string str in sequence)
            {
                // this will call the lambda before printing out
                Console.WriteLine(str);
            }
        }
    }
}