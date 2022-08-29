using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; } 
        public List<Pet> Data { get; set; }

        public int Count => data.Count; 

        public void Add(Pet pet)
        {
            if (Count < Capacity) 
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
            => data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The clinic has the following patients:");
            foreach (Pet pet in data)
            {
                stringBuilder.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
