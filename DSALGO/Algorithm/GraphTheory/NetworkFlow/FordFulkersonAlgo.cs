using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.NetworkFlow {
    public static class FordFulkersonAlgo {
        static GraphList Residual;
        static NetworkList Network;
        static bool[] visited;
        static int[] previous;
        public static void Init(NetworkList network) {
            Network = network;
            Residual = network.ToResidualGraph();
            visited = new bool[network.NodeCount];
            previous = new int[network.NodeCount];
        }
        public static void Reset() {
            Array.Fill(visited, false);
            Array.Fill(previous, -1);
        }
        private static int GetAugmentingPath(ref List<int> path) {
            Reset();
            throw new NotImplementedException();
        }
        private static void DFS() {
            int source = Network.Source;
            int sink = Network.Sink;

            Stack<int> stack = new Stack<int>();
            stack.Push(source); 
            visited[source] = true;
            while(stack.Count > 0) {
                int pop = stack.Pop();
                if(pop == sink) {
                    
                }
                
                visited[pop] = true;
                foreach (var link in Residual.GetAdjLinks(pop)) {
                    if (!visited[link.to]) { 
                        stack.Push(link.to);
                        previous[link.to] = pop;
                    }
                }
            }
        }
        private static List<int> BuildPath(int start , int end) {
            List<int> path = new();
            for (int i = end; i  != start ; i = previous[i]) {
                path.Add(i);
            }
            return path;
        }
    }
}
