using System;
using System.Linq;

namespace E._06._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];
            for (int row = 0; row < n; row++)
            {
                double[] rowsInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedMatrix[row] = new double[rowsInput.Length];
                for (int col = 0; col < rowsInput.Length; col++)
                {
                    jaggedMatrix[row][col] = rowsInput[col];
                }
            }

            for (int row = 0; row < n - 1; row++)
            {
                int counter = 0;
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                    {
                        jaggedMatrix[row][col] *= 2;
                        jaggedMatrix[row + 1][col] *= 2;
                    }
                    else
                    {
                        jaggedMatrix[row][col] /= 2;
                        if (counter < 1)
                        {
                            for (int i = 0; i < jaggedMatrix[row + 1].Length; i++)
                            {
                                jaggedMatrix[row + 1][i] /= 2;
                            }
                            counter++;
                        }
                    }
                }
            }

            string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "End")
            {
                int rows = int.Parse(commands[1]);
                int column = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (rows >= 0 && column >= 0 && rows < n && column < jaggedMatrix[rows].Length)
                {
                    if (commands[0] == "Add")
                    {
                        jaggedMatrix[rows][column] += value;
                    }
                    else if (commands[0] == "Subtract")
                    {
                        jaggedMatrix[rows][column] -= value;
                    }
                }

                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (commands[0] == "End")
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        Console.Write($"{jaggedMatrix[row][col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
