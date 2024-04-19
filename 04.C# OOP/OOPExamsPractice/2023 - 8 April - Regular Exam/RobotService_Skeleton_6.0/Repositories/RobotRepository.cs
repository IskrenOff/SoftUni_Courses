using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public void AddNew(IRobot model)
        {
            throw new NotImplementedException();
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            throw new NotImplementedException();
        }

        public bool RemoveByName(string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
