using System;
using System.Collections.Generic;
using System.Linq;

namespace E._04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,int> evenNum = new Dictionary<int,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!evenNum.ContainsKey(num))
                {
                    evenNum.Add(num,0);
                }
                evenNum[num]++;
            }

            int print = evenNum.FirstOrDefault(x => x.Value % 2 == 0).Key;
            
            Console.WriteLine(print);
        }
    }
}
