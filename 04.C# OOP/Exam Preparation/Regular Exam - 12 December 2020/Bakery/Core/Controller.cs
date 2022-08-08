using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bakery.Utilities.Enums;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables =new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            switch (type)
            {
                case nameof(BakedFoodType.Bread):
                    bakedFood = new Bread(name, price);
                    break;
                case nameof(BakedFoodType.Cake):
                    bakedFood = new Cake(name, price);
                    break;
            }

            bakedFoods.Add(bakedFood);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case nameof(TableType.InsideTable):
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case nameof(TableType.OutsideTable):
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    sb.Append(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var currentTable = tables.First(x => x.TableNumber == tableNumber);
            decimal totalBill = currentTable.GetBill();

            currentTable.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {totalBill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currentTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var currentBoza = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currentBoza == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            currentTable.OrderDrink(currentBoza);
            totalIncome += currentBoza.Price;

            return string.Format($"Table {tableNumber} ordered {drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currentTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var currentBanica = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currentBanica == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            currentTable.OrderFood(currentBanica);
            totalIncome += currentBanica.Price;

            return string.Format(OutputMessages.FoodOrderSuccessful,tableNumber,foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {          
            if (!tables.Any(x => x.Capacity >= numberOfPeople && x.IsReserved == false))
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            var availableTable = tables.First(x => x.Capacity >= numberOfPeople && x.IsReserved == false);

            availableTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, availableTable.TableNumber, numberOfPeople);
        }
    }
}
