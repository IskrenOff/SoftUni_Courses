using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private double fuelConsumption;
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;

            FuelConsumption = DefaultFuelConsumption;
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public virtual void Drive (int kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
