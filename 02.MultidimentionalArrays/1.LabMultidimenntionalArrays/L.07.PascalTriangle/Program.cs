using System;

namespace L._07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] paskal= new long[n][];
            
            for (long row = 0; row < n; row++)
            {
                paskal[row] = new long[row + 1];
                paskal[row][0] = 1;
                paskal[row][^1] = 1;
                for (long col = 1; col < row; col++)
                {
                    paskal[row][col] = paskal[row - 1][col - 1] + paskal[row - 1][col];
                }
            }

            for (long row = 0; row < paskal.Length; row++)
            {
                for (long col = 0; col < paskal[row].Length; col++)
                {
                    Console.Write(paskal[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
