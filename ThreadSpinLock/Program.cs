﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSpinLock
{
    class Program
    {
        static void Main(string[] args)
        {
            SpinLockDemo.SpinLockSample1();

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
