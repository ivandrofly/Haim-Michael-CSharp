using System;
using System.Globalization;

namespace Format_Provider
{
    class Program
    {
        static void Main()
        {
            NumberFormatInfo formatter = new NumberFormatInfo();
            formatter.CurrencySymbol = "ILS"; // this change the Current currency symbol to ILS
            Console.WriteLine(3.ToString("C", formatter));
            Console.ReadLine();  // wait here
        }
    }
}
