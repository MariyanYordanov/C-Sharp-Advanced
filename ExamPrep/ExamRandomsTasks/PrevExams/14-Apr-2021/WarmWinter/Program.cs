using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] hatsArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] scarfsArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hats = new Stack<int>(hatsArray);
            Queue<int> scarfs = new Queue<int>(scarfsArray);
            List<int> setList = new List<int>();
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    int sum = hats.Peek() + scarfs.Peek();
                    setList.Add(sum);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int newValue = 1 + hats.Pop();
                    hats.Push(newValue);
                }
            }

            Console.WriteLine($"The most expensive set is: {setList.Max()}");
            Console.WriteLine(string.Join(" ",setList));
        }
    }
}
