using System;
using System.Linq;

namespace E._01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPrimeryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (row == col)
                    {
                        sumPrimeryDiagonal += matrix[row, col];
                    }
                    if (n - 1 - row == col)
                    {
                        sumSecondaryDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumPrimeryDiagonal - sumSecondaryDiagonal));
            
        }
    }
}
