using System;
using System.Linq;

namespace Selling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int playerRow = 0;
            int playerCol = 0;
            int firstPillarRow = -1;
            int firstPillarCol = -1;
            int secondPillarRow = -1;
            int secondPillarCol = -1;
            int counter = 1;
            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row, col] = cols[col];
                    if (field[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (field[row, col] == 'O')
                    {
                        if (counter == 1)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            secondPillarRow = row;
                            secondPillarCol = col;
                        }
                    }
                }
            }

            string direction = Console.ReadLine();
            int sumMoney = 0;
            while (true)
            {
                field[playerRow, playerCol] = '-';
                Move(ref playerRow,ref playerCol,direction);
                if (!IsInRange(field, ref playerRow, ref playerCol))
                {
                    break;
                }

                if (Char.IsDigit(field[playerRow, playerCol]))
                {
                    int money = int.Parse(field[playerRow, playerCol].ToString());
                    sumMoney += money;
                    if (sumMoney >= 50)
                    {
                        field[playerRow, playerCol] = 'S';
                        break;
                    }
                }

                if (IsInRange(field, ref firstPillarRow, ref firstPillarCol) && field[playerRow, playerCol] == 'O')
                {
                    field[firstPillarRow, firstPillarCol] = '-';
                    field[secondPillarRow, secondPillarCol] = '-';
                    if (field[firstPillarRow, firstPillarCol] == field[playerRow, playerCol])
                    {
                        playerRow = secondPillarRow;
                        playerCol = secondPillarCol;
                    }
                    else if (field[secondPillarRow, secondPillarCol] == field[playerRow, playerCol])
                    {
                        playerRow = firstPillarRow;
                        playerCol = firstPillarCol;
                    }
                }

                field[playerRow, playerCol] = 'S';
                direction = Console.ReadLine();
            }

            if (sumMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {sumMoney}");

            PrintMatrix(field);
        }


        private static void Move(ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "up")
            {
                playerRow--;
            }
            else if (direction == "down")
            {
                playerRow++;
            }
            else if (direction == "left")
            {
                playerCol--;
            }
            else if (direction == "right")
            {
                playerCol++;
            }
        }


        public static bool IsInRange<T>(T[,] matrix, ref int playerRow, ref int playerCol)
            => playerRow >= 0
            && playerRow < matrix.GetLength(0)
            && playerCol >= 0
            && playerCol < matrix.GetLength(1);

        public static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
