using System;

namespace Factory_Adv_Ex
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }    

    }

    public class PersonFactory
    {
        private int id = 0;

        public Person CreatePerson(string name)
        {
            return new Person{ Id = id++, Name=name };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
