using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.Sorting {
    public static class CountingSort {
        // O(n) non-comparison
        public static void Run(int[] nums) {
            int min = nums.Min();
            int max = nums.Max();
            int range = max - min +1;
            int[] count = new int[range];
            int[] ans = new int[nums.Length+1];
            
            // counting
            for (int i = 0; i < nums.Length; i++) {
                int index = nums[i] - min;  // align to zero
                count[index]++;
            }
            count.Print();
            // calc prefix
            for (int i = 1; i < count.Length; i++) {
                count[i] += count[i - 1];
            }
            count.Print();
            for (int i = 0; i < nums.Length; i++) {
                int newIndex = count[nums[i]-min]++;
                Console.WriteLine($"{newIndex}, {nums[i]}");
                ans[newIndex] = nums[i];
            }
            nums = ans;
        }
    }
}
