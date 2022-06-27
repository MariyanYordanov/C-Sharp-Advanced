using System;
using System.Linq;

namespace L._05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }

            }

            int maxSum = int.MinValue;
            int indexRow = 2;
            int indexCol = 2;
            int maxIndexRow = 0;
            int maxIndexCol = 0;
            for (int row = 0; row <= rows - indexRow + 1; row++)
            {
                for (int col = 0; col <= cols - indexCol + 1; col++)
                {
                    int sum = 0;
                    for (int currRow = row; currRow < row + indexRow; currRow++)
                    {
                        for (int currCol = col; currCol < col + indexCol; currCol++)
                        {
                            sum += matrix[currRow, currCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxIndexRow = row;
                        maxIndexCol = col;
                    }
                }

            }

            for (int row = maxIndexRow; row < maxIndexRow + indexRow; row++)
            {
                for (int col = maxIndexCol; col < maxIndexCol + indexCol; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
            
        }
    }
}
