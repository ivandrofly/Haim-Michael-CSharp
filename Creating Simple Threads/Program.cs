using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Creating_Simple_Threads
{
    class Program
    {
        static void Main()
        {
            Thread thread1 = new Thread(WriteOrange);
            Thread thread2 = new Thread(WriteOrange);
            thread1.Start();
            thread2.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Carmel");
            }
            Console.WriteLine();
        }

        static void WriteBanana()
        {
            //System.Diagnostics.Debugger.Break();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Banana");
            }
        }

        static void WriteOrange()
        {
            //System.Diagnostics.Debugger.Break();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Tapuz");
            }
        }
    }
}

