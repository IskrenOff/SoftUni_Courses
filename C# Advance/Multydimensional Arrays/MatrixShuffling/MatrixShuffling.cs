using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] myMatrix = new string[rows, cols];

            FillMatrix(myMatrix);

            string command = Console.ReadLine();

            while (command != "END")
            {
                // Check if the command is valid
                if (!ValidateCommand(command, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string[] commandParts = command.Split(' ');
                    int row1 = int.Parse(commandParts[1]);
                    int col1 = int.Parse(commandParts[2]);
                    int row2 = int.Parse(commandParts[3]);
                    int col2 = int.Parse(commandParts[4]);
                    string firstElement = myMatrix[row1, col1];
                    string secondElement = myMatrix[row2, col2];
                    //swap the elements
                    myMatrix[row1, col1] = secondElement;
                    myMatrix[row2, col2] = firstElement;

                    PrintMatrix(myMatrix);
                }
                
                command = Console.ReadLine();
            }

        }

        private static void PrintMatrix(string[,] myMatrix)
        {
            for (int row = 0; row < myMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < myMatrix.GetLength(1); col++)
                {
                    Console.Write(myMatrix[row , col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidateCommand(string command , int rows , int cols)
        {
            string[] commandParts = command.Split(' ');

            //Your program should then receive commands in the format: "swap row1 col1 row2 col2" where row1, col1, row2, col2 are coordinates in the matrix. For a command to be valid, it should start with the "swap" keyword along with four valid coordinates(no more, no less). 

            if (commandParts[0] == "swap" && commandParts.Length == 5)
            {
                int row1 = int.Parse(commandParts[1]);
                int col1 = int.Parse(commandParts[2]);
                int row2 = int.Parse(commandParts[3]);
                int col2 = int.Parse(commandParts[4]);

                // valid command -> check if the rows and cols or in the matrix

                if (row1 >= 0 && row1 < rows 
                    && col1 >= 0 && col1 < cols 
                    && row2 >= 0 && row2 < rows 
                    && col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(' ');

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
