using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                data.Add(ski);
            }

        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Model == model && x.Manufacturer == manufacturer);
            return data.Remove(ski);
        }

        public Ski GetNewestSki() => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) => data.FirstOrDefault(x => x.Model == model && x.Manufacturer == manufacturer);

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                stringBuilder.AppendLine(ski.ToString().TrimEnd());
            }

            return stringBuilder.ToString();
        }
    }
}
