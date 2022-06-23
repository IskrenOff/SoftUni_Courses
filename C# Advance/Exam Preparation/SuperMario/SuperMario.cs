using System;

namespace SuperMario
{
    internal class SuperMario
    {
        private static int marioRow;
        private static int marioCol;

        private static int newRow;
        private static int newCol;

        private static char[][] maze;

        private const char MarioSymbol = 'M';
        private const char DeadSymbol = 'X';
        private const char PrincesSymbol = 'P';
        private const char BowserSymbol = 'B';
        private const char EmptySymbol = '-';


        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            FillMaze();

            string input = Console.ReadLine();
            bool isOver = false;

            while (!isOver)
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = command[0];
                maze[int.Parse(command[1])][int.Parse(command[2])] = BowserSymbol;

                marioLives--;
                maze[marioRow][marioCol] = EmptySymbol;

                (newRow, newCol) = MoveMario(marioRow, marioCol, direction);

                if (HasValidCoordinates (newRow, newCol))
                {
                    (marioRow, marioCol) = (newRow, newCol);

                    switch (maze[marioRow][marioCol])
                    {
                        case PrincesSymbol:
                            isOver = true;
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                            maze[marioRow][marioCol] = EmptySymbol;
                            break;
                            case BowserSymbol:
                            marioLives -= 2;
                            maze[marioRow][marioCol] = EmptySymbol;
                            break;
                    }
                }
                if (!isOver && marioLives <= 0)
                {
                    maze[marioRow][marioCol] = DeadSymbol;
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    isOver = true;
                }

                input = Console.ReadLine();
            }

            PrintOutput();

        }
        public static void PrintOutput()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
        }
        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < maze.GetLength(0) &&
                   col >= 0 && col < maze[row].Length;
        }
        public static (int, int) MoveMario(int row, int col, string direction)
        {
            switch (direction)
            {
                case "W":
                    row--;
                    break;
                case "S":
                    row++;
                    break;
                case "A":
                    col--;
                    break;
                case "D":
                    col++;
                    break;
            }

            return (row, col);
        }
        public static void FillMaze()
        {
            int rows = int.Parse(Console.ReadLine());
            maze = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                maze[row] = new char[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    maze[row][col] = rowData[col];

                    if (maze[row][col] == MarioSymbol)
                    {
                        (marioRow, marioCol) = (row, col);
                    }
                }
            }
        }
    }
}
