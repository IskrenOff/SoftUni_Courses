using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        public string Brand => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public double MaxMileage => throw new NotImplementedException();

        public string LicensePlateNumber => throw new NotImplementedException();

        public int BatteryLevel => throw new NotImplementedException();

        public bool IsDamaged => throw new NotImplementedException();

        public void ChangeStatus()
        {
            throw new NotImplementedException();
        }

        public void Drive(double mileage)
        {
            throw new NotImplementedException();
        }

        public void Recharge()
        {
            throw new NotImplementedException();
        }
    }
}
