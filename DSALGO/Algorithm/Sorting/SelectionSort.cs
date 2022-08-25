namespace DSALGO.Algorithm.Sorting {
    public static class SelectionSort {

        /*
        Time Complexity : O(n^2)
        stable : no
        in-pace : yes
         */
        public static void Run(int[] arr) {
            int min = 0;

            for (int i = 0; i < arr.Length; i++) {
                for (int j = i; j < arr.Length; j++) {
                    if (arr[j] < arr[min]) {
                        min = j;
                    }
                }
                // swap(arr[i], arr[min])
                int tmp = arr[i];
                arr[i] = arr[min];
                arr[min] = tmp;
                arr.Print();
            }
        }
    }
}
