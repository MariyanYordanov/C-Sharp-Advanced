namespace CustomDoublyLinkedList
{
    using System;
    public class CustomDoublyLinkedList<T>
    {
        /// <summary>
        /// Create recursive data structure
        /// </summary>
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(T value)
            {
                Value = value;
            }
        }
        
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        /// <summary>
        /// Add an element at the beginning of the list (before its head) 
        /// </summary>
        /// <param name="element">The currrent element</param>
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                // Empty list  add the new element as head and tail at the same time.
                head = tail = new ListNode(element);
            }
            else
            {
                // 	Non-empty list  add the new element as a new head and redirect the old head as the second element, just after the new head.
                ListNode newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }

            Count++;
        }

        /// <summary>
        /// Appending a new element as the list tail
        /// </summary>
        /// <param name="element">The currrent element</param>
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                ListNode newTail = new ListNode(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }

            Count++;
        }

        /// <summary>
        /// Remove the first element from the list and move 
        /// its head to point to the second element.
        /// </summary>
        /// <returns>Returns the first element of collection</returns>
        /// <exception cref="InvalidOperationException">
        /// Throw InvalidOperationException exeption if list is empty
        /// </exception>
        public T RemoveFirst()
        {
            // 	Empty list  throw an exception.
            IsEmpty();

            // 	Single element in the list  make the list empty (head == tail == null)
            T firstElement = head.Value;
            // Multiple elements in the list  remove the first element and redirect the head to point to the second element (head = head.NextNode).
            head = head.NextNode;

            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return firstElement;
        }

        /// <summary>
        /// Remove the last element from the list and move 
        /// its tail to point to the element before the last
        /// </summary>
        /// <returns>Returns the last element of collection</returns>
        /// /// <exception cref="InvalidOperationException">
        /// Throw InvalidOperationException exeption if list is empty
        /// </exception>
        public T RemoveLast()
        {
            IsEmpty();

            T lastElement = tail.Value;
            tail = tail.PreviousNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return lastElement;
        }


        /// <summary>
        /// Method pass through each of elements, one by one
        /// </summary>
        /// <param name="action">The value of current element</param>
        public void ForEach(Action<T> action)
        {
            // Start from the head and pass to the next element until the last element is reached (its next element is null).
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            //For example, if you want to print all of the elements you can use the following code:
            // list.ForEach(x => Console.ReadLine(x));
            //Where list is DoublyLinkedList type object.

        }

        /// <summary>
        /// Copy all elements of the linked list to an array of the same size.
        /// </summary>
        /// <returns>Returns array whit copyed elements on linked list</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            ListNode currentNode = head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return array;
        }
        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }

    }
}
