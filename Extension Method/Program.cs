using System;

namespace Extension_Method
{
    internal class Program
    {
        private static void Main()
        {
            Rectangle rec = new Rectangle(4, 3);
            Console.WriteLine(rec.Area());
            Console.WriteLine("ivandro ismael".ToUpperAll());
        }
    }

    public sealed class Rectangle
    {
        public double Width;
        public double Height;

        public Rectangle(double wVal, double hVal)
        {
            this.Width = wVal;
            this.Height = hVal;
        }
    }

    public static class RectanbleExtensionMethods
    {
        public static double Area(this Rectangle rec)
        {
            return rec.Width * rec.Height;
        }

        public static string ToUpperAll(this string s)
        {
            return s.ToUpper();
        }
    }
}