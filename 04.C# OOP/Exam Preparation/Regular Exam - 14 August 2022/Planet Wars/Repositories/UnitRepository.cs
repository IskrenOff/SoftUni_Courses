using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => militaryUnits;

        public void AddItem(IMilitaryUnit model)
        {
            militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return militaryUnits.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return militaryUnits.Remove(FindByName(name));
        }
    }
}
