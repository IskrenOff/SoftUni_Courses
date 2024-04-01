using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        protected Vehicle(string brand, string model,double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.maxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
            this.isDamaged = false;
        }

        public string Brand 
        {
            get => brand;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model 
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public int BatteryLevel => this.batteryLevel;
        public double MaxMileage => this.maxMileage;
        public bool IsDamaged => this.isDamaged;

        public string LicensePlateNumber 
        {
            get => licensePlateNumber;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }


        public void ChangeStatus()
        {
            if (!IsDamaged)
            {
                isDamaged = true;
            }
            else
            {
                isDamaged = false;
            }
        }

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / this.maxMileage) * 100);
            this.batteryLevel -= (int)percentage;

            if (this.GetType().Name == nameof(CargoVan))
            {
                this.batteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.batteryLevel = 100;
        }

        public override string ToString()
        {
            string vehicleCondition;

            if (this.IsDamaged)
            {
                vehicleCondition = "damaged";
            }
            else 
            {
                vehicleCondition = "OK";
            }

            return $"{brand} {model} License plate: {licensePlateNumber} Battery: {batteryLevel}% Status: {vehicleCondition}";
        }
    }
}
