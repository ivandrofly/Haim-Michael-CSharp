using System;
using System.Threading;

namespace Threads_Local_Storage
{
    public class Yarkan
    {
        private string name;
        private string product;

        //static readonly object _syncObj = new object(); // better lock this object type
        public Yarkan(string nameVal, string productVal)
        {
            name = nameVal;
            product = productVal;
        }

        public void DoSomething()
        {
            Thread.SetData(Program.slot, name);
            for (int i = 0; i < 100; i += 10)
            {
                lock (Program.slot)
                {
                    Console.WriteLine(Thread.GetData(Program.slot) + " ==> " + product);
                    Thread.Sleep(500);
                }
            }
        }
    }

    internal class Program
    {
        public static LocalDataStoreSlot slot = Thread.GetNamedDataSlot("yarkan_name"); // yarkan_name is the local name for data slot

        private static void Main()
        {
            Thread t1 = new Thread(new Yarkan("david", "orange").DoSomething);
            t1.Start();
            Thread t2 = new Thread(new Yarkan("michael", "apple").DoSomething);
            t2.Start();
        }
    }
}