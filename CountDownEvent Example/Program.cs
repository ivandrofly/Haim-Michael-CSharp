using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CountDownEvent_Example
{
    class Program
    {
        static CountdownEvent counter = new CountdownEvent(2);
        static void Main()
        {
            new Thread(Say).Start("Shalom");
            new Thread(Say).Start("Shalom");
            counter.Wait();
            Console.WriteLine("end");
        }

        private static void Say(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(obj);
            }
            counter.Signal();
        }
    }
}
