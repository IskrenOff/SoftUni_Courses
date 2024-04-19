using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int interfaceStandart = 10045;
        private const int batteryUsage = 10000;

        public SpecializedArm() : base(interfaceStandart, batteryUsage)
        {
        }
    }
}
