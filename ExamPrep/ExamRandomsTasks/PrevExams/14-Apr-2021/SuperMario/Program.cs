using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lifes = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int marioRow = 0;
            int marioCol = 0;
            char[][] field = new char[n][];
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                field[row] = new char[cols.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row][col] = cols[row];
                    if (field[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }


            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0];
                int bowserRow = int.Parse(commands[1]);
                int bowserCol = int.Parse(commands[2]);
                field[bowserRow][bowserCol] = 'B';
                field[marioRow][marioCol] = '-';
                lifes--;
                if (direction == "W" && marioRow - 1 >= 0)
                {
                    marioRow--;
                }
                else if (direction == "S" && marioRow + 1 < field.GetLength(0))
                {
                    marioRow++;
                }
                else if (direction == "A" && marioCol - 1 >= 0 )
                {
                    marioCol--;
                }
                else if (direction == "D" && marioCol + 1 < field.GetLength(1))
                {
                    marioCol++;
                }

                if (field[marioRow][marioCol] == 'B')
                {
                    lifes -= 2;
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lifes}");
                    break;
                }
                if (lifes <= 0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }


                field[marioRow][marioCol] = 'M';
            }

            foreach (var line in field)
            {
                string currentLine = string.Join("", line);
                Console.WriteLine(currentLine);
            }
        }
    }
}
