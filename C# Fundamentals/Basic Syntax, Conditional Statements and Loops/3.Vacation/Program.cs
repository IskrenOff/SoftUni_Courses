using System;

namespace _3.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int peopleCnt = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();  
            string dayOfTheWeek = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;  

            switch (groupType)
            {
                case "Students":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    if (peopleCnt >= 30)
                    {
                        totalPrice = price * peopleCnt;
                        totalPrice -= totalPrice * 0.15;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = price * peopleCnt;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    break;
                case "Business":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                    }
                    if (peopleCnt >= 100)
                    {
                        totalPrice = price * peopleCnt;
                        totalPrice -= price * 10;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = price * peopleCnt;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    break;
                case "Regular":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                    }
                    if (peopleCnt >= 10 && peopleCnt <= 20)
                    {
                        totalPrice = price * peopleCnt;
                        totalPrice -= totalPrice * 0.05;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = price * peopleCnt;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    break;
            }







        }
    }
}
