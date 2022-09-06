using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public IReadOnlyCollection<Drone> Drones => drones;

        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            if (this.drones.Count < this.Capacity)
            {
                if (drone.Name == null || drone.Brand == null
                || drone.Name == string.Empty || drone.Brand == string.Empty
                || drone.Range < 5 || drone.Range > 15)
                {
                    return $"Invalid drone.";
                }
            }
            else
            {
                return $"Airfield is full.";
            }

            this.drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
            => this.drones.Remove(this.drones.FirstOrDefault(x => x.Name == name));

        public int RemoveDroneByBrand(string brand)
            => this.drones.RemoveAll(x => x.Brand == brand);

        public Drone FlyDrone(string name)
        {
            foreach (var drone in this.drones)
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
            List<Drone> dronesToFly = new List<Drone>();
            foreach (var drone in dronesToFly)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    dronesToFly.Add(drone);
                }
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in Drones)
            {
                if (drone.Available)
                {
                    sb.AppendLine($"{drone}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }

}
