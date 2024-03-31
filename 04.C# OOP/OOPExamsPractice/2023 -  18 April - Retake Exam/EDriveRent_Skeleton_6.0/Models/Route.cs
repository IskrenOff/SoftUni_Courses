using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        public string StartPoint => throw new NotImplementedException();

        public string EndPoint => throw new NotImplementedException();

        public double Length => throw new NotImplementedException();

        public int RouteId => throw new NotImplementedException();

        public bool IsLocked => throw new NotImplementedException();

        public void LockRoute()
        {
            throw new NotImplementedException();
        }
    }
}
