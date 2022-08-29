using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public List<Car> Participants { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) && Capacity >= Participants.Count + 1 && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }

        }

        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Car FindParticipant(string licensePlate) => Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar() => Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                stringBuilder.AppendLine(car.ToString().TrimEnd());
            }

            return stringBuilder.ToString();
        }
    }
}
