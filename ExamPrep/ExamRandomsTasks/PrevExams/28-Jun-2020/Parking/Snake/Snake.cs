using System;
using System.Linq;

namespace Snake
{
    class Snake
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeCol = 0;
            int burrowFirstRow = -1;
            int burrowFirstCol = -1;
            int burrowSecondRow = -1;
            int burrowSecondCol = -1;
            int counterBurrow = 0;
            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row, col] = cols[col];
                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (field[row, col] == 'B')
                    {
                        if (counterBurrow == 0)
                        {
                            burrowFirstRow = row;
                            burrowFirstCol = col;
                            counterBurrow++;
                        }
                        else
                        {
                            burrowSecondRow = row;
                            burrowSecondCol = col;
                        }
                    }
                }
            }

            int foodQuantity = 0;
            while (true)
            {
                string direction = Console.ReadLine();
                field[snakeRow, snakeCol] = '.';
                Move(ref snakeRow, ref snakeCol, direction);
                if (!IsInRange(field, ref snakeRow,ref snakeCol))
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodQuantity}");
                    break;
                }

                if (field[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }

                if (foodQuantity == 10)
                {
                    field[snakeRow, snakeCol] = 'S';
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodQuantity}");
                    break;
                }

                if (field[snakeRow, snakeCol] == 'B')
                {
                    field[burrowFirstRow, burrowFirstCol] = '.';
                    field[burrowSecondRow, burrowSecondCol] = '.';
                    if (field[snakeRow, snakeCol] == field[burrowFirstRow, burrowFirstCol])
                    {
                        snakeRow = burrowSecondRow;
                        snakeCol = burrowSecondCol;
                    }
                    else
                    {
                        snakeRow = burrowFirstRow;
                        snakeCol = burrowFirstCol;
                    }
                }

                field[snakeRow, snakeCol] = 'S';
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
