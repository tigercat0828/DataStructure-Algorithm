using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DSALGO.DataStructure.Graph.AdjacencyList;

namespace DSALGO.Algorithm.Graph.FindShortestPath {
    public static class SSSPonDAG {
        public static List<int> FindPath(AdjacencyList graph, int start, int end) {
            if (start == end) return new List<int> { start };
            if (!graph.Contains(start) || !graph.Contains(end)) {
                Console.WriteLine("Unvalid Input");
                return null;
            }
            
            int[] cost = new int[graph.nodeCount];
            int[] previous = new int[graph.nodeCount];
            Array.Fill(previous, -1);
            Array.Fill(cost, int.MaxValue);

            TopologicalSort sorter = new TopologicalSort(graph);
            List<int> sortingResult = sorter.Topsort().ToList();
            // sortingResult.Print();

            cost[start] = 0;

            
            foreach (var next in sortingResult) {
                List<Link> linkEdges = graph.GetLinkedEdges(next);
                if (linkEdges != null) {
                    foreach (var edge in linkEdges) {
                        int dest = edge.dest;
                        int cst = edge.weight;
                        if (cost[next] + cst < cost[dest]) {
                            cost[dest] = cost[next] + cst;
                            previous[dest] = next;
                        }
                    }
                }
            }
            
            cost.Print();
            // construct path
            List<int> path = new();
            path.Add(end);
            int current = end;
            while(current != start) {
                path.Add(previous[current]);
                current = previous[current];
            }
            path.Reverse();
            return path;
        }
    }
}
