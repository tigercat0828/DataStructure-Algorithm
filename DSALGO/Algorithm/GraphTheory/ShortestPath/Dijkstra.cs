using DSALGO.DataStructure.GraphStructure;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    public class Dijkstra {
        // edge weight must be positive
        // O((E+V)lgV) for heap
        // O(E+VlgV) for fib-heap

        private readonly Graph graph;
        bool[] visited;
        int[] costs;
        int[] previous;
        IndexedPriorityQueue<int, int> queue;
        public Dijkstra(Graph graph) {
            this.graph = graph;
            queue = new();
            visited = new bool[graph.NodeCount];
            costs = new int[graph.NodeCount];
            previous = new int[graph.NodeCount];
            Array.Fill(costs, int.MaxValue);
            Array.Fill(previous, -1);
        }

        public (List<int> path, int cost) FindPath(int start, int end) {

            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                return (null, 0);
            }
            if (start == end) {
                return (new() { start }, 0);
            }
            queue.Enqueue(start, 0);
            costs[start] = 0;

            while (queue.Count > 0) {
                int node = queue.Dequeue();
                visited[node] = true;

                foreach (var edge in graph.GetAdjacentEdges(node)) {
                    if (visited[edge.to]) continue;

                    if (costs[node] + edge.weight < costs[edge.to]) {
                        costs[edge.to] = costs[node] + edge.weight;

                        queue.Enqueue(edge.to, costs[edge.to]);
                        previous[edge.to] = node;
                    }
                }
            }
            return (BuildPath(start, end), costs[end]);
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
