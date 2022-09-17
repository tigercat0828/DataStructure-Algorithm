using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {
    public class TopsortOnDAG {
        // Time Complexity O(n)
        // weight of edge can be negative

        const int MAX_VALUE = 1000000000;
        readonly Graph graph;
        int[] costs;
        TopologicalSort sorter;
        int[] previous;
        public TopsortOnDAG(Graph graph) {

            this.graph = graph;
            sorter = new(graph);
            previous = new int[graph.NodeCount];
            costs = new int[graph.NodeCount];

            Reset();
        }
        public int[] GetCosts() => costs;

        public (List<int> path, int cost) FindPath(int start, int end) {
            Reset();
            if (start == end) {
                return (new List<int>(), 0);
            }
            if (CheckNodeInvalid(start, end)) return (null, 0);
            List<int> sortingResult = sorter.Topsort().ToList();
            // sortingResult.Print();

            costs[start] = 0;

            foreach (var node in sortingResult) {

                foreach (var edge in graph.GetAdjacentEdges(node)) {
                    int to = edge.to;
                    int goCost = edge.weight;
                    if (costs[node] + goCost < costs[to]) {
                        costs[to] = costs[node] + goCost;
                        previous[to] = node;
                    }
                }

            }

            List<int> path = BuildPath(start, end);
            return (path, costs[end]);
        }
        private List<int> BuildPath(int start, int end) {
            List<int> path = new();
            path.Add(end);
            int current = end;
            while (current != start) {
                path.Add(previous[current]);
                current = previous[current];
            }
            path.Reverse();
            return path;
        }
        void Reset() {
            Array.Fill(previous, -1);
            Array.Fill(costs, MAX_VALUE);
        }
        public bool CheckNodeInvalid(int start, int end) {
            return !graph.ContainsNode(start) || !graph.ContainsNode(end);
        }
    }
}
