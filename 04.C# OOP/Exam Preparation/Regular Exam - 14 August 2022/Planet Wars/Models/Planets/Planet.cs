using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.MilitaryUnits;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        //private double militaryPower;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                if (double.IsNaN(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudget);
                }
                budget = value;
            }
        }

        public double MilitaryPower => GetMilitaryPower();
      

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            List<string> unitNames = new List<string>();
            List<string> weaponNames = new List<string>();
            foreach (var unit in Army)
            {
                unitNames.Add(unit.GetType().Name);
            }

            foreach (var unit in Weapons)
            {
                weaponNames.Add(unit.GetType().Name);
            }

            sb.AppendLine($"Planet: {name}");
            sb.AppendLine($"--Budget: {budget} billion QUID");
            if (unitNames.Count != 0)
            {
                sb.AppendLine($"--Forces: {string.Join(", ",unitNames)}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }
            if (weaponNames.Count != 0)
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weaponNames)}");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();

        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in Army)
            {
                item.IncreaseEndurance();
            }
        }

        private double GetMilitaryPower()
        {
            double total = this.Weapons.Sum(w => w.DestructionLevel) + this.Army.Sum(u => u.EnduranceLevel);

            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                total *= 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                total *= 1.45;
            }

            return Math.Round(total, 3);
        }
    }
}
