using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath
{
    public static class DijkstraAlgo
    {
        public static double FindPath(GraphList graph, int start, int end, ref List<int> path) {
           
            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                return 0;
            }
            IndexedPriorityQueue<int, double> queue = new(); // nodeID, currentCost
            bool[] isVisited = new bool[graph.NodeCount];
            double[] nodeCosts = new double[graph.NodeCount]; Array.Fill(nodeCosts, int.MaxValue);
            int[] previous = new int[graph.NodeCount];  Array.Fill(previous, -1);
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
                foreach (var linked in graph.GetAdjEdges(popNode)) {
                    if (isVisited[linked.to]) continue;
    
                    if (nodeCosts[popNode] + linked.weight < nodeCosts[linked.to]) {
                        nodeCosts[linked.to] = nodeCosts[popNode] + linked.weight;
                        Console.WriteLine($"Enqueue from [{popNode}] to [{linked.to}], current cost :{nodeCosts[linked.to]}");
                        queue.Enqueue(linked.to, nodeCosts[linked.to]);
                        previous[linked.to] = popNode;
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
