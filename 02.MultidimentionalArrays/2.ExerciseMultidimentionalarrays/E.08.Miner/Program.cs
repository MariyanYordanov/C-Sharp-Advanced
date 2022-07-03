using System;
using System.Linq;

namespace E._09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[fieldSize, fieldSize];
            LoadMartix(field, fieldSize);
            int colection = FindCoal(field);
            int[] start = FindStart(field);
            int[] currentPosotion = new int[2] { start[0], start[1] };
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    currentPosotion[0] -= 1;
                    if (!IsIndexValid(field, currentPosotion[0]))
                    {
                        currentPosotion[0] += 1;
                    };
                }
                else if (commands[i] == "right")
                {
                    currentPosotion[1] += 1;
                    if (!IsIndexValid(field, currentPosotion[1]))
                    {
                        currentPosotion[1] -= 1;
                    };
                }
                else if (commands[i] == "down")
                {
                    currentPosotion[0] += 1;
                    if (!IsIndexValid(field, currentPosotion[0]))
                    {
                        currentPosotion[0] -= 1;
                    };
                }
                else if (commands[i] == "left")
                {
                    currentPosotion[1] -= 1;
                    if (!IsIndexValid(field, currentPosotion[1]))
                    {
                        currentPosotion[1] += 1;
                    };
                }
                
                if (field[currentPosotion[0], currentPosotion[1]] == 'c')
                {
                    colection--;
                    field[currentPosotion[0], currentPosotion[1]] = '*';
                    if (colection == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentPosotion[0]}, {currentPosotion[1]})");
                        return;
                    }
                }
                else if (field[currentPosotion[0], currentPosotion[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentPosotion[0]}, {currentPosotion[1]})");
                    return;
                }
                
            }

            Console.WriteLine($"{colection} coals left. ({currentPosotion[0]}, {currentPosotion[1]})");
        }

        private static int FindCoal(char[,] field)
        {
            int coal = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'c')
                    {
                        coal++;
                    }
                }
            }

            return coal;
        }

        private static bool IsIndexValid(char[,] field, int currentPosotion)
        {
            return currentPosotion >= 0 && currentPosotion < field.GetLength(0);
        } 

        private static int[] FindStart(char[,] field)
        {
            int[] start = new int[2];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    if (field[row,col] == 's')
                    {
                        start[0] = row;
                        start[1] = col;
                    }
                }
            }

            return start;
        }

        private static void LoadMartix(char[,] field, int fieldSize)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputRow[col];
                }
            }
        }

    }
}
