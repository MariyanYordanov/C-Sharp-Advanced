using System;

namespace ExamPreparationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n,n];
            int officerRowPrev = 0;
            int officerColPrev = 0;
            int mirrorsRowOne = 0;
            int mirrorsColOne = 0;
            int mirrorsRowTwo = 0;
            int mirrorsColTwo = 0;
            int counterM = 0;
            for (int row = 0; row < n; row++)
            {
                char[] rows = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = rows[col];
                    if (armory[row,col] == 'A')
                    {
                        officerRowPrev = row;
                        officerColPrev = col;
                    }

                    if (armory[row, col] == 'M')
                    {
                        if (counterM == 0)
                        {
                            mirrorsRowOne = row;
                            mirrorsColOne = col;

                        }
                        else if(counterM == 1)
                        {
                            mirrorsRowTwo = row;
                            mirrorsColTwo = col;
                        }

                        counterM++;
                    }
                }
            }

            int coins = 0;
            while (true)
            {
                string command = Console.ReadLine();
                int[] nextPositon = Move(command,officerRowPrev,officerColPrev);
                int officerRowNext = nextPositon[0];
                int officerColNext = nextPositon[1];
                if (!IsInArmory(armory, officerRowNext, officerColNext))
                {
                    armory[officerRowPrev, officerColPrev] = '-';
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                else
                {
                    if (Char.IsDigit(armory[officerRowNext, officerColNext]))
                    {
                        int digit = int.Parse(armory[officerRowNext, officerColNext].ToString());
                        coins += digit;
                    }
                    else if (counterM > 0)
                    {
                        if (armory[officerRowNext, officerColNext] == armory[mirrorsRowOne, mirrorsColOne])
                        {
                            armory[officerRowNext, officerColNext] = '-';
                            officerRowNext = mirrorsRowTwo;
                            officerColNext = mirrorsColTwo;
                        }
                        else if (armory[officerRowNext, officerColNext] == armory[mirrorsRowTwo, mirrorsColTwo])
                        {
                            armory[officerRowNext, officerColNext] = '-';
                            officerRowNext = mirrorsRowOne;
                            officerColNext = mirrorsColOne;
                        }
                    }
                }

                armory[officerRowPrev, officerColPrev] = '-';
                armory[officerRowNext, officerColNext] = 'A';
                officerRowPrev = officerRowNext;
                officerColPrev = officerColNext;

                if (coins >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }

            }

            Console.WriteLine($"The king paid {coins} gold coins.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInArmory(char[,] matrix, int row, int col)
            => row >= 0
            && row < matrix.GetLength(0)
            && col >= 0
            && col < matrix.GetLength(1);

        private static int[] Move(string command, int officerRowPrev, int officerColPrev)
        {
            
            int[] newPosition = new int[] { officerRowPrev, officerColPrev };
            if (command == "up")
            {
                newPosition = new int[] { officerRowPrev - 1, officerColPrev };
            }
            else if (command == "down")
            {
                newPosition = new int[] { officerRowPrev + 1, officerColPrev };
            }
            else if (command == "left")
            {
                newPosition = new int[] { officerRowPrev, officerColPrev - 1 };
            }
            else if (command == "right")
            {
                newPosition = new int[]{ officerRowPrev, officerColPrev + 1 };
            }

            return newPosition;
        }
    }
}
