using System;
using System.Collections.Generic;
using System.Linq;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        
        static void Main(string[] args)
        {
            string tireInput = Console.ReadLine();
            List<Tire[]> tireList = new List<Tire[]>();
            while (tireInput != "No more tires")
            {
                string[] tiresString = tireInput.Split().ToArray();
                Tire[] tire = new Tire[4]
                {
                new Tire(int.Parse(tiresString[0]), double.Parse(tiresString[1])),
                new Tire(int.Parse(tiresString[2]), double.Parse(tiresString[3])),
                new Tire(int.Parse(tiresString[4]), double.Parse(tiresString[5])),
                new Tire(int.Parse(tiresString[6]), double.Parse(tiresString[7])),
                };

                tireList.Add(tire);
                tireInput = Console.ReadLine();
            }
            
            
            string engineInput = Console.ReadLine();
            List<Engine> engines = new List<Engine>();
            while (engineInput != "Engines done")
            {
                string[] engineString = engineInput.Split().ToArray();
                int horsePower = int.Parse(engineString[0]);
                double cubicCapacity = double.Parse(engineString[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
                engineInput = Console.ReadLine();
            }

            string specialInput = Console.ReadLine();
            List<Car> cars = new List<Car>();
            while (specialInput != "Show special")
            {
                string[] specialString = specialInput.Split().ToArray();
                string makeCar = specialString[0];
                string modelCar = specialString[1];
                int yearCar = int.Parse(specialString[2]);
                double fuelQuantityCar = double.Parse(specialString[3]);
                double fuelConsumptionCar = double.Parse(specialString[4]);
                int engineIndex = int.Parse(specialString[5]);
                int tiresIndex = int.Parse(specialString[6]);
                Car car = new Car(makeCar, modelCar, yearCar, fuelQuantityCar, fuelConsumptionCar, engines[engineIndex], tireList[tiresIndex]);
                cars.Add(car);
                specialInput = Console.ReadLine();
            }

            foreach (var car in cars)
            {
               if (car.Year >= 2017 && car.Engine.HorsePower > 330 && (car.Tires.Sum(x => x.Pressure) > 9 && car.Tires.Sum(x => x.Pressure) < 10))
               {
                    car.Drive(20);
                    car.WhoAmI();
               }
            }

        }
    }
}
