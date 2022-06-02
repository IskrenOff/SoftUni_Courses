﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string carModel = command.Split(' ')[1];
                double amountOfKm = double.Parse(command.Split(' ')[2]);

                Car carToDrive = cars.First(car => car.Model == carModel);
                carToDrive.Drive(amountOfKm);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
