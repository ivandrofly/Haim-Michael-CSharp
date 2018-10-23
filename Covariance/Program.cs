using System;

namespace Covariance
{
    class Program
    {
        public delegate Shape GetShape();
        public static Rectangle GetRectangle()
        {
            return new Rectangle();
        }
        public static Circle GetCircle()
        {
            return new Circle();
        }

        static void Main()
        {
            GetShape getCircleMethod = GetCircle;
            GetShape getRectangleMethod = GetRectangle;
            Console.WriteLine(getCircleMethod());
            Console.WriteLine(getRectangleMethod());

        }
    }

    class Shape { }
    class Circle : Shape
    {
        public override string ToString()
        {
            return "I'm a Circle";
        }
    }
    class Rectangle : Shape
    {
        public override string ToString()
        {
            return "I'm a Shape";
        }
    }
}
