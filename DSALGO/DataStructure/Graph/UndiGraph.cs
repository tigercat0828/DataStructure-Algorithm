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
    public class UndiGraph {    

        List<List<int>> graph;
        List<bool> isAlive;
        public int Capacity { get; private set; }
        public int NodeCount { get; private set; }

        public UndiGraph(int nodeCount) {
            Capacity = nodeCount;
            NodeCount = nodeCount;
            isAlive = Enumerable.Repeat(false, nodeCount).ToList();
            graph = new List<List<int>>();
            for (int i = 0; i < Capacity; i++) {
                graph.Add(new List<int>());
            }
        }
        public void AddEdge(int from, int to, int weight = 0) {
            AddNode(from);
            AddNode(to);
            isAlive[from] = true;
            isAlive[to] = true;
            graph[from].Add(to);
            graph[to].Add(from);
        }
        public void AddNode(int node) {
            if (node >= Capacity) {
                int newNodes = node - Capacity + 1;
                Capacity = node + 1;
                for (int i = 0; i < newNodes; i++) {
                    graph.Add(new List<int>());
                    isAlive.Add(false);
                }
            }
            isAlive[node] = true;
        }
        public void DeleteNode(int node) {
            if (!ContainsNode(node)) return;
            isAlive[node] = false;
            graph[node].Clear();
            for (int i = 0; i < Capacity; i++) {
                graph[i].Remove(node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (ContainsEdge(from,to)) {
                graph[from].Remove(to);
                graph[to].Remove(from);
            }
        }
        public bool ContainsEdge(int from, int to) {
            return ContainsNode(from) && ContainsNode(to);
        }
        public bool ContainsNode(int node) {
            return !(node >= Capacity || !isAlive[node]);
        }
        public List<int> GetAllNodes() {
            List<int> nodes = new();
            for (int i = 0; i < Capacity; i++) {
                if (isAlive[i]) nodes.Add(i);
            }
            return nodes;
        }
        public List<int> GetAdjacentNodes(int node) {
            return graph[node];
        }
        public void Print() {
            for (int i = 0; i < Capacity; i++) {
                Console.Write($"[{i}]:");
                graph[i].Print();
            }
        }
    }
}
