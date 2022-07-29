using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.MinimumSpanningTree {
    public static class PrimMst {
        static GraphList Graph;
        static PriorityQueue<Edge, double> PQ;
        static bool[] Visited;

        public static double Build(GraphList graph, int root, List<Edge> treeEdges) {
            double mstCost = 0;
            if (!graph.ContainsNode(root)) {
                throw new Exception($"Node {root} node in the graph");
            }
            Graph = graph;
            PQ = new();
            Visited = new bool[graph.NodeCount];

            EnqueueEdges(root);

            while (PQ.Count > 0) {
                Edge edge = PQ.Dequeue();
                if (Visited[edge.to]) continue;

                EnqueueEdges(edge.to);
                treeEdges.Add(edge);
                mstCost += edge.weight;
            }

            int expectedEdgeCount = graph.NodeCount - 1;
            if (treeEdges.Count != expectedEdgeCount) {
                Console.WriteLine("Can't Build MST. Not all node are connected");
            }
            return mstCost;
        }
        private static void EnqueueEdges(int node) {

            Visited[node] = true;
            
            foreach (var link in Graph.GetAdjEdges(node)) {
                if (Visited[link.to]) continue;

                Edge edge = new Edge(node, link.to, link.weight);
                PQ.Enqueue(edge, link.weight);
            }
        }

    }
}
