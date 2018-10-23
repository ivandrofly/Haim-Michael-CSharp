using System;
using System.Threading;

namespace Semaphore_Constructor
{
    class Program
    {
        private static readonly object _syncObj = new object();
        static Semaphore semaphore;

        static void Main()
        {
            Thread t1 = new Thread(QuaQua);
            Thread t2 = new Thread(QuaQua);
            Thread t3 = new Thread(QuaQua);
            Thread t4 = new Thread(QuaQua);
            Thread t5 = new Thread(QuaQua);
            Thread t6 = new Thread(QuaQua);
            semaphore = new Semaphore(2, 5); // allow 2 threads to enters
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            Thread.Sleep(10000);
            // Two more thread will join the quaqua once the main thread run these two lines
            /*semaphore.Release();
            semaphore.Release();*/
        }

        private static void QuaQua()
        {
            WriteYellow();
            semaphore.WaitOne();
            WriteGreen();
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(1000);
                WriteBlue(i);
            }
            semaphore.Release();
        }

        private static void WriteBlue(object count)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Quaqua (thread id: " + Thread.CurrentThread.GetHashCode() + ") " + count);
            }
        }

        private static void WriteGreen()
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString() + " Has Entered");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void WriteYellow()
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Waiting... " + Thread.CurrentThread.ManagedThreadId);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
