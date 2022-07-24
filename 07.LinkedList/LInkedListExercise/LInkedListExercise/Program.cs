using System;
using System.Collections;
using System.Collections.Generic;

namespace LInkedListExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string reverseThisLinkedList = "Hire a programmer with 4 words";
            string[] rtls = reverseThisLinkedList.Split();
            var doublyLinkedList = new MyDoublyLinkedList<string>();
            for (int i = 0; i < rtls.Length; i++)
            {
                doublyLinkedList.AddFirst(new Node<string>(rtls[i]));
            }

            Node<string> node = doublyLinkedList.Head;
            doublyLinkedList.Print(node);
            

            Console.WriteLine();
            int P = 16;
            int N = 3;

            // We are given the seqyence:
            // S = N ,N + 1, 2*N ,N + 2, 2*(N + 1), 2*N + 1, 4*N, ...
            // S[0] = N; S[1] = N + 1; S[2] = 2*N; S[3] = N + 2; S[4] = 2*N + 1; S[5] = 4*N ...
            // Find the first index of given number P
            // Example N = 3, P = 16
            // S = 3, 4, 6, 5, 8, 7, 12, 6, 10, 9, 16,... => index of P is 11, S[11] = 16

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(N);
            int counter = 1;
            while (sequence.Peek() != P)
            {
                sequence.Enqueue(sequence.Peek() + 1);
                sequence.Enqueue(sequence.Peek() * 2);
                sequence.Dequeue();
                counter++;
            }

            int result = counter;
            Console.WriteLine(result);
        }
                
    }
}
