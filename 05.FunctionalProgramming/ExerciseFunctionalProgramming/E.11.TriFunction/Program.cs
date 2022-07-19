using System;

namespace E._11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> asciiName = name =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                return sum;
            };

            Func<int, int, bool> isEqualOrLarger = (sum, number) => sum >= number;
            
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            foreach (var name in names)
            {
                if (isEqualOrLarger(asciiName(name), number))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
            
        }
    }
}
