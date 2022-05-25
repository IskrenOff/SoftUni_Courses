using System;

namespace _04._BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int houer = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes > 59)
            {
                minutes -= 60;
                houer += 1;
            }
            if (houer > 23)
            {
                houer = 0;
            }
            Console.WriteLine($"{houer}:{minutes:D2}");


        }
    }
}
