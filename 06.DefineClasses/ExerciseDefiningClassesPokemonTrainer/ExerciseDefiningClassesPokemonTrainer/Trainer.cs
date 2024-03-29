﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer()
        {
            Badge = 0;
        }

        public Trainer(string name)
            : this()
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badge { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
}
