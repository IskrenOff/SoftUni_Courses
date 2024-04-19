using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandart;
        private int batteryUsage;

        protected Supplement(int interfaceStandart, int batteryUsage)
        {
            this.InterfaceStandard = interfaceStandart;

            this.batteryUsage = batteryUsage;

        }

        public int InterfaceStandard 
        {
            get => interfaceStandart;
            set => interfaceStandart = value;
        }

        public int BatteryUsage 
        {
            get => batteryUsage;
            set => batteryUsage = value;
        }
    }
}
