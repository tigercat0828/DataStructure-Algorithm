
using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory {
    /// <summary>
    /// For DAG, Directed Acyclic Graph
    /// </summary>
    public static class TopologicalSort {
        static bool[] isVisited;
        static int[] result;
        static int nodeCount;
        static int currIdx;
        static GraphList Graph;

        private static void Init(GraphList graph) {
            Graph = graph;
            nodeCount = graph.NodeCount;
            isVisited = new bool[nodeCount];
            result = new int[nodeCount];
            currIdx = nodeCount - 1;
        }
        public static int[] Topsort(GraphList graph) {
            Init(graph);

            List<int> nodes = Graph.GetAllNodes();
            foreach (var node in nodes) {
                if (isVisited[node]) continue;
                DFS(node);
            }
            return result;
        }
        private static void DFS(int node) {
            // postorder DFS
            if (isVisited[node]) return;
            isVisited[node] = true;
            
            foreach (var dest in Graph.GetAdjNodes(node)) {
                if (isVisited[dest]) continue;
                DFS(dest);
            }
            result[currIdx--] = node;
        }
    }
}
