using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath
{
    public static class DijkstraAlgo
    {
        public static List<int> FindPath(GraphList graph, int start, int end, out double cost) {
           
            if (!graph.ContainsNode(start) || !graph.ContainsNode(end)) {
                cost = -1;
                return null;
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
                    cost = nodeCosts[end];
                    return BuildPath(previous, start, end);
                }
                foreach (var linked in graph.GetAdjLinks(popNode)) {
                    if (isVisited[linked.dest]) continue;
    
                    if (nodeCosts[popNode] + linked.weight < nodeCosts[linked.dest]) {
                        nodeCosts[linked.dest] = nodeCosts[popNode] + linked.weight;
                       // Console.WriteLine($"Enqueue from [{popNode}] to [{linked.dest}], current cost :{nodeCosts[linked.dest]}");
                        queue.Enqueue(linked.dest, nodeCosts[linked.dest]);
                        previous[linked.dest] = popNode;
                    }
                }
            }
            cost = -1;

            Console.WriteLine($"There is no path from [{start}] to [{end}].");
            return new List<int>();
        }
        private static List<int> BuildPath(int[] previous, int start, int end) {
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
    }
}
