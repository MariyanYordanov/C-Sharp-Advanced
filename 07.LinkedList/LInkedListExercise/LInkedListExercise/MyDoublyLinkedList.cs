namespace LInkedListExercise
{
    using System;
    public class MyDoublyLinkedList<T>
    {
        private bool IsReversed = false;
        public int Count { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void Reversed()
        {
            IsReversed = !IsReversed;
        }

        public void AddFirst(Node<T> node)
        {
            Count++;
            if (!IsFirst(node))
            {
                Node<T> previosHead = Head;
                Head = node;
                previosHead.Prev = Head;
                Head.Next = previosHead;
            }
        }

        public void AddLast(Node<T> node)
        {
            Count++;
            if (!IsFirst(node))
            {
                Node<T> temp = Tail;
                Tail = node;
                temp.Prev = Tail;
                Tail.Next = temp;
            }
        }

        public Node<T> RemoveFirst()
        {
            if (Head == null)
            {
                return null;
            }

            Count--;
            var previosHead = Head;
            var newHead = Head.Next;

            if (newHead != null)
            {
                newHead.Prev = null;
            }
            else
            {
                Tail = null;
            }

            Head = newHead;

            return previosHead;
        }

        public Node<T> RemoveLast()
        {
            if (Tail == null)
            {
                return null;
            }

            Count--;
            var previosTail = Tail;
            var newTail = Tail.Prev;

            if (newTail != null)
            {
                newTail.Prev = null;
            }
            else
            {
                Head = null;
            }

            Tail = newTail;

            return previosTail;
        }

        public void ForEach(Action<Node<T>> action)
        {
            var node = Head;
            if (IsReversed)
            {
                node = Tail;
            }
            while (node != null)
            {
                action(node);
                if (IsReversed)
                {
                    node = node.Prev;
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        public Node<T>[] ToArray()
        {
            Node<T>[] arr = new Node<T>[Count];
            int index = 0;
            var node = Head;
            if (IsReversed)
            {
                node = Tail;
            }
            while (node != null)
            {
                arr[index++] = node;
                if (IsReversed)
                {
                    node = node.Prev;
                }
                else
                {
                    node = node.Next;
                }
                
            }

            return arr;
        }

        public void Print(Node<T> node)
        {
            while (node != null)
            {
                Console.Write($"{node.Value} ");
                node = node.Next;
            }
        }

        private bool IsFirst(Node<T> node)
        {
            if (Head == null)
            {
                Head = Tail = node;
                return true;
            }

            return false;
        }
    }
}
