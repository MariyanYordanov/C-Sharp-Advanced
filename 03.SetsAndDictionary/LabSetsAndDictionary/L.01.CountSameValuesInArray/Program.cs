using System;
using System.Collections.Generic;
using System.Linq;

namespace L._01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,int> nums = new Dictionary<double,int>();
            double[] input =  Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!nums.ContainsKey(input[i]))
                {
                    nums.Add(input[i], 1);
                }
                else
                {
                    nums[input[i]] += 1;
                }
            }

            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
