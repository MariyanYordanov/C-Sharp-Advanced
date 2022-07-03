using System;
using System.Linq;

namespace E._09.Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string[] inputCoordinates = Console.ReadLine().Split();
            for (int i = 0; i < inputCoordinates.Length; i++)
            {
                int[] bomb = inputCoordinates[i].Split(",").Select(int.Parse).ToArray();
                Expload(matrix, bomb);
            }

            int alive = 0;
            int sum = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    sum += item;
                    alive++;
                }
            }

            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static bool IsInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        static void Expload(int[,] matrix, int[] bomb)
        {
            int bombRow = bomb[0];
            int bombCol = bomb[1];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (bombRow == row && bombCol == col)
                    {
                        int valueBomb = matrix[bombRow, bombCol];
                        if (valueBomb > 0)
                        {
                            if (IsInRange(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                            {
                                matrix[row - 1, col] -= valueBomb;
                            }

                            if (IsInRange(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= valueBomb;
                            }

                            if (IsInRange(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                            {
                                matrix[row, col + 1] -= valueBomb;
                            }

                            if (IsInRange(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= valueBomb;
                            }

                            if (IsInRange(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                            {
                                matrix[row + 1, col] -= valueBomb;
                            }

                            if (IsInRange(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= valueBomb;
                            }

                            if (IsInRange(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                            {
                                matrix[row, col - 1] -= valueBomb;
                            }

                            if (IsInRange(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= valueBomb;
                            }

                            matrix[bombRow, bombCol] = 0;
                        }
                    }
                }
            }
        }
    }
}
