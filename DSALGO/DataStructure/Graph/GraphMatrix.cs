using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    public class GraphMatrix : IGraph {
        const double X = 10000000;
        public bool isUndirected { get; }
        public int NodeCount => Graph[0].Count;
        public List<List<double>> Graph;
        public GraphMatrix(int nodeCount, bool isUndirected) {
            this.isUndirected = isUndirected;
            Graph = new();
            for (int i = 0; i < nodeCount; i++) {
                Graph[i] = new List<double> {};
            }
        }
        public GraphMatrix(int nodeCount, bool isUndirected ,List<Edge> edges) : this(nodeCount, isUndirected) {
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

        public bool ContainsNode(int node) => node < NodeCount;

        public void DeleteEdge(int from, int to) {
            if (!ContainsEdge(from, to))
                throw new Exception($"Edge ({from}, {to}) is not in the graph");
            Graph[from][to] = X;
        }

        public void DeleteNode(int node) {
            for (int i = 0; i < NodeCount; i++) {
                Graph[node][i] = X;
                Graph[i][node] = X;
            }
        }

        public void EditEdge(int from, int to, double newWeight) {
            if (!ContainsEdge(from, to)) {
                throw new NotImplementedException();
            }
            Graph[from][to] = newWeight;
        }

        public List<Edge> GetAdjEdges(int node) {
            List<Edge> edges = new();
            for (int i = 0; i < NodeCount; i++) {
                double wei = Graph[node][i];
                if (wei!= X) {
                    edges.Add(new Edge(node, i, wei));
                }
            }
            return edges;
        }

        public List<int> GetAdjNodes(int node) {
            List<int> nodes= new();
            for (int i = 0; i < NodeCount; i++) {
                double wei = Graph[node][i];
                if (wei != X) {
                    nodes.Add(i);
                }
            }
            return nodes;
        }

        public List<int> GetAllNodes() {
            List<int> nodes = new();
            for (int i = 0; i < NodeCount; i++) {
                if (Graph[i][i] != X) {
                    nodes.Add(i);
                }
            }
            return nodes;
        }

        public void Print() {
            foreach (var row in Graph) {
                row.Print();
            }
        }

        public List<Edge> ToEdgeList() {
            if (isUndirected) return GetUndirectedEdges();
            return GetDirectedEdges();
        }

        private List<Edge> GetDirectedEdges() {
            List<Edge> edges = new();
            for (int i = 0; i < Graph.Count; i++) {
                for (int j = 0; j < Graph[i].Count; j++) {
                    double wei = Graph[i][j];
                    if(wei != X) {
                        edges.Add(new Edge(i, j, wei));
                    }
                }
            }
            return edges;
        }

        private List<Edge> GetUndirectedEdges() {
            List<Edge> edges = new();
            for (int i = 0; i < Graph.Count; i++) {
                for (int j = 0; j < Graph[i].Count; j++) {
                    if (j > i) {
                        double wei = Graph[i][j];
                        if (wei != X) {
                            edges.Add(new Edge(i, j, wei));
                        }
                    }
                }
            }
            return edges;
        }
    }
}
