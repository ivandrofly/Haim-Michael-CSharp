using System;
using System.Reflection;

namespace Dynamic_Binding
{
    internal class Program
    {
        private static void Main()
        {
            //BindingTrim();
            BindingEquals();

            System.Diagnostics.Debugger.Break();
            Type type = typeof(string);
            Type[] paramsTypes = { typeof(int) };
            MethodInfo method = type.GetMethod("Substring", paramsTypes);
            object[] args = { 4, 6 };
            string ob = "abcdefghijklmnop";
            object returnedVal = method.Invoke(ob, args);
            Console.WriteLine(returnedVal);
        }

        #region My Examples

        private static void BindingEquals()
        {
            MethodInfo methodInfo = typeof(int).GetMethod("Equals", new Type[] { typeof(int) });
            object returnType = methodInfo.Invoke(20, new object[] { 20 });
            Console.WriteLine(returnType);
        }

        private static void BindingTrim()
        {
            // Note:
            // if This line is throwing the "Ambiguous match found" exception:
            // var trimMethod = typeof(string).GetMethod("Trim");
            // http://tiny.cc/4ofnbx
            MethodInfo methodInfo = typeof(string).GetMethod("Trim", new Type[0]);
            Console.WriteLine(" ivandro ismael ");
            object result = methodInfo.Invoke(" ivandro ismael ", null);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        #endregion My Examples
    }
}