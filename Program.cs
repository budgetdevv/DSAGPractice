using System;
using System.Linq;

namespace SortingAlgorithmsPractice
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int SIZE = 10, SHUFFLE_COUNT = 10, HIGHEST_NUM = 1000;
            
            var random = new Random();

            var arr = new int[SIZE];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, HIGHEST_NUM + 1);
            }
            
            for (int i = 1; i <= SHUFFLE_COUNT; i++)
            {
                ShuffleArray(arr, random);
            }

            arr.PrintArray();

            var copy = arr.ToArray();
            
            BubbleSort(copy);

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

                    if (rightIndex == remainingLength)
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
    }
}