using EDriveRent.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            throw new NotImplementedException();
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            throw new NotImplementedException();
        }

        public string RepairVehicles(int count)
        {
            throw new NotImplementedException();
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            throw new NotImplementedException();
        }

        public string UsersReport()
        {
            throw new NotImplementedException();
        }
    }
}
