using System;
using System.Linq;

namespace Help_A_Mole_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int points = 0;

            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            for (int r = 0; r < n; r++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int c = 0; c < n; c++)
                {
                    field[r, c] = input[0][c];
                }
            }



            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
                    break;
                }
                (int row, int col) = MolePosition(field);

                if ((row, col) == (69, 69))
                {
                    break;
                }


                if (command == "up")
                {
                    points += Movement(row, col, row - 1, col, field);
                }
                else if (command == "down")
                {
                    points += Movement(row, col, row + 1, col, field);
                }
                else
                if (command == "right")
                {
                    points += Movement(row, col, row, col + 1, field);

                }
                else if (command == "left")
                {
                    points += Movement(row, col, row, col - 1, field);
                }
                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    Console.Write(String.Join("", field[row, col]));
                Console.WriteLine();
            }
        }

        static (int row, int col) MolePosition(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLongLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLongLength(1); c++)
                {
                    if (matrix[r, c] == 'M')
                    {
                        return (r, c);
                    }
                }
            }
            return (69, 69);
        }

        static (int row, int col) TeleportMole(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLongLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLongLength(1); c++)
                {
                    if (matrix[r, c] == 'S')
                    {
                        return (r, c);
                    }
                }
            }
            return (69, 69);
        }
        static int Movement(int row, int col, int newRow, int newCol, char[,] matrix)
        {
            if (0 > newRow ||
                0 > newCol ||
                matrix.GetLength(0) <= newRow ||
                matrix.GetLength(1) <= newCol)
            {
                Console.WriteLine("Don't try to escape the playing field!");

                return 0;
            }
            matrix[row, col] = '-';
            char pointsToAdd = matrix[newRow, newCol];
            matrix[newRow, newCol] = 'M';


            if (char.IsDigit(pointsToAdd))
            {
                return pointsToAdd - 48;
            }
            else if (pointsToAdd == 'S')
            {
                matrix[newRow, newCol] = '-';
                (int SpecialRow, int TeleporetedRow) = TeleportMole(matrix);
                matrix[SpecialRow, TeleporetedRow] = 'M';

                return -3;
            }

            return 0;
        }


    }
}
