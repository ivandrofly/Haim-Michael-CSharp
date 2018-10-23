using System;
using System.Threading;

namespace Semaphore_Demo
{
    internal class Program
    {
        private static readonly object _syncObject = new object();
        private static Semaphore semaphore = new Semaphore(1, 3);

        private static void DoSomething(object id)
        {
            WriteYellowLine("{0} wants to access the semaphore", id);
            semaphore.WaitOne();
            WriteGreenLine("{0} as successed to access the semaphore", id);
            Thread.Sleep(2000);
            WriteRedLine("{0} is about to leave the smeaphore", id);
            semaphore.Release();

            // NOTE:
            // http://tiny.cc/mz0hbx
        }

        private static void WriteGreenLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine(format, arg);
            }
        }

        /// <summary>
        /// This method will prevent multi-access thread by locking the readonly _syncObject
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        private static void WriteLine(string format, object arg)
        {
            Console.WriteLine(format, arg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteRedLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine(format, arg);
            }
        }

        private static void WriteYellowLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine(format, arg);
            }
        }

        private static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoSomething).Start(i);
            }
            Console.Read();
        }
    }
}