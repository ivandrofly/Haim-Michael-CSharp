using System;

namespace Named_Parameters
{
    class Program
    {
        static void Main()
        {
            Person ob = new Person();
            ob.SetData(idVal: 12341234, nameVal: "Ismael");
            ob.SetData(23, "ivandro");
            Console.WriteLine(ob.ToString());
        }
    }

    class Person
    {
        private bool male;
        private long id;
        private string name;
        private string occupation;

        public void SetData(long idVal, string nameVal, bool maleVal = true, string occupationVal = "Student")
        {
            id = idVal;
            name = nameVal;
            male = maleVal;
            occupation = occupationVal;
        }
        public override string ToString()
        {
            return name + ", " + occupation + ", " + id + ", " + (male ? "Male" : "Female");
        }
    }
}
