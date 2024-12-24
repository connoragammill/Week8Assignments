using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Week8Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int[] arr = { 12, 34, 54, 2, 3 }; 
            Console.WriteLine("Original array:"); 
            PrintArray(arr); 
            ShellSort(arr); 
            Console.WriteLine("Shell sorted array:"); 
            PrintArray(arr);

			int[] arr2 = { 12, 34, 54, 2, 3 };
			Console.WriteLine("Original array:");
			PrintArray2(arr2);
			MergeSort(arr2);
			Console.WriteLine("Merge sorted array:");
			PrintArray2(arr2);

			int[] arr3 = { 12, 34, 54, 2, 3 };
			Console.WriteLine("Original array:");
			PrintArray3(arr3);
			QuickSort(arr3, 0, arr3.Length - 1);
			Console.WriteLine("Quick sorted array:");
			PrintArray3(arr3);
		}

		static void ShellSort(int[] arr)
		{
			int n = arr.Length;
			for (int gap = n / 2; gap > 0; gap /= 2)
			{
				for (int i = gap; i < n; i += 1)
				{
					int temp = arr[i];
					int j;
					for (j = i; j >= gap && arr[j -  gap] > temp; j -= gap)
					{
						arr[j] = arr[j - gap];
					}
					arr[j] = temp;
				}
			}
		}

		static void MergeSort(int[] arr2)
		{
			if (arr2.Length < 2)
			{
				return;
			}

			//number of elements in the left half of the array
			int leftLength = arr2.Length / 2;
			//number of the elements of the right half of the array
			int rightLength = arr2.Length - leftLength;

			//container for the elements in the left half and the right half of the array
			int[] leftArray = new int[leftLength];
			int[] rightArray = new int[rightLength];

			Array.Copy(arr2, 0, leftArray, 0, leftLength);//the elements in the array starting from the 0th position, copy them into the leftArray at the 0th position
			Array.Copy(arr2, leftLength, rightArray, 0, rightLength);//the elements in the array starting from the left length which is half. Copy them into the rightArray at the 0th position

			MergeSort(leftArray);
			MergeSort(rightArray);
			SortArray(arr2, leftArray, rightArray);
		}

		static void SortArray(int[] sortedArray, int[] leftArray, int[] rightArray)
		{ 
			int left = 0;
			int right = 0;
			int sorted = 0;

			while (left < leftArray.Length && right < rightArray.Length)
			{
				if (leftArray[left] <= rightArray[right])
				{
					sortedArray[sorted++] = leftArray[left++];

				}
				else
				{
					sortedArray[sorted++] = rightArray[right++];
				}
			}

			while(left < leftArray.Length)
			{
				sortedArray[sorted++] = leftArray[left++];
			}

			while (right < rightArray.Length)
			{
				sortedArray[sorted++] = rightArray[right++];
			}
		}

		static void QuickSort(int[] arr3, int left, int right)
		{
			if ( left < right )
			{
				var pi = Partition(arr3, left, right);
				QuickSort(arr3, left, pi - 1);
				QuickSort(arr3, pi + 1, right);
			}
		}

		static void Swap(int[] arr3, int i, int j)
		{
			int t = arr3[i];
			arr3[i] = arr3[j];
			arr3[j] = t;
		}
		

		static int Partition(int[] arr3, int left, int right)
		{
			int index = left;
			int pivot = arr3[left];

			for (int i = left + 1; i <= right; i++)
			{
				if (arr3[i] < pivot)
				{
					index++;
					Swap(arr3, index, i);
				}
			}
			Swap(arr3, index, left);
			return index;
		}

		static void PrintArray(int[] arr)
		{
			foreach (int i in arr)
			{
				Console.WriteLine(i + " ");
			}
			Console.WriteLine();
		}

		static void PrintArray2(int[] arr2)
		{
			foreach (int i in arr2)
			{
				Console.WriteLine(i + " ");
			}
			Console.WriteLine();
		}

		static void PrintArray3(int[] arr3)
		{ 
			foreach (int i in arr3)
			{
				Console.WriteLine(i + " ");
			}
			Console.WriteLine();
		}
    }
}
