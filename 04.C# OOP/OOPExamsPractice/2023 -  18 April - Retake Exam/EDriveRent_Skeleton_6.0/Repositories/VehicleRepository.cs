using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        public void AddModel(IVehicle model)
        {
            throw new NotImplementedException();
        }

        public IVehicle FindById(string identifier)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
