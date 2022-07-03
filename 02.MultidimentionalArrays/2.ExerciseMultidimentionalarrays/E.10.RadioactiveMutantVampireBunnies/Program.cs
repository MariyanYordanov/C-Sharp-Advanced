using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            // read p0aram of materix and implement new matrix
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

            // read input commands
            string commands = Console.ReadLine();

            // add next move player coordinates
            int[] nextPlayerCoordinates = new int[2];
            nextPlayerCoordinates[0] = playerCoordenates[0];
            nextPlayerCoordinates[1] = playerCoordenates[1];
            bool isDead = false;
            for (int i = 0; i < commands.Length; i++)
            {
                // spread the bunnys
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
                }

                // add new bunnys
                bunnys = FindBunnys(lair);

                // make move 
                if (commands[i] == 'L')
                {
                    nextPlayerCoordinates[1] = playerCoordenates[1] - 1;
                }
                else if (commands[i] == 'U')
                {
                    nextPlayerCoordinates[0] = playerCoordenates[0] - 1;
                }
                else if (commands[i] == 'R')
                {
                    nextPlayerCoordinates[1] = playerCoordenates[1] + 1;
                }
                else if (commands[i] == 'D')
                {
                    nextPlayerCoordinates[0] = playerCoordenates[0] + 1;
                }

                // validate coordinates 
                if (IsIndexValid(lair, nextPlayerCoordinates[0], nextPlayerCoordinates[1]))
                {
                    // change field's chars
                    lair[playerCoordenates[0], playerCoordenates[1]] = '.';

                    // check for bunnys
                    if (lair[nextPlayerCoordinates[0], nextPlayerCoordinates[1]] == 'B')
                    {
                        // the player is dead
                        lair[playerCoordenates[0], playerCoordenates[1]] = 'B';
                        isDead = true;
                        break;
                    }
                    else
                    {
                        lair[nextPlayerCoordinates[0], nextPlayerCoordinates[1]] = 'P';
                    }

                }
                else
                {
                    // the player win
                    lair[playerCoordenates[0], playerCoordenates[1]] = '.';
                    isDead = false;
                    break;
                }

                // rewrite coordinates
                if (commands[i] == 'L' || commands[i] == 'R')
                {
                    playerCoordenates[1] = nextPlayerCoordinates[1];
                }
                else
                {
                    playerCoordenates[0] = nextPlayerCoordinates[0];
                }

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

            if (isDead)
            {
                Console.WriteLine($"dead: {nextPlayerCoordinates[0]} {nextPlayerCoordinates[1]}");
            }
            else
            {
                Console.WriteLine($"won: {playerCoordenates[0]} {playerCoordenates[1]}");
            }

        }

        private static bool IsIndexValid(char[,] field, int row, int col)
        {
            return row >= 0 && col >= 0 && row < field.GetLength(0) && col < field.GetLength(1);
        }

        private static List<int[]> FindBunnys(char[,] lair)
        {
            List<int[]> newBunnys = new List<int[]>();
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        newBunnys.Add(new int[] { row, col });
                    }
                }
            }

            return newBunnys;
        }
    }
}
