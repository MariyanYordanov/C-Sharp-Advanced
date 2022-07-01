using System;
using System.Linq;

namespace E._05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            string[,] matrix = new string[rows, cols];
            int counter = -1;
            
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter].ToString();
                    }

                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter].ToString();
                    }
                }

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
