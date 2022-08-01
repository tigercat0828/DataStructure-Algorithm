using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public static class FloydWarshall {
        public static double FindPath(GraphMatrix graph, int start, int end , ref List<int> path) {
            double[][] dp = graph.GetMatrix();
            int size = dp.Length;
            for (int k = 0; k < size; k++) {
                for (int i = 0; i < size; i++) {
                    for (int j = 0; j < size; j++) {
                        if (dp[i][k] + dp[k][j] < dp[i][j]) {
                            dp[i][j] = dp[i][k] + dp[k][j];
                        }
                    }
                }
            }
            dp.PrintMatix();
            return dp[start][end];
        }
    }
}
