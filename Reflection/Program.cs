using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(string);
            MemberInfo[] vec = type.GetMembers();
            foreach (MemberInfo info in vec)
            {
                Console.WriteLine(info);
            }
        }
    }
}
