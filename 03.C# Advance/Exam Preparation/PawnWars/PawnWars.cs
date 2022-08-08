using System;
using System.Collections.Generic;
using System.Linq;

namespace PawnWars
{
    internal class PawnWars
    {
        static void Main(string[] args)
        {
            char[,] chessboard = new char[8, 8];
            FillMatrix(chessboard);

            int[] whitePawnPosition = new int[] {0,0};
            FindWhitePawnPosition(whitePawnPosition,chessboard);
            int[] blackPawnPosition = new int[] {0, 0};
            FindBlackPawnPosition(blackPawnPosition, chessboard);

            string[] chessLetters = new string[8] {"a","b","c","d","e","f","g","h"};

            while (true)
            {
                if (whitePawnPosition[1] == 0)
                {
                    if (chessboard[whitePawnPosition[0] - 1, whitePawnPosition[1] + 1] == 'b')
                    {
                        string coordinates = chessLetters[blackPawnPosition[1]] + (8 - blackPawnPosition[0]);
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                }
                else if (whitePawnPosition[1] == 7)
                {
                    if (chessboard[whitePawnPosition[0] - 1, whitePawnPosition[1] - 1] == 'b')
                    {
                        string coordinates = chessLetters[blackPawnPosition[1]] + (8 - blackPawnPosition[0]);
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                }
                else
                {
                    if (chessboard[whitePawnPosition[0] - 1, whitePawnPosition[1] - 1] == 'b')
                    {
                        string coordinates = chessLetters[blackPawnPosition[1]] + (8 - blackPawnPosition[0]);
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                    else if (chessboard[whitePawnPosition[0] - 1, whitePawnPosition[1] + 1] == 'b')
                    {
                        string coordinates = chessLetters[blackPawnPosition[1]] + (8 - blackPawnPosition[0]);
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                }
                for (int w = 0; w < 1; w++)
                {
                    chessboard[whitePawnPosition[0], whitePawnPosition[1]] = '-';
                    whitePawnPosition[0]--;
                    chessboard[whitePawnPosition[0], whitePawnPosition[1]] = 'w';
                }

                if (whitePawnPosition[0] == 0)
                {
                    string coordinates = chessLetters[whitePawnPosition[1]] + "8";
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    break;
                }
                if (blackPawnPosition[1] == 7)
                {
                    if (chessboard[blackPawnPosition[0] + 1, blackPawnPosition[1] - 1] == 'w')
                    {
                        string coordinates = chessLetters[whitePawnPosition[1]] + (8 - whitePawnPosition[0]);
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                }
                else if (blackPawnPosition[1] == 0)
                {
                    if (chessboard[blackPawnPosition[0] + 1, blackPawnPosition[1] + 1] == 'w')
                    {
                        string coordinates = chessLetters[whitePawnPosition[1]] + (8 - whitePawnPosition[0]);
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                }
                else
                {
                    if (chessboard[blackPawnPosition[0] + 1, blackPawnPosition[1] - 1] == 'w')
                    {
                        string coordinates = chessLetters[whitePawnPosition[1]] + (8 - whitePawnPosition[0]);
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                    else if (chessboard[blackPawnPosition[0] + 1, blackPawnPosition[1] + 1] == 'w')
                    {
                        string coordinates = chessLetters[whitePawnPosition[1]] + (8 - whitePawnPosition[0]);
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                }
                for (int b = 0; b < 1; b++)
                {
                    chessboard[blackPawnPosition[0], blackPawnPosition[1]] = '-';
                    blackPawnPosition[0]++;
                    chessboard[blackPawnPosition[0], blackPawnPosition[1]] = 'b';

                }
                if (blackPawnPosition[0] == 7)
                {
                    string coordinates = chessLetters[blackPawnPosition[1]] + "1";
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    break;
                }
            }

        }

        private static void FindWhitePawnPosition(int[] whitePawnPosition, char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'w')
                    {
                        whitePawnPosition[0] = row;
                        whitePawnPosition[1] = col;
                    }
                }
            }
        }
        private static void FindBlackPawnPosition(int[] blackPawnPosition, char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'b')
                    {
                        blackPawnPosition[0] = row;
                        blackPawnPosition[1] = col;
                    }
                }
            }
        }

        private static void FillMatrix(char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = rowData[col];
                }
            }
        }
    }
}
