using System;

namespace Delegates_Covariance
{
    internal class Program
    {
        private delegate Shape GetShape();

        public static Rectangle GetRectangle()
        {
            return new Rectangle();
        }

        public static Circle GetCircle()
        {
            return new Circle();
        }

        private static void Main()
        {
            GetShape getCircleMethod = GetCircle;
            GetShape getRectangleMethod = GetRectangle;
            Console.WriteLine(getCircleMethod());
            Console.WriteLine(getRectangleMethod.Invoke());
        }
    }

    public class Shape { }

    public class Rectangle : Shape
    {
        public override string ToString()
        {
            return "I'm Circle";
        }
    }

    public class Circle : Shape
    {
        public override string ToString()
        {
            return "I'm Rectangle";
        }
    }
}