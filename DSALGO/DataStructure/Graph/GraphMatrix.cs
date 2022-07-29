using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    public class GraphMatrix : IGraph {
        const double X = 10000000;
        public bool isUndirected => throw new NotImplementedException();
        public int NodeCount => Graph[0].Count;
        public List<List<double>> Graph;
        public GraphMatrix(int nodeCount) {
            Graph = new();
            for (int i = 0; i < nodeCount; i++) {
                Graph[i] = new List<double> {};
            }
        }
        public GraphMatrix(int nodeCount, List<Edge> edges) : this(nodeCount){
            foreach (var edge in edges) {
                AddEdge(edge);
            }
        }

        public void AddEdge(Edge edge) {
            AddEdge(edge.from, edge.to, edge.weight);
        }

        public void AddEdge(int from, int to, double weight) {
            if (!ContainsNode(from)) throw new Exception($"Node {from} is not in the graph");
            if (!ContainsNode(to)) throw new Exception($"Node {to} is not in the graph");
            if (ContainsEdge(from, to)) {
                throw new Exception($"Edge ({from},{to},) already exist");
            }
            Graph[from][to] = weight;
        }

        public void AddNode(int node) {
            for (int i = 0; i < NodeCount; i++) {
                Graph[i].Add(X);
            }
            Graph.Add(new List<double>(node+1));
        }

        public void Clear() {
            for (int i = 0; i < NodeCount; i++) {
                Graph[i].Clear();
            }
            Graph.Clear();
        }

        public bool ContainsEdge(int from, int to) {
            return Graph[from][to] == X;
        }

        public bool ContainsNode(int node) => node >= NodeCount;

        public void DeleteEdge(int from, int to) {
            throw new NotImplementedException();
        }

        public void DeleteNode(int node) {
            throw new NotImplementedException();
        }

        public void EditEdge(int from, int to, double newWeight) {
            throw new NotImplementedException();
        }

        public List<Edge> GetAdjEdges(int node) {
            throw new NotImplementedException();
        }

        public List<int> GetAdjNodes(int node) {
            throw new NotImplementedException();
        }

        public List<int> GetAllNodes() {
            throw new NotImplementedException();
        }

        public void Print() {
            throw new NotImplementedException();
        }

        public List<Edge> ToEdgeList() {
            throw new NotImplementedException();
        }
    }
}
