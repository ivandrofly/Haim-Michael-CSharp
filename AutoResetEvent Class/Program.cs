using System;
using System.Threading;

namespace AutoResetEvent_Class
{
    internal class Program
    {
        private static EventWaitHandle handle = new AutoResetEvent(false);

        private static void Main()
        {
            // note: with 'Set()' in ManualResetEvent it releases all the blocked thread
            // when you are using the AutoResetEvent for every WaitOne() you have to use Set() to release a single thread
            new Thread(SayHello).Start("Holla");
            new Thread(SayHello).Start("hello");
            new Thread(SayHello).Start("hi");
            Thread.Sleep(2000);
            handle.Set(); // release first thread
            Thread.Sleep(2000);
            handle.Set(); // release second thread
            Thread.Sleep(2000);
            handle.Set(); // release third thread
            Console.ReadLine(); // wait here!
        }

        private static void SayHello(object obj)
        {
            Console.WriteLine("Inside Sayhello data: " + obj);
            handle.WaitOne(); // block the thread
            Console.WriteLine(obj);
        }
    }
}