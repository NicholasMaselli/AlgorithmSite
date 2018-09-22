using System;

namespace Algorithms
{
    public class QuickSort
    {
		/*QuickSort is an O(NLog(N)) divide and conquer sorting algorithm that performs and average of Log(N)
		steps of its partition function which is O(N). Need in place and stable here*/		
		public static void QuickSort(int[] array) {
			int low = 0;
			int high = array.Length - 1;
			QuickSort(array, low, high);
		}
		
		private static void QuickSort(int[] array, int low, int high) {
			if (low < high) {
				int pivot = partition(array, low, high);				
				QuickSort(array, low, pivot-1);
				QuickSort(array, pivot, high);
			}
		}
		
		/*Key will be the high value for this partition function. Partition is a
		1 pass linear O(N) time algorithm*/
		private static int partition(int[] array, int low, int high) {
		
			//Ensure low and high are within bounds
			/*
			if (low < 0 || high >= array.Length) {
				return 0;
			}
			*/
			
			int temp;
			int pivot = high;
			while (low <= pivot) {
				
				//Increment low if the low index value is greater than the pivot index value
				//It is already correctly partitioned. Swap and decrement the pivot otherwise.
				if (array[low] <= array[pivot]) {
					low++;
				}
				else {
					temp = array[low];
					array[low] = array[pivot];
					array[pivot] = temp;
					
					pivot--;
				}				
			}
			
			return pivot;
		}
	
		public static void Main(string[] args) {			
			int[] sort = {2, 5, 8, 3, 8, 34, 4, 45, 6, 45, 23, 45, 6,23 4, 2, 2, 44};
			QuickSort(sort);
		}
    }
}
