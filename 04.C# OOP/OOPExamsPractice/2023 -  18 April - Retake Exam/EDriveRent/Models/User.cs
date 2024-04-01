using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
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
        private double rating;
        private bool isBlocked;

        public User(string firstName , string lastName, string drivingLicenseNumber )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.rating = 0;
            this.isBlocked = false;
        }

        public string FirstName 
        {
            get => firstName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        public string LastName 
        {
            get => lastName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        public double Rating => this.rating;
        public bool IsBlocked => this.isBlocked;

        public string DrivingLicenseNumber 
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public void DecreaseRating()
        {
            if (rating < 2)
            {
                rating = 0;
                isBlocked = true;
            }
            else
            {
                rating -= 2;
            }
        }

        public void IncreaseRating()
        {
            if (rating < 10)
            {
                rating += 0.5;
            }
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} Driving license: {drivingLicenseNumber} Rating: {rating}";
        }
    }
}
