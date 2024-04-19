using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes ;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

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
            IUser user = users.FindById(drivingLicenseNumber);
            if (user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            throw new NotImplementedException();
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            if (vehicle != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            else
            {
                if (vehicleType == nameof(CargoVan))
                {
                    vehicle = new CargoVan(brand,model,licensePlateNumber); 
                }
                else if (vehicleType == nameof(PassengerCar))
                {
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                }
            }

            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            
        }

        public string UsersReport()
        {
            throw new NotImplementedException();
        }
    }
}
