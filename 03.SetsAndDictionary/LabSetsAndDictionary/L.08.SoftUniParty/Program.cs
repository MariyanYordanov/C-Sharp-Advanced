using System;
using System.Collections.Generic;
using System.Linq;

namespace L._08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> listRegular = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();
            string reservation  = Console.ReadLine();
            while (reservation  != "PARTY")
            {
                if (reservation.Length == 8)
                {
                    if (Char.IsDigit(reservation[0]))
                    {
                        VIP.Add(reservation);
                    }
                    else
                    {
                        listRegular.Add(reservation);
                    }
                }

                reservation  = Console.ReadLine();
            }

            string guests = Console.ReadLine();
            while (guests != "END")
            {
                if (Char.IsDigit(guests[0]))
                {
                    VIP.Remove(guests);
                }
                else
                {
                    listRegular.Remove(guests);
                }

                guests = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count() + listRegular.Count());
            //Console.WriteLine(string.Join("\n",VIP));
            foreach (var item in VIP)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(string.Join("\n",listRegular));
            foreach (var item in listRegular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
