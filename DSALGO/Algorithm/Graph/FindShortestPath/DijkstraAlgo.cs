using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.PriorityQueue;

namespace DSALGO.Algorithm.Graph.FindShortestPath
{
    public class DijkstraAlgo
    {
        readonly AdjacencyList graph;
        public DijkstraAlgo(AdjacencyList graph) {
            this.graph = graph;
        }
        public List<int> FindPath(int start, int end, out int cost) {

            if (!graph.Contains(start) || !graph.Contains(end)) {
                cost = -1;
                return null;
            }

            IndexedPriorityQueue<int, int> queue = new(); // nodeID, currentCost
            bool[] isVisited = new bool[graph.nodeCount];
            int[] nodeCosts = new int[graph.nodeCount]; Array.Fill(nodeCosts, int.MaxValue);
            int[] previous = new int[graph.nodeCount];  Array.Fill(previous, -1);
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
                foreach (var linked in graph.GetLinkedEdges(popNode)) {
                    if (isVisited[linked.dest]) continue;
    
                    if (nodeCosts[popNode] + linked.cost < nodeCosts[linked.dest]) {
                        nodeCosts[linked.dest] = nodeCosts[popNode] + linked.cost;
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

        private List<int> BuildPath(int[] previous, int start, int end) {
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
