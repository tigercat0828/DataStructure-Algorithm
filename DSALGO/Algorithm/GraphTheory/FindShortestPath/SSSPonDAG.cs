using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public class SSSPonDAG {

        readonly GraphList graph;
        public SSSPonDAG(GraphList graph) {
            this.graph = graph;
        }
        public List<int> FindPath(int start, int end, out double cost) {
            if (start == end) {
                cost  = 0;
                return new List<int> { start };
            }
            
            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                Console.WriteLine($"Node [{start}] or [{end} is not in graph]");
                cost = 1;
                return null;
            }
            
            double[] costs = new double[graph.NodeCount];
            int[] previous = new int[graph.NodeCount];

            Array.Fill(previous, -1);
            Array.Fill(costs, int.MaxValue);

            List<int> sortingResult = TopologicalSort.Topsort(graph).ToList();
            // sortingResult.Print();

            costs[start] = 0;

            foreach (var next in sortingResult) {
                List<Edge> linkEdges = graph.GetAdjEdges(next);
                if (linkEdges != null) {
                    foreach (var edge in linkEdges) {
                        int dest = edge.to;
                        double cst = edge.weight;
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
        private List<int> BuildPath(int start, int end) {
            throw new NotImplementedException();
        }
    }
}
