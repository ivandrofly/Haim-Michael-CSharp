using System;

namespace Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(3, 4);
            Console.WriteLine(rec.Area());
        }
    }


    public sealed class Rectangle
    {

        public double Width;
        public double Height;

        public Rectangle(double wVal, double hval)
        {
            this.Height = hval;
            this.Width = wVal;
        }
    }

    public static class RectangleExtensionMethods
    {

        public static double Area(this Rectangle rect)
        {
            return rect.Width * rect.Height;
        }
    }
}
