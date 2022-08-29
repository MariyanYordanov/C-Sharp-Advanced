using System;

namespace Pawn
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            for (int row = 0; row < 8; row++)
            {
                char[] rows = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rows.Length; col++)
                {
                    board[row, col] = rows[col];
                    if (board[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (board[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            
            while (true)
            {
                if (IsInRange(board, whiteCol - 1) && board[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    board[whiteRow - 1, whiteCol - 1] = 'w';
                    board[whiteRow, whiteCol] = '-';
                    Console.WriteLine($"Game over! White capture on {Coordinates(blackRow, blackCol)}.");
                    break;
                }

                if (IsInRange(board, whiteCol + 1) && board[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    board[whiteRow - 1, whiteCol + 1] = 'w';

                    Console.WriteLine($"Game over! White capture on {Coordinates(blackRow, blackCol)}.");
                    break;
                }

                int newWhiteRow = whiteRow - 1;
                board[newWhiteRow, whiteCol] = 'w';
                board[whiteRow, whiteCol] = '-';

                if (newWhiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {Coordinates(whiteRow - 1, whiteCol)}.");
                    break;
                }

                if (IsInRange(board, blackCol - 1) && board[blackRow + 1, blackCol - 1] == 'w')
                {
                    board[blackRow + 1, blackCol - 1] = 'b';
                    board[blackRow, blackCol] = '-';
                    Console.WriteLine($"Game over! Black capture on {Coordinates(whiteRow - 1, whiteCol)}.");
                    break;
                }

                if (IsInRange(board, blackCol + 1) && board[blackRow + 1, blackCol + 1] == 'w')
                {
                    board[blackRow + 1, blackCol + 1] = 'b';
                    board[blackRow, blackCol] = '-';
                    Console.WriteLine($"Game over! Black capture on {Coordinates(whiteRow - 1, whiteCol)}.");
                    break;
                }

                int newBlackRow = blackRow + 1;
                board[newBlackRow, blackCol] = 'b';
                board[blackRow, blackCol] = '-';
                if (newBlackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {Coordinates(blackRow + 1, blackCol)}.");
                    break;
                }

                whiteRow = newWhiteRow;
                blackRow = newBlackRow;
            }

            //for (int row = 0; row < 8; row++)
            //{
            //    for (int col = 0; col < 8; col++)
            //    {
            //        Console.Write(board[row, col]);
            //    }

            //    Console.WriteLine();
            //}
        }
        
        private static string Coordinates(int row, int col)
        {
            char[] cols = new char[]{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char letterCol = cols[col];
            return $"{letterCol}{8 - row}";
        }

        public static bool IsInRange<T>(T[,] matrix, int col) => col >= 0 && col < matrix.GetLength(1);
    }
}
