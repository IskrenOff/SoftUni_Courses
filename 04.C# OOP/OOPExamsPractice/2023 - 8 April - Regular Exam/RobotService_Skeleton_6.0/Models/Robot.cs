﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandards;



        public string Model => throw new NotImplementedException();

        public int BatteryCapacity => throw new NotImplementedException();

        public int BatteryLevel => throw new NotImplementedException();

        public int ConvertionCapacityIndex => throw new NotImplementedException();

        public IReadOnlyCollection<int> InterfaceStandards => throw new NotImplementedException();

        public void Eating(int minutes)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteService(int consumedEnergy)
        {
            throw new NotImplementedException();
        }

        public void InstallSupplement(ISupplement supplement)
        {
            throw new NotImplementedException();
        }
    }
}
