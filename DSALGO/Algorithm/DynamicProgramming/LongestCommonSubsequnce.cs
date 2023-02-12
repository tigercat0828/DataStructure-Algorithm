using System.Text;

namespace DSALGO.Algorithm.DynamicProgramming {
    public class LongestCommonSubsequence {
        int[,] dp;
        public string GetLCS(string A, string B) {

            A = A.Insert(0, "*");
            B = B.Insert(0, "-");

            int row = A.Length;
            int col = B.Length;
            dp = new int[row, col];
            for (int i = 1; i < row; i++) {
                for (int j = 1; j < col; j++) {
                    if (A[i] == B[j]) {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            StringBuilder strBuilder = new(50);
            int r = A.Length - 1;
            int c = B.Length - 1;
            while (dp[r, c] != 0) {
                if (A[r] == B[c]) {
                    strBuilder.Append(A[r]);
                    r--;
                    c--;
                }
                else {
                    if (dp[r, c] == dp[r, c - 1]) c--;
                    if (dp[r, c] == dp[r - 1, c]) r--;
                }
            }

            char[] result = strBuilder.ToString().ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }
        public void ShowDPtable() {
            for (int i = 0; i < dp.GetLength(0); i++) {
                for (int j = 0; j < dp.GetLength(1); j++) {
                    Console.Write(dp[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
