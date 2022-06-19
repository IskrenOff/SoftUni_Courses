using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        private List<Car> participants;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count; // ¤ Getter Count - returns the count of the currently enrolled participants

        public List<Car> Participants
        {
            get => participants;
            set => participants = value;
        }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public void Add (Car car)
        {
            // ¤   Adds the entity if there isn't a Car with the same License plate and if there is enough space in terms of race                capacity and if the car meets the maximum horse power requirement of the race. 
            Car duplicateCar = Participants.FirstOrDefault(x => x.LicensePlate.Equals(car.LicensePlate));

            if (duplicateCar == null && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            //  ¤  Removes a Car from the race with the given License plate,
            //  if such exists and returns bool if the deletion is successful.
            return participants.Remove(participants.Find(x => x.LicensePlate == licensePlate));
        }
        public Car FindParticipant (string licensePlate)
        {
            // ¤ returns the Car with most HorsePower.
            // If there are no Cars in the Race, method should return null.
            Car searchCar = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (searchCar == null)
            {
                return null;
            }
            return searchCar;
        }
        public Car GetMostPowerfulCar()
        {
            //  ¤ Returns the Car with most HorsePower.
            //  If there are no Cars in the Race, method should return null.
            if (participants.Count > 0)
            {
                int mostHorsePowerCar = int.MinValue;

                foreach (var car in participants)
                {
                    if (car.HorsePower > mostHorsePowerCar)
                    {
                        mostHorsePowerCar = car.HorsePower;
                    }
                }
                return participants.Find(car => car.HorsePower == mostHorsePowerCar);
            }
            return null;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            for (int i = 0; i < participants.Count -1; i++)
            {
                output.AppendLine(participants[i].ToString());
            }
            output.Append(participants[Count-1].ToString());
            return output.ToString();
        }
    }
}
