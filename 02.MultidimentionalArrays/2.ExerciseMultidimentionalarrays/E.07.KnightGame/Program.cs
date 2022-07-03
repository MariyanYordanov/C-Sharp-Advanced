using System;

namespace E._07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = rowInput[col];
                }
            }

            int strikeRow = 0;
            int strikeCol = 0;
            int toRemove = 0;
            while (true)
            {
                int maxStrike = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int strike = 0;
                        if (board[row, col] == '0')
                        {
                            continue;
                        }
                        if (board[row, col] == 'K')
                        {

                            if (IsInRange(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                strike++;
                            }

                            if (IsInRange(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                strike++;
                            }

                        }

                        if (strike > maxStrike)
                        {
                            maxStrike = strike;
                            strikeRow = row;
                            strikeCol = col;
                        }
                    }
                }

                if (maxStrike > 0 )
                {
                    toRemove++;
                    board[strikeRow, strikeCol] = '0';
                }
                else
                {
                    Console.WriteLine(toRemove);
                    break;
                }
            }
        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && col >= 0 && row < board.GetLength(0) && col < board.GetLength(1);
        }
    }
}
