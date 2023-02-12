using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.ShortestPath {

    // Time Complexity : O(VE)
    // edge weight can be negative
    /*  s到v經過k個邊所需的cost
        D[s,v,k] =  {   0                 
                    {   infinite
                    {   min(D[s,v,k-1], min (u,v)belong Es {D[s,u,k-1]+w(u,v)} )
    */
    public class BellmanFord {
        const int IN_NEGATIVE_CYCLE = int.MinValue;
        const int UNVISITED = int.MaxValue;
        private readonly List<Edge> edgeList;

        int[] costs;
        int[] previous;
        int nodeCount;
        public BellmanFord(DGraph graph) {
            edgeList = graph.ToEdgeList();
            nodeCount = graph.NodeCount;
            costs = new int[nodeCount];
            previous = new int[nodeCount];
            Array.Fill(costs, UNVISITED);
            Array.Fill(previous, -1);
        }
        public int[] GetCosts() => costs;
        public (List<int> path, int cost) FindPath(int start, int end) {

            costs[start] = 0;
            for (int i = 0; i < nodeCount - 1; i++) {
                foreach (var edge in edgeList) {
                    if (costs[edge.from] + edge.weight < costs[edge.to]) {
                        costs[edge.to] = costs[edge.from] + edge.weight;
                        previous[edge.to] = edge.from;
                    }
                }
            }
            PropagandaNegativeCycle();

            return (BuildPath(start, end), costs[end]);
        }
        private void PropagandaNegativeCycle() {
            // check node caught in negative cycle
            for (int i = 0; i < nodeCount - 1; i++) {
                foreach (var edge in edgeList) {
                    if (costs[edge.from] + edge.weight < costs[edge.to]) {
                        costs[edge.to] = IN_NEGATIVE_CYCLE;
                    }
                }
            }
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