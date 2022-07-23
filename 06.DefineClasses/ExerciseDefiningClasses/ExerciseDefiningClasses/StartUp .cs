using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //  Opinion Poll

            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);
            //    Person person = new Person(name, age);
            //    family.AddMember(person);
            //}

            //List<Person> people = family.GetPersonOver30();
            //foreach (var member in people.OrderBy(x => x.Name))
            //{
            //    Console.WriteLine($"{member.Name} - {member.Age}");
            //}


            // *Date Modifier

            //string[] startDate = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            //string[] endDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(DateModifier.DateCalculator(startDate, endDate));


            // Speed Rasing
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double FuelConsumptionPerKilometer = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, FuelConsumptionPerKilometer);
                cars.Add(car);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string method = commands[0];
                if (method == "End")
                {
                    break;
                }

                string carModel = commands[1];
                double amountOfKm = double.Parse(commands[2]);
                cars.Where(c => c.Model == carModel).ToList().ForEach(c => c.Drive(amountOfKm));
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

    }
}
