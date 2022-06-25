using System;
using System.Collections.Generic;
using System.Linq;

namespace E._10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            int counter = 0;
            while (input != "END")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int temp = seconds;

                if (input == "green")
                {
                    while (temp > 0 && queue.Count() > 0)
                    {
                        string lastPassedCar = queue.Dequeue(); 

                        if (temp - lastPassedCar.Length >= 0)
                        {
                            temp -= lastPassedCar.Length;
                            counter++;
                            continue;
                        }

                        if (temp + freeWindow - lastPassedCar.Length >= 0)
                        {
                            temp = 0;
                            counter++;
                            continue;
                        }

                        int hit = temp + freeWindow;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{lastPassedCar} was hit at {lastPassedCar[hit]}.");
                        return;
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
