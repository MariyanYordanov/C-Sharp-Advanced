using System;
using System.Collections.Generic;
using System.Linq;

namespace E._05.GenericCountMethodString
{
    public class Box<T>
         where T : IComparable
    {
        public List<T> Items;

        public Box()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Printing method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => string.Join(Environment.NewLine, Items.Select(x => $"{typeof(T)}: {x}"));
        /// <summary>
        /// Compare value of given input whit value of every collection element 
        /// </summary>
        /// <param name="inputToCompare"></param>
        /// <returns></returns>
        public int CountBigger(T inputToCompare)
        {
            int counter = 0;
            foreach (var item in Items)
            {
                //  if left > right => -1
                //  if left = right =>  0
                //  if left < right =>  1
                // item is bigger than inputToCompare so counter = 1;
                if (item.CompareTo(inputToCompare) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// Swap two elements on the given indexes on one line
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
