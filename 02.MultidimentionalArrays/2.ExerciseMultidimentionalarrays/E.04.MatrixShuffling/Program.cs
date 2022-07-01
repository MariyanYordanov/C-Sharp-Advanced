using System;
using System.Linq;

namespace E._04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] inputRow = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string[] input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                if (input[0] == "swap" && input.Length == 5)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);
                    if (row1 >= 0 && row2 >= 0 && col1 >= 0 && col2 >= 0 && row1 < matrix.GetLength(0) && row2 < matrix.GetLength(0) && col1 < matrix.GetLength(1) && col2 < matrix.GetLength(1))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
