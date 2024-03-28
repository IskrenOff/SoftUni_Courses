using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private IWorkshop workshop;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();

        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            switch (bunnyType)
            {
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var targetBunny = bunnies.FindByName(bunnyName);

            if (targetBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            targetBunny.AddDye(new Dye(power));

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var selectedBunny = bunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (!selectedBunny.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg eggToColor = eggs.FindByName(eggName);
            Workshop workshop = new Workshop();

            foreach (var bunny in selectedBunny)
            {
                workshop.Color(eggToColor, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (eggToColor.IsDone() == true)
                {
                    break;
                }
            }

            return eggToColor.IsDone() == true
                ? string.Format(OutputMessages.EggIsDone, eggName)
                : string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int coloredEggs = eggs.Models.Count(x => x.IsDone() == true);

            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                int cntDyesNotfinished = bunny.Dyes.Count(x => x.IsFinished() == false);

                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {cntDyesNotfinished} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
