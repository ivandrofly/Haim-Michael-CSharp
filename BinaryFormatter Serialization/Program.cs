using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BinaryFormatter_Serialization
{
    class Program
    {
        static void Main()
        {
            Person person = new Person("Haim", 123123);
            IFormatter binaryFormatter = new BinaryFormatter();

            // Serialiing
            using (FileStream stream = File.Create("personal.data"))
            {
                binaryFormatter.Serialize(stream, person);
            }

            // Deserializing
            using (FileStream stream = File.OpenRead("personal.data"))
            {
                Person objPerson = (Person)binaryFormatter.Deserialize(stream);
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }
    }

    [Serializable]
    class Person
    {
        private string name;
        private int id;

        public Person(string nameVal, int idVal)
        {
            this.name = nameVal;
            this.id = idVal;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, ID: {1}", name, id);
        }
    }
}
