using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count; 

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            
            if (string.IsNullOrEmpty(renovator.Type) && string.IsNullOrEmpty(renovator.Name))
            {
                return "Invalid renovator's information.";
            }
            else if (!(Count < NeededRenovators))
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }


        public bool RemoveRenovator (string name)
        {
            return renovators.Remove(renovators.FirstOrDefault(x => x.Name == name));
        }


        public int RemoveRenovatorBySpecialty (string type)
        {
            if (renovators.Any(x => x.Type == type))
            {
                int count = renovators.Count;
                renovators.RemoveAll(x => x.Type == type);
                return count;
            }
            return 0;   
        }
        public Renovator HireRenovator (string name)
        {
            Renovator currRenovator = null;
            foreach (var renovator in renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    currRenovator = renovator;
                }
            }
            return currRenovator;
        }


        public List<Renovator> PayRenovators(int days)
        {
            return new List<Renovator>(renovators.Where(x => x.Days >= days));
        }
        public string Report()
        {
            var renovats = this.renovators.Where(x => x.Hired == false);
            return $"Renovators available for Project {Project}:" + Environment.NewLine + string.Join(Environment.NewLine, renovats);
        }
    }
}
