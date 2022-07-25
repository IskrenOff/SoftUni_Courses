using System;
using System.Linq;

namespace WallDestroyer
{
    internal class WallDestroyer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n,n];

            FillMatrix(wall);

            int[] vankoPosition = new int[] {0,0};

            FindVankoPosition(vankoPosition, wall);

            int row = vankoPosition[0];
            int col = vankoPosition[1];

            string command = Console.ReadLine();

            int holes = 0;
            int rod = 0;

            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        if (row - 1 >= 0)
                        {
                            if (wall[row - 1, col] == '-')
                            {
                                wall[row, col] = '*';
                                row--;
                                wall[row, col] = 'V';
                                holes++;
                            }
                            else if (wall[row - 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rod++;
                            }
                            else if (wall[row - 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row - 1}, {col}]!");
                                wall[row, col] = '*';
                                row--;
                            }
                            else if (wall[row - 1, col] == 'C')
                            {
                                holes += 2;
                                wall[row, col] = '*';
                                row--;
                                wall[row, col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                                PrintMatrix(wall);
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (row + 1 <= wall.GetLength(0))
                        {
                            if (wall[row + 1, col] == '-')
                            {
                                wall[row, col] = '*';
                                row++;
                                wall[row, col] = 'V';
                                holes++;
                            }
                            else if (wall[row + 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rod++;
                            }
                            else if (wall[row + 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row + 1}, {col}]!");
                                wall[row, col] = '*';
                                row++;
                            }
                            else if (wall[row + 1, col] == 'C')
                            {
                                holes += 2;
                                wall[row, col] = '*';
                                row++;
                                wall[row, col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                                PrintMatrix(wall);
                                return;
                            }
                        }
                        break;
                    case "left":
                        if (col - 1 >= 0)
                        {
                            if (wall[row, col - 1] == '-')
                            {
                                wall[row, col] = '*';
                                col--;
                                wall[row, col] = 'V';
                                holes++;
                            }
                            else if (wall[row, col - 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rod++;
                            }
                            else if (wall[row, col - 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row}, {col - 1}]!");
                                wall[row, col] = '*';
                                col--;
                            }
                            else if (wall[row, col - 1] == 'C')
                            {
                                holes += 2;
                                wall[row, col] = '*';
                                col--;
                                wall[row, col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                                PrintMatrix(wall);
                                return;
                            }
                        }
                        break;
                    case "right":
                        if (col + 1 <= wall.GetLength(1))
                        {
                            if (wall[row, col + 1] == '-')
                            {
                                holes++;
                                wall[row, col] = '*';
                                col++;
                                wall[row, col] = 'V';
                            }
                            else if (wall[row, col + 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rod++;
                            }
                            else if (wall[row, col + 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row}, {col + 1}]!");
                                wall[row, col] = '*';
                                col++;
                            }
                            else if (wall[row, col + 1] == 'C')
                            {
                                holes += 2;
                                wall[row, col] = '*';
                                col++;
                                wall[row, col] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                                PrintMatrix(wall);
                                return;
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            int placesWithNoholes = 1;

            if (placesWithNoholes == 0)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rod} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes + 1} hole(s) and he hit only {rod} rod(s).");
            }
            PrintMatrix(wall);
        }
        private static void PrintMatrix(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
            private static void FindVankoPosition(int[] vankoPosition, char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0) -1; row++)
            {
                for (int col = 0; col < chessboard.GetLength(1) -1; col++)
                {
                    if (chessboard[row, col] == 'V')
                    {
                        vankoPosition[0] = row;
                        vankoPosition[1] = col;
                    }
                }
            }
        }
        private static void FillMatrix(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = rowData[col];
                }
            }
        }
    }
}
