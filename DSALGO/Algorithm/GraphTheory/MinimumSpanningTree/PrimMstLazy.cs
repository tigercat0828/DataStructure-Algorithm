using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.MinimumSpanningTree {
    public class PrimMstLazy {
        readonly Graphz graph;
        PriorityQueue<Edge, double> PQ;
        bool[] isVisited;

        public PrimMstLazy(Graphz graph) {
            this.graph = graph;
            PQ = new();
            isVisited = new bool[graph.nodeCount];
        }
        public List<Edge> BuildMST(int root, out double mstCost) {
            mstCost = 0;
            if (!graph.Contains(root)) {
                return null;
            }

            List<Edge> mstEdges = new List<Edge>();

            int expectedCount = graph.nodeCount - 1;

            EnqueueEdges(root);

            while (PQ.Count > 0) {
                Edge edge = PQ.Dequeue();

                if (isVisited[edge.to]) continue;
                Console.WriteLine($"  build {edge} V");
                EnqueueEdges(edge.to);
                mstEdges.Add(edge);
                mstCost += edge.weight;
            }

            if (mstEdges.Count != expectedCount) return null;

            return mstEdges;
        }
        private void EnqueueEdges(int nodeID) {

            isVisited[nodeID] = true;
            foreach (var link in graph.GetAdjacentEdges(nodeID)) {
                if (isVisited[link.dest]) continue;
                Edge edge = new Edge(nodeID, link.dest, link.cost);
                PQ.Enqueue(edge, link.cost);
                Console.WriteLine($"Enqueue {edge}");
            }
        }

    }
}
