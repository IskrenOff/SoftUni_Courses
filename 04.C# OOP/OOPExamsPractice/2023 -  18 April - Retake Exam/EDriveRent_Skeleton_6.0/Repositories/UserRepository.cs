using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        public void AddModel(IUser model)
        {
            throw new NotImplementedException();
        }

        public IUser FindById(string identifier)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
