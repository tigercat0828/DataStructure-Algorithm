namespace DSALGO.Algorithm.Sorting {
    public static class QuickSort<T> where T : IComparable {

        public static void Run(T[] nums) {
            quickSort(nums, 0, nums.Length - 1);
        }
        private static int LumotoPartition(T[] nums, int left, int right) {
            int pivot = right;
            int i = left;
            int j = left;
            while (j != pivot) {
                int cmp = nums[j].CompareTo(nums[pivot]);
                if (cmp < 0) {
                    // swap (i,j)
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    i++;
                }
                j++;
            }
            (nums[i], nums[pivot]) = (nums[j], nums[i]);
            Console.Write($"Partition {left}, {right}  pivot = {i}      ");
            nums.Print();

            return i;
        }
        public static void quickSort(T[] nums, int left, int right) {
            if (left < right) {
                int pivot = LumotoPartition(nums, left, right);
                quickSort(nums, left, pivot - 1);
                quickSort(nums, pivot + 1, right);
            }
        }

    }
}
