namespace DSALGO.Algorithm.DynamicProgramming {
    public class MaximumSubarray {
        public int GetMaxSubarray(int[] nums) {
            int local = 0;
            int global = 0;
            for (int i = 0; i < nums.Length; i++) {
                local = Math.Max(local + nums[i], 0);
                global = Math.Max(global, local);
            }
            return global;
        }
    }
}
