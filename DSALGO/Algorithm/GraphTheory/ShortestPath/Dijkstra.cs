using DSALGO.DataStructure.GraphStructure;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    public class Dijkstra {
        // edge weight must be positive
        // O((E+V)lgV) for heap
        // O(E+VlgV) for fib-heap

        private readonly DGraph graph;
        bool[] visited;
        int[] dists;
        int[] previous;
        IndexedPriorityQueue<int, int> queue;   // HEAP
        public Dijkstra(DGraph graph) {
            this.graph = graph;
            queue = new();
            visited = new bool[graph.MaxID];
            dists = new int[graph.MaxID];
            previous = new int[graph.MaxID];
            Array.Fill(dists, int.MaxValue);
            Array.Fill(previous, -1);
        }

        public (List<int> path, int cost) FindPath(int start, int end) {

            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                return (new(), 0);
            }
            if (start == end) {
                return (new() { start }, 0);
            }
            queue.Enqueue(start, 0);
            dists[start] = 0;

            while (queue.Count > 0) {
                int node = queue.Dequeue();
                visited[node] = true;

                foreach (var edge in graph.GetAdjacentEdges(node)) {
                    if (visited[edge.to]) continue;

                    if (dists[node] + edge.weight < dists[edge.to]) {
                        dists[edge.to] = dists[node] + edge.weight;

                        queue.Enqueue(edge.to, dists[edge.to]);
                        previous[edge.to] = node;
                    }
                }
            }
            return (BuildPath(start, end), dists[end]);
        }
        private List<int> BuildPath(int start, int end) {
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
