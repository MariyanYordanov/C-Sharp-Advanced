using System;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] cols = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            int wildBoarTruffle = 0;
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string leddCommand = token[0];
                if (leddCommand == "Collect")
                {
                    int ReterRow = int.Parse(token[1]);
                    int ReterCol = int.Parse(token[2]);
                    if (matrix[ReterRow, ReterCol] == 'B')
                    {
                        blackTruffle++;
                    }
                    else if (matrix[ReterRow, ReterCol] == 'S')
                    {
                        summerTruffle++;
                    }
                    else if (matrix[ReterRow, ReterCol] == 'W')
                    {
                        whiteTruffle++;
                    }

                    matrix[ReterRow, ReterCol] = '-';
                }
                else if (leddCommand == "Wild_Boar")
                {
                    int boarRow = int.Parse(token[1]);
                    int boarCol = int.Parse(token[2]);
                    string direction = token[3];
                    if (direction == "up")
                    {
                        for (int i = boarRow; i >= 0; i -= 2)
                        {
                            if (matrix[i, boarCol] == 'B'
                                || matrix[i, boarCol] == 'W'
                                || matrix[i, boarCol] == 'S')
                            {
                                wildBoarTruffle++;
                                matrix[i, boarCol] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = boarRow; i < matrix.GetLength(0); i+=2)
                        {
                            if (matrix[i,boarCol] == 'B'
                                || matrix[i, boarCol] == 'W'
                                || matrix[i, boarCol] == 'S')
                            {
                                wildBoarTruffle++;
                                matrix[i, boarCol] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = boarCol; i >= 0; i-=2)
                        {
                            if (matrix[boarRow, i] == 'B'
                                || matrix[boarRow, i] == 'W'
                                || matrix[boarRow, i] == 'S')
                            {
                                wildBoarTruffle++;
                                matrix[boarRow, i] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = boarCol; i < matrix.GetLength(1); i += 2)
                        {
                            if (matrix[boarRow, i] == 'B'
                                || matrix[boarRow, i] == 'W'
                                || matrix[boarRow, i] == 'S')
                            {
                                wildBoarTruffle++;
                                matrix[boarRow, i] = '-';
                            }
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black," +
                $" {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffle} truffles.");


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
