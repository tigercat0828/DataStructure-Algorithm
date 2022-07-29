using System.Collections;
using System.Linq;
using System.Text;

namespace DSALGO.DataStructure.Graph {
    public class GraphList  {
        // store vertice & edges with adjacency list
        #region member property
        private Dictionary<int, List<Link>> Graph;  // adjacency list 
        public int NodeCount => Graph.Count;
        public bool isUndirected { get; }
        #endregion 

        public GraphList(List<int> vertexes, List<Edge> edgeList, bool isUndirected = false) {

            this.isUndirected = isUndirected;

            Graph = new Dictionary<int, List<Link>>();

            foreach (var v in vertexes) Graph.Add(v, new List<Link>());

            if (isUndirected) {
                int n = edgeList.Count;
                for (int i = 0; i < n; i++) {
                    Edge e = edgeList[i];
                    edgeList.Add(new Edge(e.to, e.from, e.weight));
                }
            }
            for (int i = 0; i < edgeList.Count; i++) {
                AddEdge(edgeList[i]);
            }
        }
        public GraphList(bool isUndirected) {
            Graph = new Dictionary<int, List<Link>>();
            this.isUndirected = isUndirected;
        }
        public GraphList(GraphList previous) {
            isUndirected = previous.isUndirected;
            Graph = new Dictionary<int, List<Link>>();

            List<int> oldNodes = previous.GetAllNodes();
            foreach (var node in oldNodes) {
                List<Link> newLink = new();
                foreach (var link in previous.GetAdjLinks(node)) {
                    newLink.Add(new Link(link));
                }
                Graph.Add(node, newLink);
            }
        }
        public bool ContainsNode(int node) => Graph.ContainsKey(node);
        public bool ContainsEdge(int from, int to) {
            if (!ContainsNode(from)) return false;
            List<int> nodes = GetAdjNodes(from);
            return nodes.Contains(to);
        }
        public void Print() {
            List<int> nodes = GetAllNodes();
            foreach (var node in nodes) {
                Console.Write(node + " : ");
                List<Link> links = GetAdjLinks(node);
                Console.WriteLine(String.Join(", ", links));
            }
        }
        public List<int> GetAllNodes() => Graph.Keys.ToList();
        public List<int> GetAdjNodes(int node) => Graph[node].Select(x => x.to).ToList();
        public List<Link> GetAdjLinks(int node) => Graph[node];
        public void EditEdge(int from, int to, double newWeight) {
            if (!ContainsEdge(from, to)) throw new Exception($"Edge ({from}, {to}) is not in graphs");
            Link link = Graph[from].Find(x => x.to == to);
            link.weight = newWeight;
            if (isUndirected) {
                link = Graph[to].Find(x => x.to == from);
                link.weight = newWeight;
            }
        }
        public void AddEdge(Edge edge) {
            AddEdge(edge.from, edge.to, edge.weight);
        }
        public void AddEdge(int from, int to, double weight) {
            if (ContainsEdge(from, to))
                throw new Exception($"Edge ({from},{to},) already exist");

            if (!ContainsNode(from)) AddNode(from);
            if (!ContainsNode(to)) AddNode(to);
            Graph[from].Add(new Link(to, weight));
        }
        public void AddNode(int node) {

            if (Graph.ContainsKey(node)) throw new Exception($"Node {node} already exist");
            Graph.Add(node, new List<Link>());
        }
        public void DeleteNode(int node) {
            if (!Graph.ContainsKey(node)) throw new Exception($"Node {node} is not in the graph");

            Graph[node].Clear();
            Graph.Remove(node);

            foreach (var n in GetAllNodes()) {
                List<int> adjNodes = GetAdjNodes(n);
                Graph[n].RemoveAll(x => x.to == node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (!ContainsNode(from)) throw new Exception($"Node {from} is not in the graph");
            if (!ContainsNode(to)) throw new Exception($"Node {to} is not in the graph");

            List<int> linkedNode = GetAdjNodes(from);

            if (!Graph.ContainsKey(from) && !linkedNode.Contains(to)) {
                throw new Exception($"Edge ({from}, {to}) is not in graphs");
            }
            Graph[from].RemoveAll(x => x.to == to);

            if (isUndirected) {
                Graph[to].RemoveAll(x => x.to == from);
            }
        }
        public void Clear() {
            foreach (var key in Graph.Keys) Graph[key].Clear();
            Graph.Clear();
        }
        public List<Edge> ToEdgeList() {
            if (isUndirected) return GetUndirectedEdges();
            return GetDirectedEdges();
        }
        private List<Edge> GetUndirectedEdges() {
            List<Edge> edges = new();
            bool[] visited = new bool[NodeCount];
            foreach (var node in GetAllNodes()) {
                foreach (var link in GetAdjLinks(node)) {
                    if (node < link.to) {
                        edges.Add(new Edge(node, link.to, link.weight));
                        visited[node] = true;
                        visited[link.to] = true;
                    }
                }
            }
            return edges;
        }
        private List<Edge> GetDirectedEdges() {
            List<Edge> edges = new();
            foreach (var node in GetAllNodes()) {
                foreach (var link in GetAdjLinks(node)) {
                    edges.Add(new Edge(node, link.to, link.weight));
                }
            }
            return edges;
        }
        public static GraphList Parse(string filePath) {

            List<Edge> edges = new List<Edge>();
            List<int> vertices = new List<int>();

            string[] lines = File.ReadAllLines(filePath);

            bool isDirected = bool.Parse(lines[0]);
            // vertices
            string[] vStr = lines[1].Split(" ");
            foreach (var v in vStr) {
                vertices.Add(int.Parse(v));
            }
            // edges
            for (int i = 2; i < lines.Length; i++) {
                string[] eStr = lines[i].Split(" ");
                int from = int.Parse(eStr[0]);
                int to = int.Parse(eStr[1]);
                double wei = double.Parse(eStr[2]);
                Edge e = new Edge(from, to, wei);
                edges.Add(e);
            }

            return new GraphList(vertices, edges, isDirected);
        }
    }
}