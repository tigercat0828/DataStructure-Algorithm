using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.DynamicProgramming {
    public class MinimumEditDistance {

        int match;
        int miss;
        int delete;
        int insert;
        int[][] dp;
        public MinimumEditDistance(int match, int miss, int delete, int insert) {
            this.match = match;
            this.miss = miss;
            this.delete = delete;
            this.insert = insert;
        }

        public string GetAlignedString(string A,string B) {
            // allocate space
            A = "-" + A;
            B = "-" + B;
            dp = new int[A.Length][];
            for (int i = 0; i < A.Length; i++) {
                dp[i] = new int[B.Length];
            }
            // initial boundary case
            for (int i = 0; i < A.Length; i++) {
                dp[i][0] = i* delete;
            }
            for (int i = 0; i < B.Length; i++) {
                dp[0][i] = i * insert;
            }
            for (int i = 1; i < A.Length; i++) {
                for (int j = 1; j < B.Length; j++) {
                    int del = dp[i - 1][j] + delete;
                    int ins = dp[i][j-1] + insert;
                    int tmp = (A[i] == B[j]) ? match : miss;
                    int mat = dp[i - 1][j - 1] + tmp;
                    dp[i][j]= Math.Max(Math.Max(del, ins), mat);
                }
            }
            // backtrack the answer
            StringBuilder strBuilder = new();
            int r = dp.Length - 1;
            int c = dp[0].Length - 1;
            while (r != 0 && c != 0) {
                if (A[r] == B[c]) {
                    strBuilder.Append(A[r]);
                    r--; c--;
                    continue;
                }
                if (dp[r - 1][c - 1] + miss == dp[r][c]) {
                    strBuilder.Append(B[c]);
                    r--;c--;
                    continue;
                }
                if (dp[r - 1][c] + delete == dp[r][c]) {
                    strBuilder.Append("-");
                    r--;
                    continue;
                }
                if (dp[r][c-1] + insert == dp[r][c]) {
                    strBuilder.Append("-");
                    c--;
                    continue;
                }
            }
            char[] result = strBuilder.ToString().ToCharArray();
            Array.Reverse(result);
            return new string(result);
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
/*
MinimumEditDistance algo = new(1, -1, -2, -2);
string result = algo.GetAlignedString("AGCT", "ATGCT");
Console.WriteLine(result);
algo.ShowDPtable();
*/