namespace DSALGO.Algorithm.Sorting {
    public static class HeapSort<T> where T : IComparable {
        public static void Sort(T[] array) {
            int half = (array.Length - 1) / 2;
            int end = array.Length - 1;

            for (int i = half; i >= 0; i--) {
                MaxHeapify(array, i, end);
            }

            for (int i = array.Length - 1; i >= 0; i--) {
                (array[0], array[i]) = (array[i], array[0]);    // swap(i,0)
                MaxHeapify(array, 0, i - 1);
            }
        }

        private static void MaxHeapify(T[] array, int index, int end) {
            while (true) {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int largest = -1;
                if (left <= end && array[index].CompareTo(array[left]) < 0) {
                    largest = left;
                }
                if (right <= end && array[index].CompareTo(array[right]) < 0) {
                    if (array[right].CompareTo(array[left]) > 0) largest = right;
                }
                if (largest == -1) break;
                // swap
                (array[index], array[largest]) = (array[largest], array[index]);
                index = largest;    // sink down
            }
        }

    }
}
