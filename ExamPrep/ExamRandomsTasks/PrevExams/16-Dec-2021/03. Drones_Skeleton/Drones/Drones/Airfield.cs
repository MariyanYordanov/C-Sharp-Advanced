using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones = new List<Drone>();

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => drones.Count;

        public IReadOnlyCollection<Drone> Drones 
        {
            get => drones;
            set
            {
                Drones = drones;
            }
        }
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (Drones.Count < Capacity)
            {
                if (    drone.Brand == null || drone.Brand == string.Empty
                     || drone.Name == null || drone.Name == string.Empty
                     || drone.Range < 5 || drone.Range > 15)
                {
                    return "Invalid drone.";
                }

            }

            else
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name) => drones.Remove(drones.FirstOrDefault(x => x.Name == name));
        
        public int RemoveDroneByBrand(string brand) => drones.RemoveAll(x => x.Brand == brand);

        public Drone FlyDrone(string name)
        {
            foreach (var drone in drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = new List<Drone>();
            foreach (var drone in drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    flownDrones.Add(drone);
                }
            }

            return flownDrones;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Drones available at {Name}:");

            foreach (var drone in Drones)
            {
                if (drone.Available)
                {
                    stringBuilder.AppendLine(drone.ToString());
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
