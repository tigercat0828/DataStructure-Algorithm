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
            
            List<Edge> sortedEdges = graph.ToEdgeList().OrderBy(x=>x.weight).ToList();
            foreach (var e in sortedEdges) {
                Console.WriteLine(e);
            }

            return cost;
        }
    }
}
