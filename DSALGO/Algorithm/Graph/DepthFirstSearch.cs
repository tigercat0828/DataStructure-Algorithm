using DSALGO.DataStructures.Graph;

namespace DSALGO.Algorithm.Graph {
    public class DepthFirstSearch {

        public List<int> Traversal(AdjacencyList graph, int start) {
            if (!graph.Contains(start)) return new List<int>();
            Stack<int> stack = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            List<int> path = new List<int>();
            stack.Push(start);
            while (stack.Count > 0) {
                int pop = stack.Pop();

                if (!visited.Contains(pop)) {
                    path.Add(pop);
                    visited.Add(pop);
                }

                foreach (var node in graph[pop]) {
                    if (visited.Contains(node)) continue;
                    stack.Push(node);

                }
            }
            return path;
        }
    }
}
