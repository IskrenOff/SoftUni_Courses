using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] persons = Console.ReadLine().Split(' ');

                string personName = persons[0];
                int personAge = int.Parse(persons[1]);

                Person person = new Person(personName, personAge);

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}
