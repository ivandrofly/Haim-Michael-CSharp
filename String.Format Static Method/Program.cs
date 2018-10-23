using System;

namespace String.Format_Static_Method
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "I love playing {0} at {1} o'clock every {2} evening.";
            string formattedStr = string.Format(str, "space invader", 17, DateTime.Now.DayOfWeek);
            Console.WriteLine(formattedStr);
        }
    }
}