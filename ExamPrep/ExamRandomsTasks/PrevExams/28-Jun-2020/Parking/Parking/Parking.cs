using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Data { get; set; }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(
                x => x.Manufacturer == manufacturer && x.Model == model);

            return data.Remove(car);
        }

        public Car GetLatestCar() 
            => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) 
            => data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                stringBuilder.AppendLine($"{car.ToString()}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
