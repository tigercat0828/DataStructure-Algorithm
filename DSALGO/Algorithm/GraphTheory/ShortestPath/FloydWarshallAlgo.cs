using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    public class FloydWarshallAlgo {

        double[][] dp;
        int[][] next;
        int size;
        private void Setup(GraphMatrix graph) {
            dp = graph.GetMatrix();
            size = dp.Length;
            int[][] next = new int[size][];         // for build path
            for (int i = 0; i < size; i++) {
                next[i] = new int[size];
            }
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (dp[i][j] != GraphMatrix.X) {
                        next[i][j] = j;
                    }
                }
            }
        }
        public FloydWarshallAlgo(GraphMatrix graph) {
            // setup
            Setup(graph);
            // perform algo
            for (int k = 0; k < size; k++) {
                for (int i = 0; i < size; i++) {
                    for (int j = 0; j < size; j++) {
                        if (dp[i][k] + dp[k][j] < dp[i][j]) {
                            dp[i][j] = dp[i][k] + dp[k][j];
                            next[i][j] = next[i][k];
                        }
                    }
                }
            }
        }
        public double GetPathCost(int start, int end) => dp[start][end];
        public List<int> FindPath(int start, int end) {

            if (dp[start][end] == GraphMatrix.X) {
                return new List<int>();
            }
            List<int> path = new();
            int at;
            for (at = start; at != end; at = next[at][end]) {
                if (at == -1) return path;     // there is no path from start to end
                path.Add(at);
            }
            if (next[at][end] == -1) return path;
            path.Add(end);
            return path;
        }
        private void CheckNegativeCycle() {
            for (int k = 0; k < size; k++) {
                for (int i = 0; i < size; i++) {
                    for (int j = 0; j < size; j++) {
                        if (dp[i][k] + dp[k][j] < dp[i][j]) {
                            dp[i][j] = -GraphMatrix.X;
                            next[i][j] = -1;
                        }
                    }
                }
            }
        }
    }
}
