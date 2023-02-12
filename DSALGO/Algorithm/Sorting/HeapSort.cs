namespace DSALGO.Algorithm.Sorting {
    public class HeapSort {

        public void Run(int[] A) {
            BuildMaxHeap(A);
            for (int i = A.Length - 1; i >= 0; i--) {
                (A[0], A[i]) = (A[i], A[0]);    // swap(A[0], A[1])
                Heapify(A, 0, i);
            }
        }
        private void BuildMaxHeap(int[] A) {
            for (int i = A.Length / 2; i >= 0; i--) {
                Heapify(A, i, A.Length);
            }
        }
        public void Heapify(int[] A, int root, int len) {
            int rootKey = A[root];
            int child = root * 2 + 1;
            while (child < len) {
                // choose leftchild or rightchild 
                if (child + 1 < len && A[child] < A[child + 1]) {
                    child++;
                }
                if (rootKey > A[child]) break;

                else {
                    A[(child - 1) / 2] = A[child];
                    child = child * 2 + 1;
                }
            }
            A[(child - 1) / 2] = rootKey;
        }
    }
}
