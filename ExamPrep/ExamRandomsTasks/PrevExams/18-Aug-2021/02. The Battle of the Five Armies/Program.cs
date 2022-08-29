using System;

namespace _02._The_Battle_of_the_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            int heroRow = 0;
            int heroCol = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                map[row] = rowInput;
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] == 'A')
                    {
                        heroRow = row;
                        heroCol = col;
                    }
                }
            }
            
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string move = commands[0];
                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);
                armor--;
                map[enemyRow][enemyCol] = 'O'; 
                map[heroRow][heroCol] = '-';
                if (move == "up" && heroRow - 1 >= 0)
                {
                    heroRow--;
                }
                else if (move == "down" && heroRow + 1 < rows)
                {
                    heroRow++;
                }
                else if (move == "left" && heroCol - 1 >= 0)
                {
                    heroCol--;
                }
                else if (move == "right" && heroCol + 1 < map[heroRow].Length)
                {
                    heroCol++;
                }

                if (map[heroRow][heroCol] == 'O')
                {
                    armor -= 2;
                }

                if (map[heroRow][heroCol] == 'M')
                {
                    map[heroRow][heroCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    map[heroRow][heroCol] = 'X';
                    Console.WriteLine($"The army was defeated at {heroRow};{heroCol}.");
                    break;
                }

                map[heroRow][heroCol] = 'A';
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(new string(map[row]));
            }
        }

    }
}
