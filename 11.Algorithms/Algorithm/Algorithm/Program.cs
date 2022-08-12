using System;
using System.Linq;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quick sort implementation

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //numbers = new int[] { 3, 21, 5, 1, -12, 34, 2, 9, 68, -23, -1 };
            
            QuickSort(numbers,numbers[0],numbers[numbers.Length - 1]);
        }

        private static void QuickSort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            // implement pivot, left and right indexes
            int pivotIndex = startIndex;
            int leftIndex = startIndex + 1;
            int rightIndex = endIndex;

            // the logic
            while (leftIndex <= rightIndex)
            {
                //if (left > pivot < right) => Swap(left,right)
                if (numbers[leftIndex] > numbers[pivotIndex]
                  && numbers[rightIndex] < numbers[pivotIndex]) 
                {
                    Swap(numbers, leftIndex, rightIndex);
                }

                // if ( left <= pivot ) => left++
                if (numbers[leftIndex] <= numbers[pivotIndex])
                {
                    leftIndex++;
                }

                // if ( rifht >= pivot ) => right--
                if (numbers[rightIndex] >= numbers[pivotIndex])
                {
                    rightIndex--;
                }
            }

            // when left > right => Swap(pivot,right)
            Swap(numbers, pivotIndex, rightIndex);
            var isLeftSubArraysSmaller = rightIndex - 1 - startIndex < endIndex - (rightIndex + 1);
        }

        private static void Swap(int[] numbers, int firstIndex, int secondIndex)
        {
            int temp = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temp;
        }
    }
}
