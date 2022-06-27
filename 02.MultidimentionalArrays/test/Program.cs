using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // read param of materix and implement new matrix
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] lair = new char[rows, cols];

            // add player coordinates
            int[] playerCoordenates = new int[2];

            // hold all bunnys together
            List<int[]> bunnys = new List<int[]>();

            for (int row = 0; row < rows; row++)
            {
                // add element in matrix
                string inputCols = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    // find player coordinats
                    lair[row, col] = inputCols[col];
                    if (lair[row, col] == 'P')
                    {
                        playerCoordenates[0] = row;
                        playerCoordenates[1] = col;
                    }

                    // find bunny coordinats and add them in List
                    if (lair[row, col] == 'B')
                    {
                        bunnys.Add(new int[] { row, col });
                    }
                }
            }

            string inputStr = Console.ReadLine();
            // spread the bunnys
            for (int i = 0; i < inputStr.Length; i++)
            {
                for (int bunny = 0; bunny < bunnys.Count; bunny++)
                {
                    // validate bunnys coordinates
                    if (IsIndexValid(lair, bunnys[bunny][0] - 1, bunnys[bunny][1]))
                    {
                        lair[bunnys[bunny][0] - 1, bunnys[bunny][1]] = 'B';
                    }
                    if (IsIndexValid(lair, bunnys[bunny][0] + 1, bunnys[bunny][1]))
                    {
                        lair[bunnys[bunny][0] + 1, bunnys[bunny][1]] = 'B';
                    }
                    if (IsIndexValid(lair, bunnys[bunny][0], bunnys[bunny][1] + 1))
                    {
                        lair[bunnys[bunny][0], bunnys[bunny][1] + 1] = 'B';
                    }
                    if (IsIndexValid(lair, bunnys[bunny][0], bunnys[bunny][1] - 1))
                    {
                        lair[bunnys[bunny][0], bunnys[bunny][1] - 1] = 'B';
                    }


                    // print the matrix
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{lair[row, col]}");
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine("++++++++++++++++++++++++++++");
                }
            }
        }

        private static bool IsIndexValid(char[,] field, int row, int col)
        {
            return row >= 0 && col >= 0 && row < field.GetLength(0) && col < field.GetLength(1);
        }


    }
}
