using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        public void AddModel(IRoute model)
        {
            throw new NotImplementedException();
        }

        public IRoute FindById(string identifier)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
