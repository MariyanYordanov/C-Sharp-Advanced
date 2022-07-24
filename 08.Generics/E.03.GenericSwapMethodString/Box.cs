using System;
using System.Collections.Generic;
using System.Linq;

namespace E._03.GenericSwapMethodString
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

        /// <summary>
        /// Swap on one line
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void Swap(int left, int right)
            => (Items[left], Items[right]) = (Items[right], Items[left]);
        //{
        //    T temp = Items[left];
        //    Items[left] = Items[right];
        //    Items[right] = temp;
        //}
    }
}
