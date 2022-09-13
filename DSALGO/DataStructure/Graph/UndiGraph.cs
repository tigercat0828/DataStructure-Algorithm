using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    public class UndiEdge {
        int from, to;
        int weight;
        public UndiEdge(int from, int to, int weight = 0) {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }
    }
    public class UndiGraph {    // Undirected Graph read-only (temporarily)
        
        List<List<int>> graph;
        public int NodeCount { get; }
        public UndiGraph(int nodeCount) {
            NodeCount = nodeCount;
            // wtf
            // graph = Enumerable.Repeat(new List<int>(), nodeCount).ToList();
            graph = new List<List<int>>();
            for (int i = 0; i < NodeCount; i++) {
                graph.Add(new List<int>());
            }
        }
        public void AddEdge(int from, int to, int weight=0) {
            graph[from].Add(to);
            graph[to].Add(from);
        }
        public List<int> GetAllNodes() {
            return Enumerable.Range(0, NodeCount).ToList();
        }
        public List<int> GetAdjacentNodes(int node) {
            return graph[node];
        }
        public void Print() {
            for (int i = 0; i < NodeCount; i++) {
                Console.Write($"[{i}]:");
                graph[i].Print();
            }
        }
        
    }

}
