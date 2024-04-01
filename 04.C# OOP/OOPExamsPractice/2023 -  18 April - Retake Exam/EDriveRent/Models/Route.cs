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
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            //this.StartPoint = startPoint;
            //this.EndPoint = endPoint;
            //this.Length = length;
            //this.RouteId = routeId;

        }

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
