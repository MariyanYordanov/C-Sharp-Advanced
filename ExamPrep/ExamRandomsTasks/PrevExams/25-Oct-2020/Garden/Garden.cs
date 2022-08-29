using System;
using System.Linq;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] matrixDimention = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] garden = new int[matrixDimention[0], matrixDimention[1]];
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow")
                {
                    break;
                }
                
                int plantRow = int.Parse(input[0].ToString());
                int plantCol = int.Parse(input[2].ToString());
                if (plantRow < 0 || plantRow > garden.GetLength(0) || plantCol < 0 || plantCol > garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    garden[row, plantCol]++;
                }

                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[plantRow, col]++;
                }

                garden[plantRow, plantCol] -= 1;
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

    }
}
