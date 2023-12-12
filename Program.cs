using System;
using System.Linq;

namespace SortingAlgorithmsPractice
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int SIZE = 20, HIGHEST_NUM = 1000;
            
            var random = new Random();

            var arr = new int[SIZE];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, HIGHEST_NUM + 1);
            }

            arr = arr.OrderDescending().ToArray();

            arr.PrintArray();

            var copy = arr.ToArray();
            
            BubbleSort(copy);

            copy.PrintArray();
            
            copy = arr.ToArray();
            
            InsertionSort(copy);
            
            copy.PrintArray();
            
            copy = arr.ToArray();

            SelectionSort(copy);
            
            copy.PrintArray();
        }
        
        private static void ShuffleArray(int[] arr, Random random)
        {
            var length = arr.Length;
            
            for (int i = 0; i < length; i++)
            {
                ref var left = ref arr[i];
                
                ref var right = ref arr[random.Next(0, length)];

                // Swap
                (left, right) = (right, left);
            }
        }

        private static void PrintArray(this int[] arr)
        {
            var output = string.Empty;

            const string SUFFIX = ", ";

            foreach (var item in arr)
            {
                output += $"{item}{SUFFIX}";
            }

            output = output.AsSpan(0, output.Length - SUFFIX.Length).ToString();

            Console.WriteLine($"[ {output} ]");
        }

        private static void BubbleSort(int[] arr)
        {
            for (int remainingLength = arr.Length; remainingLength > 1; remainingLength--)
            {
                var leftIndex = 0;

                var swapTookPlace = false;
            
                while (true)
                {
                    var rightIndex = leftIndex + 1;

                    // >=  handles arr.Length == 0
                    if (rightIndex >= remainingLength)
                    {
                        break;
                    }
                    
                    ref var left = ref arr[leftIndex];
                
                    ref var right = ref arr[rightIndex];

                    if (left > right)
                    {
                        // Swap
                        (left, right) = (right, left);
                        swapTookPlace = true;
                    }

                    leftIndex = rightIndex;
                }

                if (!swapTookPlace)
                {
                    return;
                }
            }
        }

        private static void InsertionSort(int[] arr)
        {
            var length = arr.Length;
            
            for (int rightIndex = 1; rightIndex < length; rightIndex++)
            {
                ref var currentRight = ref arr[rightIndex];

                var currentRightVal = currentRight;
                
                for (int i = rightIndex - 1; i >= 0; i--)
                {
                    ref var currentLeft = ref arr[i];

                    if (currentRightVal >= currentLeft)
                    {
                        break;
                    }

                    // Move value in left slot to right slot
                    currentRight = currentLeft;

                    // Current left slot now becomes right slot
                    currentRight = ref currentLeft;
                }
                
                // Unconditionally write value to right slot.
                // This is because we avoid writing back currentRightVal until its appropriate position is found
                currentRight = currentRightVal;
            }
        }

        private static void SelectionSort(int[] arr)
        {
            var length = arr.Length;

            // When there is only a single element in "unsorted" partition, the whole array is sorted.
            var threshold = length - 1;

            int indexOfUnsortedStart = 0;
            
            while (indexOfUnsortedStart < threshold)
            {
                ref var unsortedStartSlot = ref arr[indexOfUnsortedStart];

                ref var currentLowestSlot = ref unsortedStartSlot;

                var currentLowestValue = currentLowestSlot;
                
                for (int cursorIndex = indexOfUnsortedStart + 1; cursorIndex < length; cursorIndex++)
                {
                    ref var cursorSlot = ref arr[cursorIndex];

                    var cursorValue = cursorSlot;
                    
                    if (cursorValue < currentLowestValue)
                    {
                        currentLowestValue = cursorValue;
                        currentLowestSlot = ref cursorSlot;
                    }
                }
                
                // Swap value of the lowest slot ( Unsorted partition ) with unsortedStartSlot

                // Swap
                (unsortedStartSlot, currentLowestSlot) = (currentLowestSlot, unsortedStartSlot);

                indexOfUnsortedStart++;
            }
        }
    }
}