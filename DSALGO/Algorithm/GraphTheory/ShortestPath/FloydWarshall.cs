using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    // Dynamic Programming
    // Time Complexity : O(V^3)
    // Space Complexity : O(V^2)
    // All shortest path algo

    public class FloydWarshall {

        int[][] dp;
        int[][] next;
        public FloydWarshall(Graph graph) {
            dp = graph.ToMatrix();
            // Utility.PrintMatix(dp);
            int n = dp.Length;

            next = new int[n][];
            for (int i = 0; i < n; i++) {
                next[i] = new int[n];
                Array.Fill(next[i], -1);
            }

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dp[i][j] != Graph.CANT_REACH) next[i][j] = j;
                }
            }
            Run();
        }
        private void Run() {
            // perform algo
            int n = dp.Length;
            for (int k = 0; k < n; k++) {

                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        //Console.WriteLine($"Run({i}, {k} , {j})");
                        if (dp[i][k] + dp[k][j] < dp[i][j]) {
                            dp[i][j] = dp[i][k] + dp[k][j];
                            next[i][j] = next[i][k];
                        }
                    }
                }

                PrintIteration(k);
            }
        }
        private void PrintIteration(int k) {
            Console.WriteLine($"===================== {k}");
            for (int i = 0; i < dp.Length; i++) {
                for (int j = 0; j < dp[0].Length; j++) {
                    if (dp[i][j] >= Graph.CANT_REACH) {
                        Console.Write($"{"-",4}");
                    }
                    else {
                        Console.Write($"{dp[i][j],4}");
                    }
                }
                Console.WriteLine();
            }
        }
        public (List<int> path, int cost) FindPath(int start, int end) {

            if (dp[start][end] == Graph.CANT_REACH) {
                return (new(), 0);
            }
            List<int> path = new();

            int at;
            for (at = start; at != end; at = next[at][end]) {
                if (at == -1) return (new(), 0);      // there is no path from start to end
                path.Add(at);
            }
            if (next[at][end] == -1) return (new(), 0);

            path.Add(end);
            return (path, dp[start][end]);
        }
        private void CheckNegativeCycle() {
            int n = dp.Length;
            for (int k = 0; k < n; k++) {
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        if (dp[i][k] + dp[k][j] < dp[i][j]) {
                            dp[i][j] = -Graph.CANT_REACH;
                            next[i][j] = -1;
                        }
                    }
                }
            }
        }
    }
}
