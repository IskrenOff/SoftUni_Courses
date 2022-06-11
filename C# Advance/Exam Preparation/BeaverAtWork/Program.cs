using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixData = int.Parse(Console.ReadLine());

            string[,] pond = new string[matrixData, matrixData];

            FillMatrix(pond);

            int[] beaverPosition = new int[] {0,0};
            int branchCnt = 0;
            int branchesCollect = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (pond[row, col] != "-" && pond[row, col] != "F" && pond[row, col] != "B")
                    {
                        branchCnt++;
                    }
                }
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (pond[row ,col] == "B")
                    {
                        beaverPosition[0] = row;
                        beaverPosition[1] = col;
                    }
                }
            }

            Stack<string> beaverStorage = new Stack<string>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "up":
                        if (beaverPosition[0]-1 < 0)
                        {
                            if (beaverStorage.Count > 0)
                            {
                                beaverStorage.Pop();
                                branchesCollect--;
                            }
                        }
                        else
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            beaverPosition[0]--;
                        }
                        if (pond[beaverPosition[0], beaverPosition[1]] == "F")
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";

                            if (beaverPosition[0] == 0)
                            {
                                beaverPosition[0] = pond.GetLength(0)-1;
                            }
                            else
                            {
                                beaverPosition[0] = 0;
                            }
                        }
                        else if (pond[beaverPosition[0], beaverPosition[1]] != "-")
                        {
                            beaverStorage.Push(pond[beaverPosition[0], beaverPosition[1]]);
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            branchCnt--;
                            branchesCollect++;
                        }
                        break;
                    case "down":
                        if (beaverPosition[0]+1 > pond.GetLength(1)-1)
                        {
                            if (beaverStorage.Count > 0)
                            {
                                beaverStorage.Pop();
                                branchesCollect--;
                            }
                        }
                        else
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            beaverPosition[0]++;
                        }
                        if (pond[beaverPosition[0], beaverPosition[1]] == "F")
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";

                            if (beaverPosition[0] == pond.GetLength(0)-1)
                            {
                                beaverPosition[0] = 0;
                            }
                            else
                            {
                                beaverPosition[0] = pond.GetLength(1)-1;
                            }
                        }
                        else if (pond[beaverPosition[0], beaverPosition[1]] != "-")
                        {
                            beaverStorage.Push(pond[beaverPosition[0], beaverPosition[1]]);
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            branchCnt--;
                            branchesCollect++;
                        }
                        break;
                    case "left":
                        if (beaverPosition[1]-1 < 0)
                        {
                            if (beaverStorage.Count > 0)
                            {
                                beaverStorage.Pop();
                                branchesCollect--;
                            }
                        }
                        else
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            beaverPosition[1]--;
                        }
                        if (pond[beaverPosition[0], beaverPosition[1]] == "F")
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";

                            if (beaverPosition[1] == 0)
                            {
                                beaverPosition[1] = pond.GetLength(0) - 1;
                            }
                            else
                            {
                                beaverPosition[1] = 0;
                            }
                        }
                        else if (pond[beaverPosition[0], beaverPosition[1]] != "-")
                        {
                            beaverStorage.Push(pond[beaverPosition[0], beaverPosition[1]]);
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            branchCnt--;
                            branchesCollect++;
                        }
                        break;
                    case "right":
                        if (beaverPosition[1]+1 > pond.GetLength(0)-1)
                        {
                            if (beaverStorage.Count > 0)
                            {
                                beaverStorage.Pop();
                                branchesCollect--;
                            }
                        }
                        else
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            beaverPosition[1]++;
                        }
                        if (pond[beaverPosition[0], beaverPosition[1]] == "F")
                        {
                            pond[beaverPosition[0], beaverPosition[1]] = "-";

                            if (beaverPosition[1] == pond.GetLength(0)-1)
                            {
                                beaverPosition[1] = 0;
                            }
                            else
                            {
                                beaverPosition[1] = pond.GetLength(0)-1;
                            }
                        }
                        else if (pond[beaverPosition[0], beaverPosition[1]] != "-")
                        {
                            beaverStorage.Push(pond[beaverPosition[0], beaverPosition[1]]);
                            pond[beaverPosition[0], beaverPosition[1]] = "-";
                            branchCnt--;
                            branchesCollect++;
                        }
                        break;
                }
                if (branchCnt == 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            pond[beaverPosition[0], beaverPosition[1]] = "B";

            if (branchCnt != 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchCnt} branches left.");
                PrintMatrix(pond);
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branchesCollect} wood branches: {string.Join(", ",beaverStorage.Reverse())}.");
                PrintMatrix(pond);
            }
        }

        private static void PrintMatrix(string[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void FillMatrix(string[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(' ');

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = rowData[col];
                }
            }
        }
        
    }
}
