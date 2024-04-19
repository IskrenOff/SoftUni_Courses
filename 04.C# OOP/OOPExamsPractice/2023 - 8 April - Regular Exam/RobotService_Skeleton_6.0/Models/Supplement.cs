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
        private int interfaceStandard;
        private int batteryUsage;

        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            this.InterfaceStandard = interfaceStandard;
            this.BatteryUsage = batteryUsage;

        }

        public int InterfaceStandard 
        {
            get => interfaceStandard;
            set => interfaceStandard = value;
        }

        public int BatteryUsage 
        {
            get => batteryUsage;
            set => batteryUsage = value;
        }
    }
}
