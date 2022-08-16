using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        private string name;
        private int capacity;


        public Bakery(string name, int capacity)
        {
            data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.Find(x => x.Name == name));
        }

        public Employee GetOldestEmployee()
        {
            int oldestEmployee = data.Select(x => x.Age).Max();
            return data.Find(e => e.Age == oldestEmployee);
        }

        public Employee GetEmployee(string name)
        {
            return data.Find(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Employees working at Bakery {Name}");

            foreach (var employee in data)
            {
                output.AppendLine($"{employee}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
