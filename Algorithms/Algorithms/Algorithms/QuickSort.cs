using System;

namespace Algorithms
{
    public class QuickSort
    {
        /*QuickSort is an O(NLog(N)) divide and conquer sorting algorithm that performs and average of Log(N)
		steps of its partition function which is O(N). Need in place and stable here*/
        public static void quicksort(int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            quicksort(array, low, high);
        }

        private static void quicksort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = partition(array, low, high);
                quicksort(array, low, pivotIndex - 1);
                quicksort(array, pivotIndex, high);
            }
        }

        //Key will be the high value for this partition function. Partition is a linear O(N) time algorithm
        private static int partition(int[] array, int low, int high)
        {
            int left = low;
            int right = high;
            int temp;

            //Start by choosing the pivot to be the last value in the array and decrement the right pointer
            int pivot = array[right];
            right--;

            while (left <= right)
            {

                //Increment low if the low index value is greater than the pivot index value
                //It is already correctly partitioned. Swap and decrement the pivot otherwise.
                if (array[left] <= pivot)
                {
                    left++;
                }
                else
                {
                    temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;

                    right--;
                }
            }

            //Swap pivot to the right + 1 index at the end of the loop
            temp = array[right + 1];
            array[right + 1] = array[high];
            array[high] = temp;

            return right + 1;
        }

        public static void printArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.Write(array[array.Length - 1]);
            Console.Write("]");

            //Console.Read() holds console open until closed
            Console.Read();
        }

        public static void Main(string[] args)
        {
            int[] sort = { 2, 5, 8, 3, 8, 34, 4, 45, 6, 45, 23, 45, 6, 23, 4, 2, 2, 44 };
            quicksort(sort);
            printArray(sort);
        }
    }
}
