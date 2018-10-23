using System;
using System.Threading;

namespace Mutex_Demo
{
    internal class Program
    {
        private static Mutex mutex = new Mutex(true, "demo");

        private static void Main()
        {
            // In computer science, mutual exclusion refers to the requirement of
            // ensuring that no two concurrent processes[a] are in their critical section at the same time;

            // MUTEX single intance runing!
            // since WaitOne waits for signal if it doesn't recieve signal until the time is up it will return false
            if (!mutex.WaitOne(2000))
            {
                Console.WriteLine("Another instance of this application is already running...");
                Console.ReadLine();
            }
            else
            {
                try
                {
                    Run();
                }
                finally
                {
                    mutex.ReleaseMutex(); // allows the waiting instance to enter
                }
            }
        }

        private static void Run()
        {
            Console.WriteLine("Do something... Application is running...[Hit Enter to release mutex]");
            Console.ReadLine();
        }
    }
}
// Note: to run this you will need to execute from bin folder 2x