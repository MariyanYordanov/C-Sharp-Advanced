namespace CreateCustomDataStructures
{
    using System;
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int counter;

        public CustomStack()
        {
            counter = 0;
            items = new int[initialCapacity];
        }

        public int Count => counter;

        /// <summary>
        ///  Returns the last element from the collection,
        ///  but it doesn't remove it. 
        /// </summary>
        /// <returns>
        /// Returns the last element from the collection
        /// </returns>
        public int Peek() 
        {
            IsEmpty();
            return items[counter - 1]; 
        } 

        /// <summary>
        /// Add new element on the last index in collection 
        /// </summary>
        /// <param name="element">
        /// element
        /// </param>
        public void Push(int element)
        {
            Resize();
            items[counter] = element;
            counter++;
        }

        /// <summary>
        /// Returns the last element from the collection and removes it
        /// </summary>
        /// <returns>The last elementfrom the collection</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw exeption if index is not in range of array
        /// </exception>
        public int Pop()
        {
            IsEmpty();
            int last = items[counter - 1];
            counter--;
            return last;
        }

        /// <summary>
        /// Traverses the collection element by element
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < counter; i++)
            {
                action(items[i]);
            }

        }

        /// <summary>
        /// Check the index is in range of array
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// Throw exeption if index is not in range of array
        /// </exception>
        private void IsEmpty()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }

        /// <summary>
        /// Increace size of inner array by multiply by two
        /// </summary>
        private void Resize()
        {
            if (items.Length == counter)
            {
                var nextItems = new int[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    nextItems[i] = items[i];
                }

                items = nextItems;
            }
        }

    }
}
