using System;
using System.Collections.Generic;
using System.Linq;

namespace ReVolt
{
    class ReVolt
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row, col] = cols[col];
                    if (field[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
           
            bool isWon = false;
            for (int i = 0; i < m; i++)
            {
                string direction = Console.ReadLine();
                field[playerRow, playerCol] = '-';
                if (direction == "up")
                {
                    playerRow -= 1;
                    if (playerRow < 0)
                    {
                        playerRow = field.GetLength(0) - 1;
                    }

                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerRow -= 1;
                        continue;
                    }

                    if (field[playerRow, playerCol] == 'B')
                    {
                        while (field[playerRow, playerCol] == 'B')
                        {
                            playerRow -= 1;
                            if (playerRow < 0)
                            {
                                playerRow = field.GetLength(0) - 1;
                            }
                        }
                    }
                }
                else if (direction == "down")
                {
                    playerRow += 1;
                    if (playerRow > field.GetLength(0) - 1)
                    {
                        playerRow = 0;
                    }

                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerRow -= 1;
                        continue;
                    }

                    if (field[playerRow, playerCol] == 'B')
                    {
                        while (field[playerRow, playerCol] == 'B')
                        {
                            playerRow += 1;
                            if (playerRow > field.GetLength(0) - 1)
                            {
                                playerRow = 0;
                            }
                        }
                    }
                }
                else if (direction == "left")
                {
                    playerCol -= 1;
                    if (playerCol < 0)
                    {
                        playerCol = field.GetLength(1) - 1;
                    }

                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerCol += 1;
                        continue;
                    }

                    if (field[playerRow, playerCol] == 'B')
                    {
                        while (field[playerRow, playerCol] == 'B')
                        {
                            playerCol -= 1;
                            if (playerCol < 0)
                            {
                                playerCol = field.GetLength(0) - 1;
                            }
                        }
                    }
                }
                else if (direction == "right")
                {
                    playerCol += 1;
                    if (playerCol > field.GetLength(1) - 1)
                    {
                        playerCol = 0;
                    }

                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerCol -= 1;
                        continue;
                    }

                    if (field[playerRow, playerCol] == 'B')
                    {
                        while (field[playerRow, playerCol] == 'B')
                        {
                            playerCol += 1;
                            if (playerCol > field.GetLength(1) - 1)
                            {
                                playerCol = 0;
                            }
                        }
                    }
                }

                if (field[playerRow, playerCol] == 'F')
                {
                    isWon = true;
                    field[playerRow, playerCol] = 'f';
                    break;
                }

                field[playerRow, playerCol] = 'f';
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
