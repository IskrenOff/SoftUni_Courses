using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepo;
        private readonly IRepository<IPlanet> planetRepo;


        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepo.Add(astronaut);

            string result = string.Format(OutputMessages.AstronautAdded, type, astronautName); 

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepo.Add(planet);

            string result = string.Format(OutputMessages.PlanetAdded,planetName);

            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RetireAstronaut(string astronautName)
        {
            throw new NotImplementedException();
        }
    }
}
