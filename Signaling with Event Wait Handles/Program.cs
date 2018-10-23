using System;
using System.Threading;

namespace Signaling_with_Event_Wait_Handles
{
    internal class Program
    {
        private static EventWaitHandle handle = new ManualResetEvent(false);

        private static void Main()
        {
            // note: with 'Set()' in manualresetevent all the blocked thread will be released
            // when you are using the autoresetevent for every waitone you have to use set()

            //handle.Set(); // all these 1 group thread won't wait in SayHello WaitOne() Method!
            new Thread(SayHello).Start("Holla");
            new Thread(SayHello).Start("Hello");
            new Thread(SayHello).Start("Hi");
            new Thread(SayHello).Start("Hey");
            new Thread(SayHello).Start("Ivandro");
            new Thread(SayHello).Start("Ismael");
            new Thread(SayHello).Start("Gomes Jao");

            Console.WriteLine("Thread is sleeping... for 2.0 secs");
            handle.Set(); // release all threads waiting in WaitOne();
            Thread.Sleep(100);
            handle.Reset(); // this will make the WaitOne() to block all upcoming thread!
            new Thread(SayHello).Start("bonjour!");
            Thread.Sleep(4000 * 2);
            handle.Set();

            Console.WriteLine("Main Thread is leaving!");
            Console.ReadLine(); // wait here!
        }

        private static void SayHello(object obj)
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId); // better lock this with a static obj
            Console.WriteLine("Sayhello() data: " + obj);
            handle.WaitOne(); // block the thread
            Console.WriteLine(obj);
        }
    }
}