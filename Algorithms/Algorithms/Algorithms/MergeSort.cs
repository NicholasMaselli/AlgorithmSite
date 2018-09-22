using system;

namespace Algorithms
{
	public class MergeSort
	{
		public static void MergeSort(int[] array) {
			int low = 0;
			int high = array.Length - 1;
						
			MergeSort(array, low, high, middle);
		}
		
		private static void MergeSort(int array[], int low, int high){
			if (low < high) {
				int middle = low + (high-low)/2;
				
				MergeSort(array, low, middle);
				MergeSort(array, middle + 1, high);
				
				merge(array, low, high, middle);
			}			
		}
		
		private static void merge(int[] array, int low, int high, int middle) {
			int leftSize = middle - low + 1;
			int rightSize = high - middle;
			
			int[] leftArray = new int[leftSize];
			int[] rightArray = new int[rightSize];
			
			//Place data in these temporary array
			for (int i = 0; i < leftSize; i++) {
				leftArray[i] = array[low + i];
			}
			
			for (int j = 0; j < rightSize; j++) {
				rightArray[j] = array[middle + 1 + j];
			}
			
			int i = 0;
			int j = 0;
			
			int k = low;
			while (i < leftSize && j < rightSize) {
				if (leftArray[i] <= rightArray[j]) {
					array[k] = leftArray[i];
					i++;
				}
				else {
					array[k] = rightArray[j];
					j++
				}
				k++;
			}
			
			//Add the remaining elements to the input array
			while(i < leftSize) {
				array[k] = leftArray[i];
				i++;
				k++;
			}
			
			while(j < rightSize) {
				array[k] = rightArray[j];
				j++;
				k++;
			}			
		}
	
		public static void Main(string[] args) {
			
		}
	}
}