using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using System.Numerics;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private  PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
      
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;

            switch (unitTypeName)
            {
                case nameof(StormTroopers):
                    unit = new StormTroopers();
                    break;
                case nameof(SpaceForces):
                    unit = new SpaceForces();
                    break;
                case nameof(AnonymousImpactUnit):
                    unit = new AnonymousImpactUnit();
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            Weapon weapon = null;
            IPlanet planet = planets.FindByName(planetName);

            switch (weaponTypeName)
            {
                case nameof (BioChemicalWeapon):
                    weapon = new BioChemicalWeapon(destructionLevel);  
                    break;
                case nameof (NuclearWeapon):
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case nameof (SpaceMissiles):
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default: string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName);
                    break;
            }

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }
            if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));              
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded,planetName,weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {           
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedList = planets.Models.OrderByDescending
                (p => p.MilitaryPower).ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedList)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            bool nuclearWeaponPlanet1 = planet1.Weapons.Any(x => x is NuclearWeapon);
            bool nuclearWeaponPlanet2 = planet2.Weapons.Any(x => x is NuclearWeapon);          

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (nuclearWeaponPlanet1 == nuclearWeaponPlanet2)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return string.Format(OutputMessages.NoWinner);
                }
                else if (nuclearWeaponPlanet1)
                {
                    return DefineWinnerPricePool(planet1, planet2);
                }
                else if (nuclearWeaponPlanet2)
                {
                    return DefineWinnerPricePool(planet2,planet1);              
                }
            }

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                return DefineWinnerPricePool(planet1, planet2);
            }
            else
            {
                return DefineWinnerPricePool(planet2, planet1);
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string DefineWinnerPricePool(IPlanet winner,IPlanet looser)
        {
            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(x => x.Cost));
            winner.Profit(looser.Weapons.Sum(x => x.Price));
            planets.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }
        public string GetPlanetCount()
        {
            int count = planets.Models.Count;
            return count.ToString();
        }
    }
}
