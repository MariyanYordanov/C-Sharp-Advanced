using System;
using System.Linq;

namespace E._03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int indexRow = 3;
            int indexCol = 3;
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rows - indexRow + 1; row++)
            {
                for (int col = 0; col < cols - indexCol + 1; col++)
                {
                    int sum = 0;
                    for (int currentRow = row; currentRow < row + indexRow; currentRow++)
                    {
                        for (int currentCol = col; currentCol < col +  indexCol; currentCol++)
                        {
                            sum += matrix[currentRow,currentCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }

            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row < maxRow + indexRow; row++)
            {
                for (int col = maxCol; col < maxCol + indexCol; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
