using DSALGO.DataStructure.DisjointSet;
using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.MinimumSpanningTree {
    public static class KruskalMst {
        public static double Build(GraphList graph, int root, List<Edge> treeEdges) {
            if (!graph.ContainsNode(root)) throw new Exception($"Node {root} is not in the graph");
            
            double cost = 0;
            
            DisjointSet set = new DisjointSet(graph.NodeCount);

            // Or use a priorty queue, both them are O(nlong)
            List<Edge> sortedEdges = graph.ToEdgeList().OrderBy(x=>x.weight).ToList();
            
            foreach (var edge in sortedEdges) {
                int v1 = edge.from;
                int v2 = edge.to;
                double wei = edge.weight;
                if (set.IsSameSet(v1, v2)) continue;

                set.Union(v1, v2);
                treeEdges.Add(new Edge(v1, v2, wei));
                cost += wei;
            }
            // retrun MST forest;
            return cost;
        }
        public static double Build(List<Edge> edgeList, int root, List<Edge> treeEdges) {
            int nodeCount = Math.Max(
                edgeList.Select(x => x.from).Max(),
                edgeList.Select(x => x.to).Max()
            ) + 1;
            
            DisjointSet set = new DisjointSet(nodeCount);
            double cost = 0;
            // Or use a priorty queue, both them are O(nlong)
            edgeList = edgeList.OrderBy(x => x.weight).ToList();

            foreach (var edge in edgeList) {
                int v1 = edge.from;
                int v2 = edge.to;
                double wei = edge.weight;
                if (set.IsSameSet(v1, v2)) continue;

                set.Union(v1, v2);
                treeEdges.Add(new Edge(v1, v2, wei));
                cost += wei;
            }
            // retrun MST forest;
            return cost;
        }

    }
}
