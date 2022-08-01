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
        public int NodeCount => Mat.Count;
        public List<List<double>> Mat;
        public GraphMatrix(int nodeCount, bool isUndirected) {
            this.isUndirected = isUndirected;
            Mat = new List<List<double>> ();
            for (int i = 0; i < nodeCount; i++) {
                Mat.Add(new List<double>(Enumerable.Repeat(X,nodeCount))) ;
            }
            for (int i = 0; i < Mat.Count; i++) {
                for (int j = 0; j < Mat[0].Count; j++) {
                    if (i == j) Mat[i][j] = 0;
                    else Mat[i][j] = X;
                }
            }
        }
        public GraphMatrix(int nodeCount, bool isUndirected, List<Edge> edges) : this(nodeCount, isUndirected) {
            foreach (var edge in edges) {
                AddEdge(edge);
            }
        }
        public void AddEdge(Edge edge) {
            AddEdge(edge.from, edge.to, edge.weight);
        }
        public void AddEdge(int from, int to, double weight) {
            if (!ContainsNode(from)) throw new Exception($"Node {from} doesn't exist");
            if (!ContainsNode(to)) throw new Exception($"Node {to} doesn't exist");
            if (ContainsEdge(from, to)) {
                throw new Exception($"Edge ({from},{to},) already exist");
            }
            Mat[from][to] = weight;

            if (isUndirected) {
                Mat[to][from] = weight;
            }
        }
        public void AddNode(int node) {

            if (ContainsNode(node)) throw new Exception($"Node {node} already exist");
            if (node < NodeCount) {
                Mat[node][node] = 0;
            }
            else {
                Console.WriteLine("Nodecount = " + NodeCount);
                for (int i = 0; i < NodeCount; i++) {
                    Mat[i].Add(X);
                }
                int newSize = NodeCount + 1;
                Mat.Add(new List<double>(Enumerable.Repeat(X, newSize)));
                Mat[NodeCount - 1][NodeCount - 1] = 0;
            }
        }
        public void Clear() {
            for (int i = 0; i < NodeCount; i++) {
                Mat[i].Clear();
            }
            Mat.Clear();
        }
        public bool ContainsEdge(int from, int to) {
            return Mat[from][to] != X;
        }
        public bool ContainsNode(int node) { 
            if(node>=NodeCount) return false;
            return Mat[node][node] == 0; 
        }
        public void DeleteEdge(int from, int to) {
            if (!ContainsEdge(from, to))
                throw new Exception($"Edge ({from}, {to}) doesn't exist");
            Mat[from][to] = X;
            if (isUndirected) {
                Mat[to][from] = X;
            }
        }
        public void DeleteNode(int node) {
            if (!ContainsNode(node)) 
                throw new Exception($"Node {node} doesn't exist");
            
            for (int i = 0; i < NodeCount; i++) {
                Mat[node][i] = X;
                Mat[i][node] = X;
            }
        }
        public void EditEdge(int from, int to, double newWeight) {
            if (!ContainsEdge(from, to)) {
                throw new Exception($"Edge ({from}, {to}) doesn't exist");
            }
            Mat[from][to] = newWeight;
        }
        public List<Edge> GetAdjEdges(int node) {
            List<Edge> edges = new();
            for (int i = 0; i < NodeCount; i++) {
                double wei = Mat[node][i];
                if (wei != X) {
                    edges.Add(new Edge(node, i, wei));
                }
            }
            return edges;
        }
        public List<int> GetAdjNodes(int node) {
            List<int> nodes = new();
            for (int i = 0; i < NodeCount; i++) {
                double wei = Mat[node][i];
                if (wei != X) {
                    nodes.Add(i);
                }
            }
            return nodes;
        }
        public List<int> GetAllNodes() {
            List<int> nodes = new();
            for (int i = 0; i < NodeCount; i++) {
                if (Mat[i][i] != X) {
                    nodes.Add(i);
                }
            }
            return nodes;
        }
        public void Print() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"- [");
            for (int i = 0; i < NodeCount; i++) {
                sb.Append(String.Format("{0, 6}", $"{i}"));
            }
            sb.AppendLine($"  ]\n");
            for (int i = 0; i < NodeCount; i++) {
                sb.Append($"{i} [");
                for (int j = 0; j <NodeCount; j++) {
                    if (Mat[i][j] == X) sb.Append(String.Format("{0, 6}","X"));
                    else sb.Append(String.Format("{0, 6}",Mat[i][j]));
                }
                sb.AppendLine("  ]");
            }
            Console.WriteLine(sb.ToString());
        }
        public List<Edge> ToEdgeList() {
            if (isUndirected) return GetUndirectedEdges();
            return GetDirectedEdges();
        }
        private List<Edge> GetDirectedEdges() {
            List<Edge> edges = new();
            for (int i = 0; i < NodeCount; i++) {
                for (int j = 0; j < NodeCount; j++) {
                    double wei = Mat[i][j];
                    if (wei != X) {
                        edges.Add(new Edge(i, j, wei));
                    }
                }
            }
            return edges;
        }
        private List<Edge> GetUndirectedEdges() {
            List<Edge> edges = new();
            for (int i = 0; i < Mat.Count; i++) {
                for (int j = 0; j < Mat[i].Count; j++) {
                    if (j > i) {
                        double wei = Mat[i][j];
                        if (wei != X) {
                            edges.Add(new Edge(i, j, wei));
                        }
                    }
                }
            }
            return edges;
        }
        public double[][] GetMatrix() {
            
            double[][] result = new double[NodeCount][];
            for (int i = 0; i < NodeCount; i++) result[i] = new double[NodeCount];

            for (int i = 0; i < NodeCount; i++) {
                for (int j = 0; j < NodeCount; j++) {
                    result[i][j] = Mat[i][j];
                }
            }
            return result;
        }
    }
}
