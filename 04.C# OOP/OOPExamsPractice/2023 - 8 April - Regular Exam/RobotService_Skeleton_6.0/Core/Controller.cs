using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;

            switch (typeName)
            {
                case "DomesticAssistant":
                    robot = new DomesticAssistant(model);
                    break;
                case "IndustrialAssistant":
                    robot = new IndustrialAssistant(model);
                    break;
                default:
                    return string.Format (OutputMessages.RobotCannotBeCreated, typeName);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;

            switch (typeName)
            {
                case "SpecializedArm":
                    supplement = new SpecializedArm();
                    break;
                case "LaserRadar":
                    supplement = new LaserRadar();
                    break;
                default:
                    return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = robots.Models().Where(x => x.InterfaceStandards.Any(d => d == interfaceStandard)).OrderByDescending(x => x.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
            }

            int sumBL = selectedRobots.Sum(x => x.BatteryLevel);

            if (sumBL < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBL);
            }

            int robotCountInServi = 0;

            foreach (var robot in selectedRobots)
            {
                robotCountInServi++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCountInServi);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var robotReportCollection = robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(b => b.BatteryCapacity);

            foreach (var robot in robotReportCollection)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var selectedRobots = robots.Models().Where(x => x.Model == model && x.BatteryLevel * 2 < x.BatteryCapacity);
            int robotsFedCount = 0;

            foreach (var robot in selectedRobots)
            {
                robotsFedCount++;
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsFedCount);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            var selectedModels = robots.Models().Where(f => f.Model == model);
            var stillNotUpgraded = selectedModels.Where(p => p.InterfaceStandards.All(s => s != supplement.InterfaceStandard));
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();

            if (robotForUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotForUpgrade.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
