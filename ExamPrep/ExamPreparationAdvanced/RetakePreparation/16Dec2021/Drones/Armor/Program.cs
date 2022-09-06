using System;

namespace Armor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] armory = new char[n, n];
            int officerRow = 0;
            int officerCol = 0;

            int mirrorFirstRow = 0;
            int mirrorFirstCol = 0;

            int mirrorSecondRow = 0;
            int mirrorSecondCol = 0;

            int counterMirrors = 0;
            ReadMatrixAndFindOfficerAndMirrors(
                armory,
                ref officerRow,
                ref officerCol,
                ref mirrorFirstRow,
                ref mirrorFirstCol, 
                ref mirrorSecondRow,
                ref mirrorSecondCol,
                ref counterMirrors);

            int sumSwords = 0;
            
            while (sumSwords < 65)
            {
                string direction = Console.ReadLine();

                armory[officerRow, officerCol] = '-';

                Move(ref officerRow, ref officerCol, ref direction);
                if (!IsMatrixInRange(ref armory, ref officerRow, ref officerCol))
                {
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {sumSwords} gold coins.");
                    PrintMatrix(ref armory);
                    return;
                }

                if (armory[officerRow, officerCol] == 'M')
                {
                    armory[officerRow, officerCol] = '-';
                    if (officerRow == mirrorFirstRow && officerCol == mirrorFirstCol)
                    {
                        officerRow = mirrorSecondRow;
                        officerCol = mirrorSecondCol;
                    }
                    else if (officerRow == mirrorSecondRow && officerCol == mirrorSecondCol)
                    {
                        officerRow = mirrorFirstRow;
                        officerCol = mirrorFirstCol;
                    }

                }

                if (Char.IsDigit(armory[officerRow, officerCol]))
                {
                    int price = int.Parse(armory[officerRow, officerCol].ToString());
                    sumSwords += price;
                }

                armory[officerRow, officerCol] = 'A';
            }

            Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {sumSwords} gold coins.");

            PrintMatrix(ref armory);
        }

        private static void PrintMatrix(ref char[,] matrix)
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

        private static void ReadMatrixAndFindOfficerAndMirrors(char[,] armory, ref int officerRow, ref int officerCol, ref int mirrorFirstRow, ref int mirrorFirstCol, ref int mirrorSecondRow, ref int mirrorSecondCol, ref int counterMirrors)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = line[col];
                    if (armory[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }

                    if (armory[row, col] == 'M')
                    {

                        if (counterMirrors == 0)
                        {
                            mirrorFirstRow = row;
                            mirrorFirstCol = col;
                            counterMirrors++;
                        }
                        else
                        {
                            mirrorSecondRow = row;
                            mirrorSecondCol = col;
                        }
                    }


                }
            }
        }

        private static void Move(ref int row, ref int col, ref string direction)
        {
            if (direction == "up")
            {
                row -= 1;
            }
            else if (direction == "down")
            {
                row += 1;
            }
            else if (direction == "left")
            {
                col -= 1;
            }
            else if (direction == "right")
            {
                col += 1;
            }
        }

        private static bool IsMatrixInRange(ref char[,] matrix, ref int row, ref int col)
                   => row >= 0
                   && row < matrix.GetLength(0)
                   && col >= 0
                   && col < matrix.GetLength(1);
    }
}
