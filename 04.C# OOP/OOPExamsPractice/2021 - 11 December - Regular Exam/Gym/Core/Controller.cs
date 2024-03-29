using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currentAthlete;

            if (athleteType == nameof(Boxer))
            {
                currentAthlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteName == nameof(Weightlifter)) 
            {
                currentAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            var gymType = gym.GetType().Name;

            if (athleteType == "Boxer" && gymType == "WeightliftingGym" ||
                athleteType == "Weightlifter" && gymType == "BoxingGym")
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(currentAthlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment;

            if (equipmentType == nameof(BoxingGloves))
            {
                currentEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currentEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currentEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded,gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var result = gyms.FirstOrDefault(x => x.Name == gymName);

            if (result == null)
            {
                return string.Empty;
            }

            var equipmentWight = result.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, equipmentWight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currentEquipment = equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (currentEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = gyms.FirstOrDefault(c => c.GetType().Name == gymName);

            if (gym == null)
            {
                return string.Empty;
            }

            gym.AddEquipment(currentEquipment);
            equipment.Remove(currentEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (gym == null)
            {
                return string.Empty;
            }
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
