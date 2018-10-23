using System;
using System.Threading;

namespace Foreground_and_Background_Threads
{
    class Program
    {
        static readonly object _syncObj = new object();
        static void Main()
        {
            Thread t1 = new Thread(WriteBanana);
            Thread t2 = new Thread(WriteOrange);

            t1.IsBackground = true; // this threas will die since the main thread quits!
            t2.IsBackground = false; // this will keep running!
            t1.Start();
            t2.Start();
        }

        private static void WriteOrange()
        {
            for (int i = 0; i < 800; i++)
            {
                Console.WriteLine("\n[BANANA: " + i + "]");
                Thread.Sleep(2000);
            }
        }

        private static void WriteBanana()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("\n[ORANGE: " + i + "]");
                Thread.Sleep(1500);
            }
        }

        private static void WriteGreen(string format, string arg)
        {
            lock (_syncObj)
            {
                Console.WriteLine(format, arg);
            }
        }

        private static void WriteYellow(string format, string arg)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(format, arg);
            }
        }
    }
}
