using System;
using System.Linq;
using System.Collections.Generic;

namespace Armory
{
    internal class Program
    {
        public static int goldCoins;
        public static int officerRow;
        public static int officerCol;
        public static int firstMirrorRow;
        public static int firstMirrorCol;
        public static int secondMirrorRow;
        public static int secondMirrorCol;
        public static int mirrorCnt;
        static void Main(string[] args)
        {
            int matrixData = int.Parse(Console.ReadLine());

            char[,]armory = new char[matrixData, matrixData];
            FillMatrix(armory);

          
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = input[col];

                    if (armory[row, col] == 'M')
                    {
                        if (mirrorCnt == 0)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                            mirrorCnt++;
                        }

                        secondMirrorRow = row;
                        secondMirrorCol = col;
                    }

                    if (armory[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        Movement(-1, 0);
                        break;
                    case "down":
                        Movement(1, 0);
                        break;
                    case "left":
                        Movement(0, 1);
                        break;
                    case "right":
                        Movement(0, -1);
                        break;
                }
            }

        }

        public static void Movement(int row, int col)

        {
            armory[officerRow, officerCol] = '-';
            officerRow += row;
            officerCol += col;
            if (isInArmory(officerRow, officerCol))
            {
                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    goldCoins += int.Parse(armory[officerRow, officerCol].ToString());


                }
                else if (mirrorCnt > 0)
                {
                    if (armory[officerRow, officerCol] == armory[firstMirrorRow, firstMirrorCol])
                    {
                        officerRow = secondMirrorRow;
                        officerCol = secondMirrorCol;
                        armory[firstMirrorCol, firstMirrorCol] = '-';
                    }
                    else if (armory[officerRow, officerCol] == armory[secondMirrorRow, secondMirrorCol])
                    {
                        officerRow = firstMirrorRow;
                        officerCol = firstMirrorCol;
                        armory[secondMirrorRow, secondMirrorCol] = '-';
                    }

                }



            }
            else if (!isInArmory(officerRow, officerCol))
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {goldCoins} gold coins.");
                PrintMatrix(armory);
                Environment.Exit(0);
            }


            armory[officerRow, officerCol] = 'A';
            if (goldCoins >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                Console.WriteLine($"The king paid {goldCoins} gold coins.");
                PrintMatrix(armory);
                Environment.Exit(0);
            }


        }
        public static bool isInArmory(int row, int col)
        {
            return row >= 0 && row <= armory.GetLength(0) && col >= 0 && col <= armory.GetLength(1);
        }
        public static void PrintMatrix(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void FillMatrix(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = rowData[col];
                }
            }
        }
    }
}
