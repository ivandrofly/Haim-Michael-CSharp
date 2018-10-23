using System;
using System.Threading;

namespace Timer_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback SayGoodBye = (obj) => Console.WriteLine(obj);
            TimerCallback saySomething = delegate(object obj) { Console.WriteLine(obj); };

            Timer timer = new Timer(SayHello, "Timer 1: ", 2000, 800);
            Timer timer2 = new Timer((obj) => Console.WriteLine(obj), "ISMAEL", 2000, 800);
            Timer timer3 = new Timer(SayHello, "ivandro", 2000, 800);
            Console.ReadLine();
            timer.Dispose();
            timer2.Dispose();
            timer2.Dispose();
        }

        private static void SayHello(object state)
        {
            Console.WriteLine(state);
        }
    }
}
