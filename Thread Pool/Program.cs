using System;
using System.Threading;

namespace Thread_Pool
{
    class Program
    {
        static ConsoleColor defaultColor;
        static void Main()
        {
            // Note: these threads will be executed lin queue
            ThreadPool.QueueUserWorkItem(WriteBanana); // #1
            ThreadPool.QueueUserWorkItem(WriteOrange); // #2
            defaultColor = Console.ForegroundColor;
            Console.ReadLine();
        }

        static void WriteBanana(object ob)
        {
            //System.Diagnostics.Debugger.Break();
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[Banana " + Thread.CurrentThread.Name + "]");
                Console.ForegroundColor = defaultColor;
                Thread.Sleep(100);
            }
        }

        static void WriteOrange(object ob)
        {
            //System.Diagnostics.Debugger.Break();
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n(Orange " + Thread.CurrentThread.Name + ")");
                Console.ForegroundColor = defaultColor;
                Thread.Sleep(100);
            }
        }
    }
}
