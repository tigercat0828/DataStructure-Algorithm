

using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory {
    /// <summary>
    /// For DAG, Directed Acyclic Graph
    /// </summary>
    public class TopologicalSort {
        bool[] isVisited;
        int[] result;
        int nodeCount;
        int currIdx;
        readonly DGraph graph;

        public TopologicalSort(DGraph graph) {
            this.graph = graph;
            nodeCount = graph.NodeCount;
            isVisited = new bool[nodeCount];
            result = new int[nodeCount];
            currIdx = nodeCount - 1;
        }
        public int[] Topsort() {

            List<int> nodes = graph.GetAllNodes();
            foreach (var node in nodes) {
                if (isVisited[node]) continue;
                DFS(node);
            }
            return result;
        }
        private void DFS(int node) {
            // postorder DFS
            if (isVisited[node]) return;
            isVisited[node] = true;

            foreach (var dest in graph.GetAdjacentNodes(node)) {
                if (isVisited[dest]) continue;
                DFS(dest);
            }
            result[currIdx--] = node;
        }
    }
}
