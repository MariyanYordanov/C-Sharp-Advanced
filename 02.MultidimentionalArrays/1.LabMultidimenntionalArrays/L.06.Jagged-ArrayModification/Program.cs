using System;
using System.Linq;

namespace L._06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagg = new int[n][];
            for (int row = 0; row < jagg.Length; row++)
            {
                int[] inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagg[row] = new int[inputRow.Length];
                for (int col = 0; col < jagg[row].Length; col++)
                {
                    jagg[row][col] = inputRow[col];
                }
            }

            string[] command = Console.ReadLine().Split(); 
            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row < 0 || col < 0 || row > jagg.Length - 1 || col > jagg.Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        jagg[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagg[row][col] -= value;
                    }
                }
                
                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jagg.Length; row++)
            {
                for (int col = 0; col < jagg[row].Length; col++)
                {
                    Console.Write(jagg[row][ col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
