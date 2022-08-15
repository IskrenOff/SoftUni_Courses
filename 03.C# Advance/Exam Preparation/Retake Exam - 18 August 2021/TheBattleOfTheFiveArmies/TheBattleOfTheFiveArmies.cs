using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace TheBattleOfTheFiveArmies
{
    internal class TheBattleOfTheFiveArmies
    {
        static int armor;
        static int armyRow;
        static int armyCol;
        static int newRow;
        static int newCol;
        static void Main(string[] args)
        {
            armor = int.Parse(Console.ReadLine());

            char[][] map = FillMatrix();

            bool armyWon = false;

            while (!armyWon)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];

                map[int.Parse(input[1])][int.Parse(input[2])] = 'O';

                (newRow, newCol) = MoveArmy(armyRow, armyCol, direction);
                map[armyRow][armyCol] = '-';
                armor--;

                if (HasValidCoordinates(newRow,newCol, map))
                {
                    (armyRow, armyRow) = (newRow, newCol);

                    if (map[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                        map[armyRow][armyCol] = '-';
                    }
                    else if (map[armyRow][armyCol] == 'M')
                    {
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        map[armyRow][armyCol] = '-';
                        armyWon = true;
                    }
                }
                if (armor <= 0 && !armyWon)
                {
                    map[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    armyWon = true;
                }
                
            }
            PrintMatrix(map);
        }
        static bool HasValidCoordinates(int row, int col, char[][] map)
        {
            return row >= 0 && row < map.GetLength(0) &&
                   col >= 0 && col < map[row].Length;
        }
        public static (int, int) MoveArmy(int row, int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }

            return (row, col);
        }
        private static void PrintMatrix(char[][] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    Console.Write(map[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static char[][] FillMatrix()
        {
            int size = int.Parse(Console.ReadLine());
            char[][] map = new char[size][];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                map[row] = new char[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    map[row][col] = rowData[col];

                    if (map[row][col] == 'A')
                    {
                        (armyRow, armyCol) = (row, col);
                    }
                }
            }

            return map;
        }
    }
}
