using System;
using System.Linq;

namespace Bee
{
    class Bee
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row, col] = cols[col];
                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int polinationed = 0;
            string tokens = Console.ReadLine();
            while (tokens != "End")
            {
                field[beeRow, beeCol] = '.';
                Move(ref beeRow, ref beeCol, tokens);

                if (!IsInRange(field,ref beeRow,ref beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (field[beeRow, beeCol] == 'O')
                {
                    field[beeRow, beeCol] = '.';
                    Move(ref beeRow, ref beeCol, tokens);
                }

                if (field[beeRow, beeCol] == 'f')
                {
                    polinationed++;
                }

                field[beeRow, beeCol] = 'B';
                tokens = Console.ReadLine();
            }

            if (polinationed < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, " +
                    $"she needed {5 - polinationed} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate " +
                    $"{polinationed} flowers!");
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


        private static void Move(ref int row,ref int col, string direction)
        {
            if (direction == "up")
            {
                row--;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "right")
            {
                col++;
            }
        }
        public static bool IsInRange<T>(T[,] matrix,ref int row,ref int col)
            => row >= 0
            && row < matrix.GetLength(0)
            && col >= 0
            && col < matrix.GetLength(1);
    }
}
