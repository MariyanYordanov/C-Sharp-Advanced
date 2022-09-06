using System;
using System.Linq;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = 0;
            int playerCol = 0;
            ReadMatrixAndFindPlayer(matrix, ref playerRow, ref playerCol);

            for (int i = 0; i < commands; i++)
            {
                string direction = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                Move(ref playerRow, ref playerCol, direction);
                ReturnInTheMatrix(matrix, ref playerRow, ref playerCol);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    Move(ref playerRow, ref playerCol, direction);
                    ReturnInTheMatrix(matrix, ref playerRow, ref playerCol);
                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    BackwardMove(ref playerRow, ref playerCol, direction);
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }

                matrix[playerRow, playerCol] = 'f';
                //PrintMatrix(matrix);// to remove after compilation in Judje
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        private static void BackwardMove(ref int playerRow, ref int playerCol, string direction)
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

        private static void ReturnInTheMatrix(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow == matrix.GetLength(0))
            {
                playerRow = 0;
            }
            else if (playerRow < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (playerCol == matrix.GetLength(1))
            {
                playerCol = 0;
            }
            else if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static void ReadMatrixAndFindPlayer(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        private static void Move(ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "up")
            {
                playerRow -= 1;
            }
            else if (direction == "down")
            {
                playerRow += 1;
            }
            else if (direction == "left")
            {
                playerCol -= 1;
            }
            else if (direction == "right")
            {
                playerCol += 1;
            }
        }
    }
}
