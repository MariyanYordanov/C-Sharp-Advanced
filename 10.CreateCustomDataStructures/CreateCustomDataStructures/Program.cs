using System;

namespace CreateCustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("//List//List//List//List//List//List/");
            //CustumListView();
            //Console.WriteLine("//List//List//List//List//List//List/");

            //Console.WriteLine("//Stack//Stack//Stack//Stack//Stack//Stack//");
            //CustumStackView();
            //Console.WriteLine("//Stack//Stack//Stack//Stack//Stack//Stack//");

            Console.WriteLine("//Queue//Queue//Queue//Queue//Queue//Queue//");
            CustumQueueView();
            Console.WriteLine("//Queue//Queue//Queue//Queue//Queue//Queue//");
        }

        private static void CustumStackView()
        {
            CustomStack customStack = new CustomStack();

            customStack.Push(144);
            customStack.ForEach(Console.WriteLine); // 144

            customStack.Push(89);
            customStack.ForEach(x => Console.WriteLine()); // 144 89

            customStack.Push(55);
            customStack.ForEach(Console.WriteLine); // 144 89 55

            customStack.Push(34);
            customStack.ForEach(Console.WriteLine); // 144 89 55 34
            
            customStack.Pop();
            customStack.ForEach(Console.WriteLine); // 144 89 55

            int secondOne = customStack.Pop();
            customStack.ForEach(Console.WriteLine); // 144 89 

            int peeked = customStack.Peek();
            Console.WriteLine($"Peek last stack element -> {peeked}");

        }

        private static void CustumQueueView()
        {
            CustumQueue custumQueue = new CustumQueue();
            custumQueue.Enqueue(13);
            custumQueue.ForEach(Console.WriteLine); // 13

            custumQueue.Enqueue(34);
            custumQueue.ForEach(Console.WriteLine); // 13 34

            custumQueue.Enqueue(89);
            custumQueue.ForEach(Console.WriteLine); // 13 34 89

            custumQueue.Dequeue();
            custumQueue.ForEach(Console.WriteLine); // 34 89

            custumQueue.Dequeue();
            custumQueue.ForEach(Console.WriteLine); // 89

            Console.WriteLine(custumQueue.Peek());
            custumQueue.ForEach(Console.WriteLine); // 89

            Console.WriteLine(custumQueue.Clear());
            custumQueue.ForEach(Console.WriteLine); // 0

            custumQueue.Enqueue(13);
            custumQueue.ForEach(Console.WriteLine); // 13

            custumQueue.Enqueue(21);
            custumQueue.ForEach(Console.WriteLine); // 13 21

            custumQueue.Enqueue(34);
            custumQueue.ForEach(Console.WriteLine); // 13 21 34

            int peeked = custumQueue.Peek();
            Console.WriteLine($"Peek queue first element -> {peeked}");
        }

        private static void CustumListView()
        {
            CustomList customList = new CustomList();

            customList.Add(1);          // 1
            Console.WriteLine(customList.ToString());

            customList.Add(2);          // 1 2
            Console.WriteLine(customList.ToString());

            customList.Add(3);          // 1 2 3
            Console.WriteLine(customList.ToString());

            customList.Add(5);          // 1 2 3 5
            Console.WriteLine(customList.ToString());

            customList.Add(8);          // 1 2 3 5 8
            Console.WriteLine(customList.ToString());

            customList.RemoteAt(0);     // 2 3 5 8
            Console.WriteLine(customList.ToString());

            customList.Insert(0, 13);    // 13 2 3 5 8
            Console.WriteLine(customList.ToString());

            customList.Swap(0, 1);       // 2 13 3 5 8
            Console.WriteLine(customList.ToString());

            customList.Reverse();       // 8 5 3 13 2
            Console.WriteLine(customList.ToString());

            Console.WriteLine(customList.Find(13)); // 3

            Console.WriteLine(customList.Contains(21));    // False

            customList.ForEach(Console.WriteLine);
        }
    }
}
