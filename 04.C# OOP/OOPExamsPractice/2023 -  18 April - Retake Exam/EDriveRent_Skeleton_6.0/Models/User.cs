using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {

        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            //this.FirstName = firstName;
            //this.LastName = lastName;
            //this.DrivingLicenseNumber = drivingLicenseNumber;

        }

        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();

        public double Rating => throw new NotImplementedException();

        public string DrivingLicenseNumber => throw new NotImplementedException();

        public bool IsBlocked => throw new NotImplementedException();

        public void DecreaseRating()
        {
            throw new NotImplementedException();
        }

        public void IncreaseRating()
        {
            throw new NotImplementedException();
        }
    }
}
