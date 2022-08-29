using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] cols = Console.ReadLine().Replace(" ", "").ToCharArray();
                beach[row] = cols;
            }

            int myCollection = 0;
            int hisCollection = 0;
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string leedCommand = commands[0];
                if (leedCommand == "Find")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    myCollection = AddToCollection(beach, myCollection, row, col);
                }
                else if (leedCommand == "Opponent")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    string direction = commands[3];
                    if (IsCoordinatesInRange(row, col, beach))
                    {
                        hisCollection = AddToCollection(beach, hisCollection, row, col);
                        for (int i = 0; i < 3; i++)
                        {
                            if (direction == "up")
                            {
                                row -= 1;
                                hisCollection = AddToCollection(beach, hisCollection, row, col);
                            }
                            else if (direction == "down")
                            {
                                row += 1;
                                hisCollection = AddToCollection(beach, hisCollection, row, col);
                            }
                            else if (direction == "left")
                            {
                                col -= 1;
                                hisCollection = AddToCollection(beach, hisCollection, row, col);
                            }
                            else if (direction == "right")
                            {
                                col += 1;
                                hisCollection = AddToCollection(beach, hisCollection, row, col);
                            }
                        }
                    }
                    
                }
                else if (leedCommand == "Gong")
                {
                    break;
                }
            }

            PrintMatrix(beach);

            Console.WriteLine($"Collected tokens: {myCollection}");
            Console.WriteLine($"Opponent's tokens: {hisCollection}");
        }

        public static int AddToCollection(char[][] jagg, int collection, int row, int col)
        {
            if (IsCoordinatesInRange(row, col, jagg) && jagg[row][col] == 'T')
            {
                jagg[row][col] = '-';
                collection++;
            }

            return collection;
        }

        public static void PrintMatrix<T>(T[][] matrix)
        {
            foreach (var line in matrix)
            {
                string currentLine = string.Join(' ', line);
                Console.WriteLine(currentLine);
            }
        }

        public static bool IsCoordinatesInRange<T>(int row, int col, T[][] jagg) 
            => row >= 0 
            && col >= 0 
            && row < jagg.Length 
            && col < jagg[row].Length;
    }
}
