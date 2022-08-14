namespace CreateCustomDataStructures
{
    using System;

    public class CustomList
    {
        private int[] items;
        private int internalCounter;
        /// <summary>
        /// Give a length to inner collection.
        /// </summary>
        public CustomList()
        {
            items = new int[2];
            internalCounter = 0;
        }

        public int Count => internalCounter;

        /// <summary>
        /// Access to inner collection using an index
        /// </summary>
        /// <param name="index">Position of given element</param>
        /// <returns>
        /// Position of given element
        /// </returns>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// Throw ArgumentOutOfRangeException exeption when 
        /// <paramref name="index"/> is bigger than array lenght
        /// </exception>
        public int this[int index]
        {
            get
            {
                EnsureIsInRange(index);
                return items[index];
            }

            set
            {
                EnsureIsInRange(index);
                items[index] = value;
            }
        }

        /// <summary>
        /// Add new element in the collection
        /// </summary>
        /// <param name="item">
        /// Element to add in collection
        /// </param>
        public void Add(int item)
        {
            
            Resize();
            items[internalCounter] = item;
            internalCounter++;
        }

        /// <summary>
        /// Remove an item from collection on the given index.
        /// </summary>
        /// <param name="index">Element on the current index</param>
        /// <returns>
        /// Return the item
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw exeption when <paramref name="index"/>
        /// is bigger than array lenght
        /// </exception>
        public int RemoteAt(int index)
        {
            EnsureIsInRange(index);
            var item = items[index];
            items[index] = default(int);
            Shift(index);
            internalCounter--;
            if (internalCounter <= items.Length / 4)
            {
                Shrink();
            }

            return item;
        }

        /// <summary>
        /// Add new element in collection at the given index.
        /// </summary>
        /// <param name="index">Position of item</param>
        /// <param name="item">Element to insert</param>
        public void Insert(int index, int element)
        {
            // Validate the index.
            EnsureIsInRange(index);

            // Check if the array should be resized then resized it.
            Resize();

            // Rearrange the items to free the space for the required index.
            ShiftToRight(index);

            // Insert the given item on the index and increase the count
            items[index] = element;
            internalCounter++;
        }

        /// <summary>
        /// Check if the given element is in the collection.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// If current element is in collection,
        /// method returns true, else return false
        /// </returns>
        public bool Contains(int element)
        {
            for (int i = 0; i < internalCounter; i++)
            {
                if (element == items[i])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method swap places of two elements on collection
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        public void Swap(int firstIndex, int secondIndex)
        {
            EnsureIsInRange(firstIndex);
            EnsureIsInRange(secondIndex);
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        /// <summary>
        /// Check for number in given collection
        /// </summary>
        /// <param name="number"></param>
        /// <returns>
        /// Return position of number in collection
        /// </returns>
        public int Find(int number)
        {
            for (int i = 0; i < internalCounter; i++)
            {
                if (number == items[i])
                {
                    return i;
                }
            }

            return int.MinValue;
        }

        /// <summary>
        /// Reverse collection
        /// </summary>
        public void Reverse()
        {
            int[] newArray = new int[internalCounter];
            int counter = 0;
            for (int i = internalCounter - 1; i >= 0; i--)
            {
                newArray[counter] = items[i];
                counter++;
            }

            items = newArray;
        }

        /// <summary>
        /// Traverses the collection element by element
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < internalCounter; i++)
            {
                action(items[i]);
            }
        }

        /// <summary>
        /// Printing method
        /// </summary>
        /// <returns>
        /// Returns all elements separated by comma 
        /// </returns>
        public override string ToString()
        {
            RemoveNull();
            return $"{string.Join(", ", items)}";
        }

        /// <summary>
        /// Increace size of inner array by multiply by two
        /// </summary>
        private void Resize()
        {
            if (internalCounter == items.Length)
            {
                int[] copyArray = new int[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    copyArray[i] = items[i];
                }

                items = copyArray;
            }
            
        }

        /// <summary>
        /// Remove all empty position from given inner collection
        /// </summary>
        private void Shrink()
        {
            int[] copyArray = new int[items.Length / 2];
            for (int i = 0; i < items.Length; i++)
            {
                copyArray[i] = items[i];
            }

            items = copyArray;
        }

        /// <summary>
        /// Rearrange all elements after given index.
        /// </summary>
        /// <param name="index">Element from who start to remove all indexes</param>
        private void Shift(int index)
        {
            for (int i = index; i < internalCounter - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[internalCounter - 1] = default(int);
        }
        /// <summary>
        /// Starting from the end of the actual elements, 
        /// this method will copy every single item on the next index.
        /// </summary>
        /// <param name="index">Position of item</param>
        private void ShiftToRight(int index)
        {
            for (int i = internalCounter; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = default(int);
        }

        /// <summary>
        /// Check index is in range and if it is not throw exeption
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw exeption if index is not in range of array
        /// </exception>
        private void EnsureIsInRange(int index)
        {
            if (index < 0 || index >= internalCounter)
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        /// <summary>
        /// Clear all empty position
        /// </summary>
        private void RemoveNull()
        {
            int[] clearArray = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                clearArray[i] = items[i];
            }

            items = clearArray;
        }

    }
}
