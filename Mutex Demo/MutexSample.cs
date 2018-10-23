﻿using System;
using System.Threading;

class Program
{
    static Mutex _m;
    // NOTE: THIS CODE WAS DOWNLOADED FROM: http://www.dotnetperls.com/mutex
    static bool IsSingleInstance()
    {
        try
        {
            // Try to open existing mutex.
            Mutex.OpenExisting("PERL");
        }
        catch
        {
            // If exception occurred, there is no such mutex.
            Program._m = new Mutex(true, "PERL");

            // Only one instance.
            return true;
        }
        // More than one instance.
        return false;
    }

    static void Main2()
    {
        if (!Program.IsSingleInstance())
        {
            Console.WriteLine("More than one instance"); // Exit program.
        }
        else
        {
            Console.WriteLine("One instance"); // Continue with program.
        }
        // Stay open.
        Console.ReadLine();
    }
}