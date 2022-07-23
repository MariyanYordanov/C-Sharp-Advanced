using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            List<Car> cars = new List<Car>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine()
                {
                    Model = inputEngine[0],
                    Power = int.Parse(inputEngine[1])
                };

                if (inputEngine.Length == 3)
                {
                    bool isDisplacement = int.TryParse(inputEngine[2], out int undefined);
                    if (isDisplacement)
                    {
                        engine.Displacement = undefined;
                    }
                    else
                    {
                        engine.Efficiency = inputEngine[2];
                    }
                }

                if (inputEngine.Length == 4)
                {
                    engine.Displacement = int.Parse(inputEngine[2]);
                    engine.Efficiency = inputEngine[3];
                }

                engines.Add(engine);
            }

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] inputCars = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                
                Car car = new Car()
                {
                    Model = inputCars[0],
                    Engine = engines.FirstOrDefault(x => x.Model == inputCars[1]),
                };

                if (inputCars.Length == 3)
                {
                    bool isWeight = int.TryParse(inputCars[2], out int undefined);
                    if (isWeight)
                    {
                        car.Weight = undefined;
                    }
                    else
                    {
                        car.Color = inputCars[2];
                    }
                }

                if (inputCars.Length == 4)
                {
                    car.Weight = int.Parse(inputCars[2]);
                    car.Color = inputCars[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement != null)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }

                if (car.Weight != null)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                if (car.Color != null)
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
               
            }
        }
    }
}
