using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.DynamicProgramming {
    public class The01Knapsnack {
        int[][] dp;
        public int GetMaxProfit(int[] values, int[] weights, int capacity) {
            int itemCount = values.Length;
            dp = new int[itemCount][];
            for (int i = 0; i < itemCount; i++) {
                dp[i] = new int[capacity + 1];
            }
            for (int i = 1; i < itemCount; i++) {
                for (int j = 0; j <= capacity; j++) {
                    dp[i][j] = dp[i - 1][j];
                    if (j >= weights[i])
                        dp[i][j] = Math.Max(dp[i - 1][j - weights[i]] + values[i], dp[i - 1][j]);
                }
            }
        
            // backtrack the answer
            int r = itemCount - 1;
            int c = capacity;
            int maxProfit = dp[r][c];
            List<int> pickedItems = new List<int>();
            while(r!=0 && c != 0) {
                if (dp[r][c] != dp[r - 1][c]) {
                    pickedItems.Add(r);
                    
                    c -= weights[r];
                }
                r--;
            }
            pickedItems.Print();
            return maxProfit;
        }
        public void ShowDPtable() {
            for (int i = 0; i < dp.Length; i++) {
                for (int j = 0; j < dp[0].Length; j++) {
                    Console.Write(dp[i][j].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
        }
    }
}
