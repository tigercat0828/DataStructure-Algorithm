namespace DSALGO.Algorithm.Sorting {
    public class QuickSort2 {
        public void Run(int[] A) {
            sort(A, 0, A.Length);
        }
        private void sort(int[] A, int left, int right) { 
            if(left < right) {
                int pivot = (left + right) / 2;
                int i = left;
                int j = right;
                while (i < j) {
                    if (A[i] < A[pivot]) i++;

                }
                sort(A, left, pivot - 1);
                sort(A, pivot + 1, right);
            }
        }
    }
}
