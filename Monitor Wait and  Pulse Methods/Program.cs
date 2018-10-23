using System;
using System.Collections.Generic;
using System.Threading;

namespace Monitor_Wait_and__Pulse_Methods
{
    internal class Program
    {
        private static object locker = new object();
        private static Queue<int> numbers = new Queue<int>();
        private static int[] vec = { 12, 123, 512, 21, 535, 6, 3, 7464, 233, 4, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static void Read()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                lock (locker)
                {
                    while (numbers.Count == 0)
                    {
                        WriteYellow("Waiting for signal...");
                        Monitor.Wait(locker); // await for Monitor.Pluse() and release the lock(locker) to allow another thread to enter
                    }
                    WriteRed(numbers.Dequeue());
                }
                Thread.Sleep(1000);
            }
        }

        public static void Write()
        {
            for (int i = 0; i < vec.Length; i++)
            {
                lock (locker)
                {
                    // if i == vec.Length print out empty repository
                    numbers.Enqueue(vec[i]);
                    WriteGreen("Sending signal...");
                    Monitor.Pulse(locker); // notify the waiting thread to change the states
                }
                Thread.Sleep(2000);
            }
        }

        private static void Main()
        {
            Console.Title = "Monitor - Wait & Pulse";
            new Thread(Write).Start();
            new Thread(Read).Start();

            Console.ReadLine();
        }

        #region WritColoredLine

        private static readonly object _syncObj = new object();

        private static void WriteGreen(string format)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(format);
            }
        }

        private static void WriteRed(object format)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(format);
            }
        }

        private static void WriteYellow(string format)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(format);
            }
        }

        #endregion WritColoredLine
    }
}