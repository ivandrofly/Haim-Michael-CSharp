using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Typing
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic ob = null;
            String str = Console.ReadLine();
            switch (str)
            {
                case "dog":
                    ob = new Dog();
                    break;
                case "cat":
                    ob = new Cat();
                    break;
                case "cow":
                    ob = new Cow();
                    break;
            }
            Console.WriteLine(ob);
            Console.WriteLine("All done!");
            Console.ReadLine();
        }
    }
    class Cat
    {
        
    }

    class Cow
    {
        
    }

    class Dog
    {
        
    }
}
