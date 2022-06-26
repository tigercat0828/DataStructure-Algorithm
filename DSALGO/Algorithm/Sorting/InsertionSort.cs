namespace DSALGO.Algorithm {
    public static class InsertionSort {

        /*
        Time Ccomplexity : O(n^2)
        stable : yes
        in-place : yes
         */
        public static void Run(int[] arr) {
            for (int i = 1; i < arr.Length; i++) {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && key < arr[j]) {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
