

using DSALGO.DataStructures.Graph;

namespace DSALGO.Algorithm.Graph {
    /// <summary>
    /// For DAG, Directed Acyclic Graph
    /// </summary>
    public class TopologicalSort {
        List<int> result = new List<int>();
        HashSet<int> visited = new HashSet<int>();

        public List<int> FindDagShortestPath() {
            throw new NotImplementedException();
        }
        public List<int> Topsort(AdjacencyList graph) {

            List<int> nodes = graph.GetAllNodes();
            foreach (var node in nodes) {
                if (visited.Contains(node)) continue;
                DFS(node, graph);
            }
            return result;
        }
        private void DFS(int node, AdjacencyList graph) {
            if (visited.Contains(node)) return;
            result.Add(node);
            visited.Add(node);
            foreach (var next in graph[node]) {
                if (visited.Contains(next)) continue;
                DFS(next, graph);
            }
        }
    }
}
