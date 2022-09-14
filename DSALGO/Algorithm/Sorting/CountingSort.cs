namespace DSALGO.Algorithm.Sorting {
    public static class CountingSort {
        // O(n) non-comparison
        public static void Run(int[] nums) {

            int max = nums.Max();
            int len = nums.Length;
            int[] count = new int[max + 1];
            int[] prefix = new int[max + 1];

            for (int i = 0; i < len; i++) {
                count[nums[i]]++;
            }
            // shift right
            for (int i = 1; i < count.Length; i++) {
                prefix[i] = count[i - 1];
            }
            // calc prefix sum
            for (int i = 1; i < count.Length; i++) {
                prefix[i] += prefix[i - 1];
            }
            int[] result = new int[len];
            for (int i = 0; i < len; i++) {
                int index = prefix[nums[i]]++;
                result[index] = nums[i];

            }
            Array.Copy(result, nums, len);
        }
    }
}
