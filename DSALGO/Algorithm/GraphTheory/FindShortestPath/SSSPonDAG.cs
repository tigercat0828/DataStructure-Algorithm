using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public class SSSPonDAG {

        readonly Graphz graph;
        public SSSPonDAG(Graphz graph) {
            this.graph = graph;
        }
        public List<int> FindPath(int start, int end, out double cost) {
            if (start == end) {
                cost  = 0;
                return new List<int> { start };
            }
            
            if (!graph.Contains(start) || !graph.Contains(end)) {
                Console.WriteLine($"Node [{start}] or [{end} is not in graph]");
                cost = 1;
                return null;
            }
            
            double[] costs = new double[graph.nodeCount];
            int[] previous = new int[graph.nodeCount];

            Array.Fill(previous, -1);
            Array.Fill(costs, int.MaxValue);

            TopologicalSort sorter = new TopologicalSort(graph);
            List<int> sortingResult = sorter.Topsort().ToList();
            // sortingResult.Print();

            costs[start] = 0;

            foreach (var next in sortingResult) {
                List<Link> linkEdges = graph.GetAdjacentEdges(next);
                if (linkEdges != null) {
                    foreach (var edge in linkEdges) {
                        int dest = edge.dest;
                        double cst = edge.cost;
                        if (costs[next] + cst < costs[dest]) {
                            costs[dest] = costs[next] + cst;
                            previous[dest] = next;
                        }
                    }
                }
            }
            
            costs.Print();
            // construct path
            List<int> path = new();
            path.Add(end);
            int current = end;
            while(current != start) {
                path.Add(previous[current]);
                current = previous[current];
            }
            path.Reverse();

            cost = costs[end];
            return path;
        }
    }
}
