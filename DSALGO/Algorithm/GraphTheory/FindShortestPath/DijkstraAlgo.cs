using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public static class DijkstraAlgo {
        public static double FindPath(GraphList graph, int start, int end, ref List<int> path) {

            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                return 0;
            }
            IndexedPriorityQueue<int, double> queue = new(); // nodeID, currentCost
            bool[] isVisited = new bool[graph.NodeCount];
            double[] nodeCosts = new double[graph.NodeCount]; Array.Fill(nodeCosts, int.MaxValue);
            int[] previous = new int[graph.NodeCount]; Array.Fill(previous, -1);
            queue.Enqueue(start, 0);
            nodeCosts[start] = 0;

            while (queue.Count > 0) {
                int popNode = queue.Dequeue();
                // Console.WriteLine($"popNode {popNode}");
                isVisited[popNode] = true;
                if (popNode == end) {
                    path = BuildPath(previous, start, end);
                    return nodeCosts[end];
                }
                foreach (var edge in graph.GetAdjEdges(popNode)) {
                    if (isVisited[edge.to]) continue;

                    if (nodeCosts[popNode] + edge.weight < nodeCosts[edge.to]) {
                        nodeCosts[edge.to] = nodeCosts[popNode] + edge.weight;
                        Console.WriteLine($"Enqueue from [{popNode}] to [{edge.to}], current cost :{nodeCosts[edge.to]}");
                        queue.Enqueue(edge.to, nodeCosts[edge.to]);
                        previous[edge.to] = popNode;
                    }
                }
            }

            Console.WriteLine($"There is no path from [{start}] to [{end}].");
            return 0;
        }
        private static List<int> BuildPath(int[] previous, int start, int end) {
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
