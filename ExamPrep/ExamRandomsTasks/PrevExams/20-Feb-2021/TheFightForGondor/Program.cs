using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());
            int[] defenseLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> plates = new List<int>(defenseLine);
            Stack<int> orcs = new Stack<int>();
            for (int i = 1; i <= wavesOfOrcs; i++)
            {
                int[] orcWarrior = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                
                for (int j = 0; j < orcWarrior.Length; j++)
                {
                    orcs.Push(orcWarrior[j]);
                }

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    if (orcs.Peek() > plates[0])
                    {
                        int newValue = orcs.Peek() - plates[0];
                        plates.RemoveAt(0);
                        orcs.Pop();
                        orcs.Push(newValue);
                    }
                    else if (orcs.Peek() < plates[0])
                    {
                        int newValue = plates[0] - orcs.Peek();
                        plates[0] -= orcs.Pop();
                    }
                    else
                    {
                        plates.RemoveAt(0);
                        orcs.Pop();
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }

            }

           

            if (orcs.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }


        }
    }
}
