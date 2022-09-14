using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.GraphStructure {
    public class Graph {    // Directed Weighted Graph
        public struct Node {
            public int dest;
            public int weight;
            public Node(int dest, int weight = 1) {
                this.dest = dest;
                this.weight = weight;
            }
            public override string ToString() {
                return $"[{dest}, {weight}]";
            }
        }
        List<List<Node>> graph;
        List<bool> isAlive;
        public int Capacity { get; private set; }
        public int NodeCount {
            get {
                int sum = 0;
                for (int i = 0; i < Capacity; i++) 
                    if (isAlive[i]) sum++;
                return sum;
            }
        }
        public Graph(int nodeCount) {
            Capacity = nodeCount;
            isAlive = Enumerable.Repeat(false, nodeCount).ToList();
            graph = new List<List<Node>>();
            for (int i = 0; i < Capacity; i++) {
                graph.Add(new List<Node>());
            }
        }
        public void AddEdge(int from, int to, int weight = 1) {
            AddNode(from);
            AddNode(to);
            isAlive[from] = true;
            isAlive[to] = true;
            graph[from].Add(new Node(to, weight));
        }
        public void AddNode(int node) {
            if (node >= Capacity) {
                int newSlotCount = node - Capacity + 1;
                Capacity = node + 1;
                for (int i = 0; i < newSlotCount; i++) {
                    graph.Add(new List<Node>());
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
                graph[i].RemoveAll(x => x.dest == node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (ContainsEdge(from, to)) {
                graph[from].RemoveAll(x => x.dest == to);
            }
        }
        public void EditEdge(int from, int to, int weight) {
            if (ContainsEdge(from, to)) {
                Node node = new Node(to, weight);
                int index = graph[from].FindIndex(x => x.dest == to);
                graph[from][index] = node;
            }
        }
        public bool ContainsEdge(int from, int to) {
            if (ContainsNode(from) && ContainsNode(to)) {
                return graph[from].Exists(x => x.dest == to);
            }
            return false;
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
            return graph[node].Select(x => x.dest).ToList();
        }
        public void Print() {
            for (int i = 0; i < Capacity; i++) {
                Console.Write($"[{i}]:");
                graph[i].Print();
            }
        }
    }
}
