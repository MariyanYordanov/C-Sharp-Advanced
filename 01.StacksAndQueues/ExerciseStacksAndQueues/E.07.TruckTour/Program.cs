using System;
using System.Linq;

namespace E._07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] pump = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pump[i] = data[0] - data[1];
            }

            int current = 0;
            int position = 0;

            for (int i = 0; i < n; i++)
            {
                current += pump[i];

                if (current < 0)
                {
                    current = 0;
                    position = i + 1;
                }
            }
            Console.WriteLine(position);
        }
    }
}
