using System;

namespace E._07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] beerInfo = Console.ReadLine().Split();
            string[] numbersInfo = Console.ReadLine().Split();

            MyTuple<string, string> personTuple = new MyTuple<string, string>
                ($"{personInfo[0]} {personInfo[1]}", personInfo[2]);

            MyTuple<string, int> beerTuple = new MyTuple<string, int>
                ($"{beerInfo[0]}", int.Parse(beerInfo[1]));

            MyTuple<int, double> numbersTyple = new MyTuple<int, double>
                (int.Parse(numbersInfo[0]), double.Parse(numbersInfo[1]));

            Console.WriteLine(personTuple.ToString());
            Console.WriteLine(beerTuple.ToString());
            Console.WriteLine(numbersTyple.ToString());
        }
    }
}
