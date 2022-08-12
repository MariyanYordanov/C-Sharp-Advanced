using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private readonly List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>(); 
        }

        public IReadOnlyCollection<Animal> Animals => animals;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal) 
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return $"Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return $"Invalid animal diet.";
            }

            if (animals.Count == Capacity)
            {
                return $"The zoo is full.";
            }

            animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            List<Animal> animalToREmove = animals.Where(x => x.Species == species).ToList();
            animals.RemoveAll(x => x.Species == species);
            return animalToREmove.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalToFind = animals.Where(x => x.Diet == diet).ToList();
            return animalToFind;
        }

        public Animal GetAnimalByWeight(double weight)
            => animals.FirstOrDefault(x => x.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> animal = animals
                .Where(x => x.Length >= minimumLength && x.Length <= maximumLength).ToList();

            return $"There are {animal.Count} animals with a length between {minimumLength}" +
                $" and {maximumLength} meters.";
        }
    }
}
