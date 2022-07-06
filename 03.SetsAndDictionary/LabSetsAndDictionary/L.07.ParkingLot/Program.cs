using System;
using System.Collections.Generic;

namespace L._07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            HashSet<string> parking = new HashSet<string>();
            while (input[0] != "END")
            {
                string command = input[0];
                string number = input[1];
                if (command == "IN")
                {
                    parking.Add(number);
                }
                else if (command == "OUT")
                {
                    if (parking.Contains(number))
                    {
                        parking.Remove(number);
                    }
                    
                }
                input = Console.ReadLine().Split(", ");
            }

            if (parking.Count > 0)
            {
                Console.WriteLine(string.Join("\n", parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
