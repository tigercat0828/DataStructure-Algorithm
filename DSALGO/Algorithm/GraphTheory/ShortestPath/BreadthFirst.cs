using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    public class BreadthFirst {
        private readonly Graph graph;
        int[] previous;
        bool[] visited;
        public BreadthFirst(Graph graph) {
            this.graph = graph;
            previous = new int[graph.MaxID];
            visited = new bool[graph.MaxID];
        }
        public (List<int> path, int cost)  FindPath(int start, int end) {

            if (start == end) {
                return (new List<int>() { start}, 0);
            }
            
            Queue<int> queue = new();

            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0) {
                int pop = queue.Dequeue();
                if (pop == end) break;

                foreach (var node in graph.GetAdjacentNodes(pop)) {
                    if (visited[node]) continue;
                    queue.Enqueue(node);
                    visited[node] = true ;
                    previous[node] = pop;
                }
            }
            List<int> path = BuildPath(start, end);
            return (path, path.Count);
        }
        public List<int> BuildPath(int start, int end) {
            List<int> path = new List<int>();
            for (int i = end; i != start; i = previous[i]) {
                path.Add(i);
            }
            path.Add(start);
            path.Reverse();
            return path;
        }

    }
}
