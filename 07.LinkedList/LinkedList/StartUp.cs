namespace CustomDoublyLinkedList
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<char> doublyLinkedList = new CustomDoublyLinkedList<char>();

            doublyLinkedList.AddFirst('3');
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 3

            doublyLinkedList.AddFirst('5');
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 5 3 

            doublyLinkedList.AddFirst('8');
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 8 5 3

            doublyLinkedList.AddLast('2');
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 8 5 3 2

            doublyLinkedList.RemoveFirst();
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 5 3 2

            doublyLinkedList.RemoveLast();
            doublyLinkedList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine(); // 5 3
        }

    }
}
