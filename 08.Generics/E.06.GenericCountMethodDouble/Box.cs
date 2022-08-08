using System;
using System.Collections.Generic;
using System.Linq;

namespace E._06.GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        public List<T> Items;

        public Box()
        {
            Items = new List<T>();
        }

        public int CountBiggerThanInput(T input)
            => Items.Count(x => x.CompareTo(input) > 0); 
        
    }
}
