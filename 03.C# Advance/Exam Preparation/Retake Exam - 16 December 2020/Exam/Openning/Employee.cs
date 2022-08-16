using System;
using System.Collections.Generic;
using System.Text;

namespace Openning
{
    public class Employee
    {
        private string name;
        private int age;
        private string country;

        public Employee(string name, int age, string capacity)
        {
            Name = name;
            Age = age;
            Country = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                age = value;
            }
        }
        public string Country
        {
            get => country;
            private set
            {
                country = value;
            }
        }

        public override string ToString()
        {
            return $"Employee: {Name}, {Age}, ({Country})";
        }
    }
}
