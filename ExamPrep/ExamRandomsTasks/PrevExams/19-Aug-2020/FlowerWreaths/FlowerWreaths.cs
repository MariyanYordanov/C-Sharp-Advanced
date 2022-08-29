using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {

            int[] liliesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rosesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> roses = new Queue<int>(rosesInput);
            Stack<int> lilies = new Stack<int>(liliesInput);
            int countOfWreaths = 0;
            int stored = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                int sum = roses.Peek() + lilies.Peek();
                if (sum == 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    countOfWreaths++;
                }
                else if (sum > 15)
                {
                    int newValue = lilies.Pop() - 2;
                    lilies.Push(newValue);
                }
                else if (sum < 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    stored += sum;
                }
            }

            int restFlowersWreaths = stored / 15;
            countOfWreaths += restFlowersWreaths;
            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }
    }
}
