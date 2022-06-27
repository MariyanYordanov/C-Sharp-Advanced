using System;
using System.Linq;

namespace MatrixExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 4;
            int col = 2;
            int[][] jagg = new int[row][col];
            jagg[row] = new int[col];
            printInSpiral(jagg, row, col);
        }

        void printInSpiral(int[][] array,int numRows, int numCols)
        {
            int dir[4][2] = new int{ { 0, 1}, { 1, 0}, { 0, -1}, { -1, 0} };
            int row = 0, col = -1, idx = 0;
            while (numRows > 0 && numCols > 0)
            {
                int numCells = (idx % 2 == 0) ? numRows : numCols;
                for (int i = 0; i < numCells; i++)
                {
                    row += dir[idx][0], col += dir[idx][1];
                    fprintf(stdout, "%d\n", array[row][col]);
                }
                if (idx % 2) numCols--; else numRows--;
                idx = (idx + 1) % 4;
            }
        }
        public static void PrintMatrix<T>(T[,] matrix)
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
    }
}
