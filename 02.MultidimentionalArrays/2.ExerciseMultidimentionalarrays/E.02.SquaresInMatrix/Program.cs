using System;
using System.Linq;

namespace E._02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                char[] arrChars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arrChars[col];
                }
            }

            int indexSquareRow = 0;
            int indexSquareCol = 0;
            int counter = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col + 1] && 
                        matrix[row, col] == matrix[row, col + 1] && 
                        matrix[row, col] == matrix[row + 1, col])
                    {
                        indexSquareRow = row;
                        indexSquareCol = col;
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);

        }
    }
}
