using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];

                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);

                Engine engine = new Engine(speed, power);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                Tires tire1 = new Tires(tire1Pressure, tire1Age);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                Tires tire2 = new Tires(tire2Pressure, tire2Age);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                Tires tire3 = new Tires(tire3Pressure, tire3Age);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Tires tire4 = new Tires(tire4Pressure, tire4Age);

                Tires[] tires = new Tires[4] { tire1, tire2, tire3, tire4, };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars.FindAll(x => x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars.FindAll(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
