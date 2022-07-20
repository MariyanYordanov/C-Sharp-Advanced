using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string tiresInfo = Console.ReadLine();
            List<Tire[]> carTires = new List<Tire[]>();
            List<Engine> carEngines = new List<Engine>();
            List<Car> cars = new List<Car>();
            
            while (tiresInfo != "No more tires")
            {
                string[] tokens = tiresInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentTires = new Tire[4]
                {
                new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                };
                carTires.Add(currentTires);
                tiresInfo = Console.ReadLine();
            }

            string engineInfo = Console.ReadLine();
            while (engineInfo != "Engines done")
            {
                string[] tokens = engineInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currentEngineHorsePower = int.Parse(tokens[0]);
                double currentEngineCubicCapacity = double.Parse(tokens[1]);
                Engine currentEngine = new Engine(currentEngineHorsePower, currentEngineCubicCapacity);
                carEngines.Add(currentEngine);
                engineInfo = Console.ReadLine();
            }

            string carInfo = Console.ReadLine();
            while (carInfo != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] tokens = carInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentCarMake = tokens[0];
                string currentCarModel = tokens[1];
                int currentCarYear = int.Parse(tokens[2]);
                double currentCarFuelQuantity = double.Parse(tokens[3]);
                double currentCarFuelConsumption = double.Parse(tokens[4]);
                int currentCarEngineIndex = int.Parse(tokens[5]);
                Engine currentCarEngine = carEngines[currentCarEngineIndex];
                int currentCarTiresIndex = int.Parse(tokens[6]);
                Tire[] currentCarTires = carTires[currentCarTiresIndex];
                Car currentCar = new Car(currentCarMake, currentCarModel, currentCarYear, currentCarFuelQuantity, currentCarFuelConsumption, currentCarEngine, currentCarTires);
                cars.Add(currentCar);
                carInfo = Console.ReadLine();
            }
            
            
            foreach (Car car in cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 300 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10))
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
