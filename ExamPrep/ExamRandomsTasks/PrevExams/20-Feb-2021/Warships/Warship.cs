using System;
using System.Linq;

namespace Warships
{
    class Warship
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] stringElements = Console.ReadLine().Split(",",
                StringSplitOptions.RemoveEmptyEntries);
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().Replace(" ","").ToCharArray();
                for (int col = 0; col < cols.Length; col++)
                {
                    field[row, col] = cols[col];
                    if (field[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int totalCountShipsDestroyed = 0;
            for (int i = 0; i < stringElements.Length; i++)
            {
                string[] coordinates = stringElements[i].Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(coordinates[0]);
                int attackCol = int.Parse(coordinates[1]);
                if (attackRow < 0 || attackCol < 0 || attackRow >= n || attackCol >= n)
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '#')
                {
                    field[attackRow, attackCol] = 'X';
                    bool isZero = false;
                    for (int j = attackRow - 1; j <= attackRow + 1; j++)
                    {
                        for (int k = attackCol - 1; k <= attackCol + 1; k++)
                        {
                            if (j >= 0 && k >= 0 && j < n && k < n)
                            {
                                if (field[j, k] == '<')
                                {
                                    field[j, k] = 'X';
                                    firstPlayerShips--;
                                    totalCountShipsDestroyed++;
                                }
                                else if (field[j, k] == '>')
                                {
                                    field[j, k] = 'X';
                                    secondPlayerShips--;
                                    totalCountShipsDestroyed++;
                                }

                                if (firstPlayerShips == 0 || secondPlayerShips == 0)
                                {
                                    isZero = true;
                                    
                                }
                            }
                        }

                        if (isZero)
                        {
                            break;
                        }
                    }
                }
                else if (field[attackRow, attackCol] == '<')
                {
                    firstPlayerShips--;
                    totalCountShipsDestroyed++;
                    field[attackRow, attackCol] = 'X';
                    if (firstPlayerShips == 0)
                    {
                        Console.WriteLine($"Player Two has won the game! " +
                            $"{totalCountShipsDestroyed} ships have been sunk in the battle.");
                        return;
                    }
                }
                else if (field[attackRow, attackCol] == '>')
                {
                    secondPlayerShips--;
                    totalCountShipsDestroyed++;
                    field[attackRow, attackCol] = 'X';
                    if (secondPlayerShips == 0)
                    {
                        Console.WriteLine($"Player One has won the game! " +
                            $"{totalCountShipsDestroyed} ships have been sunk in the battle.");
                        return;
                    }
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left." +
                $" Player Two has {secondPlayerShips} ships left.");
        }
    }
}
