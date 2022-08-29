using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public  void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredient) && ingredient.Alcohol <= MaxAlcoholLevel && ingredients.Count <= Capacity)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(x => x.Name == name);
            return ingredients.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name) 
            => ingredients.FirstOrDefault(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in ingredients)
            {
                stringBuilder.AppendLine(ingredient.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
