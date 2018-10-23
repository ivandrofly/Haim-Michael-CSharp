using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrapping_LINQ_Queries
{
    internal class Program
    {
        private static void Main()
        {
            string[] vec = { "ivandro", "ismael", "gomes jao", "sony" };
            IEnumerable<string> sequence = from str in
                                               (
                                                    from name in vec select name.ToUpper()
                                               )
                                           where str.Length > 4
                                           select str;
            foreach (var txt in sequence)
            {
                Console.WriteLine(txt);
            }
            Console.ReadLine();
        }
    }
}