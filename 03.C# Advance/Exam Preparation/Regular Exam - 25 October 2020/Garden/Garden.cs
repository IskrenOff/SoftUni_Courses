using System;
using System.Collections.Generic;

namespace Garden
{
    internal class Garden
    {

        private static int[,] garden;
        private static int numberOfRows;
        private static int numberOfCols;

        private static List<(int, int)> plantCoordinates = new List<(int, int)>();

        static void Main(string[] args)
        {
            FillGarden();

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                string[] coordinatesAsStirng = input.Split(' ');
                int row = int.Parse(coordinatesAsStirng[0]);
                int col = int.Parse(coordinatesAsStirng[1]);

                PlantFlowers(row, col);

                input = Console.ReadLine();
            }

            Bloom();
            PrintOutput();
            
        }

        

        private static void FillGarden()
        {
            string[] dimensions = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            numberOfRows = int.Parse(dimensions[0]);
            numberOfCols = int.Parse(dimensions[1]);

            garden = new int[numberOfRows,numberOfCols];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    garden[row, col] = 0;
                }
            }
        }
        static bool HasValidCoordinates (int row, int col)
        {
             return row >= 0 && row < numberOfRows &&
                col >= 0 && col < numberOfCols;
        }

        public static void PlantFlowers (int row , int col)
        {
            if (HasValidCoordinates(row, col))
            {
                plantCoordinates.Add((row, col));
            }
            else
            {
                Console.WriteLine("Invalid coordinates.");
            }
        }

        public static void SpreadFlowers(int startRow, int startCol)
        {
            garden[startRow, startCol] -= 1;

            for (int row = 0; row < numberOfRows; row++)
            {
                garden[row, startCol] += 1;
            }
            for (int col = 0; col < numberOfCols; col++)
            {
                garden[startCol, col] += 1;
            }
        }
        public static void Bloom()
        {
            foreach (var (row,col) in plantCoordinates)
            {
                SpreadFlowers(row, col);
            }
        }
        public static void PrintOutput()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfCols; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
