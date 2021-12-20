using System;

namespace QueensProblem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int queens = int.Parse(Console.ReadLine());

            int[,] matrix = new int[queens, queens];

            Console.WriteLine(GetQueens(matrix, 0));
        }

        static int GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                PrintQueens(queens);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < queens.GetLength(1); col++)
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row, col] = 1;

                    foundQueens += GetQueens(queens, row + 1);

                    queens[row, col] = 0;
                }
            }

            return foundQueens;
        }

        static void PrintQueens(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        Console.Write("Q" + " ");
                    }

                    if (matrix[row, col] == 0)
                    {
                        Console.Write("*" + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }

                if (col - i >= 0 && queens[row, col - i] == 1)
                {
                    return false;
                }

                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col + i] == 1)
                {
                    return false;
                }

                if (col - i >= 0 &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col - i] == 1)
                {
                    return false;
                }

                if (row - i >= 0 && 
                    col - i >= 0 && 
                    queens[row - i, col - i] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) && 
                    row - i >= 0 && 
                    queens[row - i, col + i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
