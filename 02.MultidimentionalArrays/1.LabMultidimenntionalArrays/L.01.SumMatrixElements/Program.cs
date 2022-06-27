using System;
using System.Linq;

namespace L._01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows,cols];
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                    sum += rowInput[col];
                }
                
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);


            // PRINT   MATRIX

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }

            //    Console.WriteLine();
            //}
        }
    }
}
