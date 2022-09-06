using System;
using System.Collections.Generic;
using System.Linq;

namespace Biver
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int beaverRow = 0;
            int beaverCol = 0;

            int counterBranches = 0;
            int collectBranches = 0;
            ReadInputAndFindBeaver(ref pond, ref beaverRow, ref beaverCol,ref counterBranches);

            Stack<char> branch = new Stack<char>();
            string direction = Console.ReadLine();
            while (direction != "end")
            {
                pond[beaverRow, beaverCol] = '-';
                Move(ref beaverRow, ref beaverCol, ref direction);
                if (!IsMatrixInRange(ref pond, ref beaverRow, ref beaverCol) )
                {
                    BackwardMove(ref beaverRow, ref beaverCol, ref direction);
                    if (branch.Count > 0)
                    {
                        branch.Pop();
                    }
                }
                else
                {
                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';

                        if (beaverRow < pond.GetLength(0) - 1)
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                        else if (beaverCol < pond.GetLength(1) - 1)
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }
                        else if (beaverRow == pond.GetLength(0) - 1)
                        {
                            beaverRow = 0;
                        }
                        else if (beaverRow == 0)
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                        else if (beaverCol == pond.GetLength(1) - 1)
                        {
                            beaverCol = 0;
                        }
                        else if (beaverCol == 0)
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }

                        if (Char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branch.Push(pond[beaverRow, beaverCol]);
                            collectBranches++;
                        }
                    }

                    if (Char.IsLower(pond[beaverRow, beaverCol]))
                    {
                        branch.Push(pond[beaverRow, beaverCol]);
                        collectBranches++;
                    }
                }

                
                pond[beaverRow, beaverCol] = 'B';

                if (counterBranches == collectBranches)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (counterBranches == collectBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branch.Count} wood branches: {string.Join(", ",branch.OrderBy(x => x))}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch." +
                    $" There are {counterBranches - collectBranches} branches left.");
            }

            PrintMatrix(ref pond);
        }

        private static void ReadInputAndFindBeaver(
            ref char[,] pond, ref int beaverRow, ref int beaverCol, ref int count)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] cols = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = cols[col];
                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (Char.IsLower(pond[row, col]))
                    {
                        count++;
                    }
                }
            }
        }
        private static void Move(ref int row,ref int col,ref string direction)
        {
            if (direction == "up")
            {
                row -= 1;
            }
            else if (direction == "down")
            {
                row += 1;
            }
            else if (direction == "left")
            {
                col -= 1;
            }
            else if (direction == "right")
            {
                col += 1;
            }
        }
        public static bool IsMatrixInRange(ref char [,] matrix,ref int row,ref int col)
                   => row >= 0
                   && row < matrix.GetLength(0)
                   && col >= 0
                   && col < matrix.GetLength(1);
        private static void BackwardMove(ref int playerRow, ref int playerCol,ref string direction)
        {
            if (direction == "up")
            {
                playerRow += 1;
            }
            else if (direction == "down")
            {
                playerRow -= 1;
            }
            else if (direction == "left")
            {
                playerCol += 1;
            }
            else if (direction == "right")
            {
                playerCol -= 1;
            }
        }
        private static void PrintMatrix(ref char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
