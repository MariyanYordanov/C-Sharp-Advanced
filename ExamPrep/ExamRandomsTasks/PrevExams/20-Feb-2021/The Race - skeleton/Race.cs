using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Data { get; set; }
        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name) => data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer() => data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in data)
            {
                stringBuilder.AppendLine($"{racer.ToString()}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
