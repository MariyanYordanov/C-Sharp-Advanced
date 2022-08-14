using System;

namespace CreateCustomDataStructures
{
    public class CustumQueue
    {
        private int firstElementIndex = 0;
        private int initialCapacity = 4;
        private int counter;
        private int[] items;

        public CustumQueue()
        {
            counter = 0;
            items = new int[initialCapacity];
        }

        public int Count => counter;


        /// <summary>
        /// Removes all the elements from the collection.
        /// </summary>
        /// <returns>
        /// Returns zero.
        /// </returns>
        public int Clear()
        {
            IsEmpty();
            for (int i = 0; i < counter; i++)
            {
                Dequeue();
            }

            return 0;
        }

        /// <summary>
        /// Take first one element from given collection
        /// </summary>
        /// <returns>
        /// Returns the first one element on the collection
        /// </returns>
        public int Peek()
        {
            IsEmpty();
            return items[firstElementIndex]; 
        }

        /// <summary>
        /// Remove first element on the collection
        /// </summary>
        /// <returns>
        /// Returns first element.
        /// </returns>
        public int Dequeue()
        {
            IsEmpty();
            int item = items[firstElementIndex];
            SwitchElements();
            return item;
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
        /// Adds an element at the beginning of the collection
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(int item)
        {
            if (initialCapacity == counter)
            {
                Resize();
            }

            items[counter] = item;
            counter++;
        }

        /// <summary>
        /// Add new position on the collection
        /// </summary>
        private void Resize()
        {
            int[] temp = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                temp[i] = items[i];
            }

            items = temp;
        }
        
        /// <summary>
        /// Reordering collection
        /// </summary>
        private void SwitchElements()
        {
            for (int i = 0; i < counter; i++)
            {
                items[i] = items[i + 1];
            }

            counter--;
        }

        /// <summary>
        /// Check for emptyness of the collection
        /// </summary>
        /// <exeption cref="InvalidOperationException">
        /// Throw exeption if queue is empty
        /// </exeption>
        private void IsEmpty()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

        }

    }
}
