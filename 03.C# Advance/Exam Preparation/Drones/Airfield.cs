using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        public Airfield(string nameAirfield, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int DroneCount { get { return Drones.Count; } }
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (Drones.Count < Capacity)
            {

                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
            else
            {
                return "Airfield is full.";
            }
        }
        public bool RemoveDrone (string name)
        {
            if (Drones.Find(x => x.Name == name) == null)
            {
                return false;
            }
            else
            {
                Drones.Remove(Drones.Find(x => x.Name == name));
                return true;
            }

        }
        public int RemoveDroneByBrand (string brand)
        {
            int cnt = Drones.Count;
            Drones.RemoveAll(drone => drone.Brand == brand);
            if (cnt == Drones.Count)
            {
                return 0;
            }
            else
            {
                return cnt - Drones.Count;
            }
        }
        public Drone FlyDrone (string name)
        {
            if (Drones.Find(x => x.Name == name) == null)
            {
                return null;
            }
            else
            {
                Drone drone = Drones.Find(x => x.Name == name);
                drone.Fly();
                return drone;
            }
        }
        public List<Drone> FlyDronesByRange (int range)
        {
            List<Drone> drones = new List<Drone>();
            drones = Drones.FindAll(x => x.Range >= range);

            foreach (var drone in drones)
            {
                drone.Fly();
            }
            return drones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
