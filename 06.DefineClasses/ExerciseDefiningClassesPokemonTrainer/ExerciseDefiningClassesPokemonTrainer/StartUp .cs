using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,Trainer> trainers = new Dictionary<string,Trainer>();
            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Pokemon pokemon = new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3]));

                if (!trainers.ContainsKey(tokens[0]))
                {
                    Trainer trainer = new Trainer(tokens[0]);
                    trainers.Add(tokens[0],trainer);
                }

                trainers[tokens[0]].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Value.Badge++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                            
                        }

                        trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badge))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badge} {trainer.Value.Pokemons.Count()}");
            
            }
        }
    }
}
