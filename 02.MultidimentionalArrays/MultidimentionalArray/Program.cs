using System;
using System.Threading;

namespace MultidimentionalArray
{
    class Snake
    {
        private readonly int Height = 40;
        private readonly int Width = 60;

        int[] X = new int[6];
        int[] Y = new int[6];

        int fruitX;
        int fruitY;

        int parts = 4;

        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();

        char key = 'W';

        string part = "♦";

        Random rnd = new Random();

        Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, Width - 2);
            fruitY = rnd.Next(2, Height - 2);
        } 
        public void Board()
        {
            //Console.Clear();
            //for (int i = 1; i <= Width + 2; i+=2)
            //{
            //    Console.SetCursorPosition(i, 1);
            //    Console.WriteLine("+");
            //}

            //for (int i = 1; i <= Width + 2; i += 2)
            //{
            //    Console.SetCursorPosition(i, Height + 2);
            //    Console.WriteLine("+");
            //}

            //for (int i = 1; i <= Height + 1; i++)
            //{
            //    Console.SetCursorPosition(1, i);
            //    Console.WriteLine("+");
            //}

            //for (int i = 1; i <= Height + 1; i++)
            //{
            //    Console.SetCursorPosition(Width + 2, i);
            //    Console.WriteLine("+");
            //}

        }

        public void Input() 
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                key = keyinfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(part);
        }

        public void Logic()
        {
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++;
                    fruitX = rnd.Next(2, Width - 2);
                    fruitY = rnd.Next(2, Height - 2);
                }

            }

            for (int i = parts; i > 1; i--)
            {
                
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }

            switch (key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < parts - 1; i++)
            {
                if (parts == X.Length - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                   GAME OVER!");
                    Console.WriteLine();
                    Console.WriteLine("                                    YOU WIN!");
                    
                    Thread.Sleep(100);
                    return;
                }
                WritePoint(X[i],Y[i]);
                WritePoint(fruitX,fruitY);
            }

           
            Thread.Sleep(130);
        }
        static void Main(string[] args)
        {
            Snake snake = new();
            while (true)
            {
                //snake.Board();
                Console.Clear();
                snake.Input();
                snake.Logic();
            }

            //Console.ReadKey();
        }

        
    }
}
