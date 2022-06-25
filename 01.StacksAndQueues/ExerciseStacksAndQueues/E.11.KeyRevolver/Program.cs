using System;
using System.Linq;
using System.Collections.Generic;

namespace E._11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksInput);
            Stack<int> bullets = new Stack<int>(bulletsInput);
            int shootingBulletsTotal = 0;
            int shootBulletsBarel = 0;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    shootingBulletsTotal++;
                    shootBulletsBarel++;
                    
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    shootingBulletsTotal++;
                    shootBulletsBarel++;
                    
                }

                if (shootBulletsBarel == barrel && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shootBulletsBarel = 0;
                }

                if (locks.Count == 0 || bullets.Count == 0)
                {
                    break;
                }

            }

            int moneyEarned = intelligenceValue - bulletPrice * shootingBulletsTotal;
            
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

        }
    }
}
