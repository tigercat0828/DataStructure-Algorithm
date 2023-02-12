namespace DSALGO.Algorithm {
    public class QuickSort1 {
        public void Run(int[] A) {
            sort(A, 0, A.Length - 1);
        }
        private void sort(int[] nums, int left, int right) {
            if (left < right) {
                int pivot = LumotoPartition(nums, left, right);
                sort(nums, left, pivot - 1);
                sort(nums, pivot + 1, right);
            }
        }

        private int LumotoPartition(int[] nums, int left, int right) {
            int pivot = right;
            int i = left;
            int j = left;
            while (j != pivot) {
                if (nums[j] < nums[pivot]) {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    i++;
                }
                j++;
            }
            (nums[i], nums[pivot]) = (nums[pivot], nums[i]);
            return i;

        }
    }
}
