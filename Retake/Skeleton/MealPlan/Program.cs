using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] mealsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] caloriesInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> meals = new Queue<string>(mealsInput);

            Stack<int> calories = new Stack<int>(caloriesInput);

            int mealsCounter = 0;
            while (calories.Count > 0 && meals.Count > 0)
            {
                int diff = 0;
                if (meals.Peek() == "salad")
                {
                    diff = calories.Pop() - 350;
                }
                else if (meals.Peek() == "soup")
                {
                    diff = calories.Pop() - 490;
                }
                else if (meals.Peek() == "pasta")
                {
                    diff = calories.Pop() - 680;
                }
                else if (meals.Peek() == "steak")
                {
                    diff = calories.Pop() - 790;
                }

                if (diff >= 0)
                {
                    calories.Push(diff);
                }
                else
                {
                    if (calories.Count > 0)
                    {
                        diff = calories.Pop() + diff;
                        calories.Push(diff);
                    }
                    else
                    {
                        mealsCounter++;
                        meals.Dequeue();
                        Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                        Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
                        return;
                    }
                }

                meals.Dequeue();
                mealsCounter++;
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",calories)} calories.");
            }

        }
    }
}
