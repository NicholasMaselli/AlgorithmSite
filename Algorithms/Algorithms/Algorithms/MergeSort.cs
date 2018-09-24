using System;

public class MergeSort
{
    public static void mergesort(int[] array)
    {
        int low = 0;
        int high = array.Length - 1;

        mergesort(array, low, high);
    }

    private static void mergesort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int middle = low + (high - low) / 2;

            mergesort(array, low, middle);
            mergesort(array, middle + 1, high);

            merge(array, low, high, middle);
        }
    }

    private static void merge(int[] array, int low, int high, int middle)
    {
        int leftSize = middle - low + 1;
        int rightSize = high - middle;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        //Place data in these temporary arrays
        for (int index = 0; index < leftSize; index++)
        {
            leftArray[index] = array[low + index];
        }

        for (int index = 0; index < rightSize; index++)
        {
            rightArray[index] = array[middle + 1 + index];
        }

        int i = 0;
        int j = 0;

        int k = low;
        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        //Add the remaining elements to the input array
        while (i < leftSize)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightSize)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
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
        
    /*
    public static void Main(string[] args)
    {
        int[] sort = { 2, 5, 8, 3, 8, 34, 4, 45, 6, 45, 23, 45, 6, 23, 4, 2, 2, 44 };
        mergesort(sort);
        printArray(sort);
    }
    */
}