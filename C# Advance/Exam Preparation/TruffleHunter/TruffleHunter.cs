using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    internal class TruffleHunter
    {
        static void Main(string[] args)
        {
            int matrixdata = int.Parse(Console.ReadLine());

            string[,] matrixForest = new string[matrixdata, matrixdata];
            FillMatrix(matrixForest);

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int eatenTruffles = 0;

            string input = Console.ReadLine();

            while (input != "Stop the hunt")
            {
                string[] command = input.Split(' ');
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                switch (command[0])
                {
                    case "Collect":
                        if (matrixForest[row,col] != "-")
                        {
                            if (matrixForest[row, col] == "B")
                            {
                                blackTruffles++;
                                matrixForest[row, col] = "-";
                            }
                            else if (matrixForest[row, col] == "S")
                            {
                                summerTruffles++;
                                matrixForest[row, col] = "-";
                            }
                            else if (matrixForest[row, col] == "W")
                            {
                                whiteTruffles++;
                                matrixForest[row, col] = "-";
                            }
                        }
                        break;
                    case "Wild_Boar":
                        string direction = command[3];

                        switch (direction)
                        {
                            case "up":
                                for (int i = row; i >= 0; i -= 2)
                                {
                                    if (matrixForest[i, col] != "-")
                                    {
                                        matrixForest[i, col] = "-";
                                        eatenTruffles++;
                                    }                                  
                                }
                                break;
                            case "down":
                                for (int i = row; i < matrixForest.GetLength(0); i += 2)
                                {
                                    if (matrixForest[i, col] != "-")
                                    {
                                        matrixForest[i, col] = "-";
                                        eatenTruffles++;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = col; i >= 0; i -= 2)
                                {
                                    if (matrixForest[row, i] != "-")
                                    {
                                        matrixForest[row, i] = "-";
                                        eatenTruffles++;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = col; i < matrixForest.GetLength(1); i += 2)
                                {
                                    if (matrixForest[row, i] != "-")
                                    {
                                        matrixForest[row, i] = "-";
                                        eatenTruffles++;
                                    }
                                }
                                break;
                        }
                        break;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.\nThe wild boar has eaten {eatenTruffles} truffles.");
            PrintMatrix(matrixForest);

        }

        private static void PrintMatrix(string[,] matrixForest)
        {
            for (int row = 0; row < matrixForest.GetLength(0); row++)
            {
                for (int col = 0; col < matrixForest.GetLength(1); col++)
                {
                    Console.Write(matrixForest[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(string[,] matrixForest)
        {
            for (int row = 0; row < matrixForest.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(' ');

                for (int col = 0; col < matrixForest.GetLength(1); col++)
                {
                    matrixForest[row, col] = rowData[col];
                }
            }
        }
    }
}
