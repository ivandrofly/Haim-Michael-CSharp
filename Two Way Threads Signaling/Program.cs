using System;
using System.Threading;

namespace Two_Way_Threads_Signaling
{
    internal class Program
    {
        private static EventWaitHandle handleA = new AutoResetEvent(false);
        private static EventWaitHandle handleB = new AutoResetEvent(false);
        private static volatile string message; // valatile indicate that the variable is being accessed by multiple threads

        private static void Main(string[] args)
        {
            new Thread(DoSomething).Start();

            handleA.WaitOne(); // wait till DoSomething is ready to reply
            message = "Hello";
            handleB.Set(); // Indicate DoSomething it can proceed

            handleA.WaitOne();// wait till DoSomething is ready to reply
            message = "Goo morning";
            handleB.Set();

            handleA.WaitOne();  // wait till DoSomething is ready to reply
            message = "How are you";
            handleB.Set();

            handleA.WaitOne(); // wait till DoSomething is ready to reply
            message = "Exit";
            handleB.Set();
        }

        private static void DoSomething()
        {
            while (true)
            {
                handleA.Set(); // indicate DoSomething is ready
                handleB.WaitOne(); // wait for getting a message
                if (message == "exit")
                    return;
                Console.WriteLine("message received is " + message);
            }
        }
    }
}