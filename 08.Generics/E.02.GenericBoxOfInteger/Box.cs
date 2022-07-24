using System;
using System.Collections.Generic;
using System.Linq;

namespace E._02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public List<T> Items;

        public Box()
        {
            Items = new List<T>();
        }

        public override string ToString()
            => string.Join(Environment.NewLine, Items.Select(x => $"{typeof(T)}: {x}"));
        
    }
}
