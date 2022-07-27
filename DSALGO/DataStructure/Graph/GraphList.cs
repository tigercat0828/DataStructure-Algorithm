using System.Collections;
using System.Linq;
using System.Text;

namespace DSALGO.DataStructure.Graph {
    public class GraphList {
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
        private Dictionary<int, List<Link>> graph;  // adjacency list 
        public int nodeCount => graph.Count;
        public bool isUndirected { get; }
        public List<int> GetAllNodes() => graph.Keys.ToList();

        
        public List<int> GetAdjNodes(int node) => graph[node].Select(x => x.dest).ToList();
        public List<Link> GetAdjEdges(int node) => graph[node];
        public GraphList(List<int> vertexes, List<Edge> edgeList, bool isUndirected = false) {

            this.isUndirected = isUndirected;

            graph = new Dictionary<int, List<Link>>();
           
            foreach (var v in vertexes) graph.Add(v, new List<Link>());

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
        public GraphList(GraphList previous) {
            isUndirected = previous.isUndirected;
            graph = new Dictionary<int, List<Link>>();

            List<int> oldNodes = previous.GetAllNodes();
            foreach (var node in oldNodes) {
                List<Link> newLink = new();
                foreach (var link in previous.GetAdjEdges(node)) {
                    newLink.Add(new Link(link));
                }
                graph.Add(node, newLink);
            }
        }
        public bool ContainsNode(int node) => graph.ContainsKey(node);
        public bool ContainsEdge(int from, int to) { 
            if(!ContainsNode(from)) return false;
            List<int> nodes = GetAdjNodes(from);
            return nodes.Contains(to);
        }
        public void Print() {
            List<int> nodes = GetAllNodes();
            foreach (var node in nodes) {
                Console.Write(node + " : ");
                List<Link> links = GetAdjEdges(node);
                Console.WriteLine(String.Join(", ", links));
            }
        }
        public void EditEdge(int from, int to, int newWeight) {
            if (!ContainsEdge(from, to)) throw new Exception($"Edge ({from}, {to}) is not in graphs");
            Link link = graph[from].Find(x=>x.dest == to);
            link.weight = newWeight;
            if (isUndirected) {
                link = graph[to].Find(x => x.dest == from);
                link.weight = newWeight;
            }
        }
        public void AddEdge(Edge edge) {

            if(ContainsEdge(edge.from, edge.to)) 
                throw new Exception($"Edge ({edge.from},{edge.to},) already exist");

            if (!ContainsNode(edge.from)) AddNode(edge.from);
            if (!ContainsNode(edge.to)) AddNode(edge.to);
            graph[edge.from].Add(new Link(edge.to, edge.weight));
        }
        public void AddNode(int node) {
            
            if (graph.ContainsKey(node)) throw new Exception($"Node {node} already exist");
            graph.Add(node, new List<Link>());
        }
        public void DeleteNode(int node) {
            if (!graph.ContainsKey(node)) throw new Exception($"Node {node} is not in the graph");
        
            graph[node].Clear();
            graph.Remove(node);

            foreach (var n in GetAllNodes()) {
                List<int> adjNodes = GetAdjNodes(n);
                graph[n].RemoveAll(x => x.dest == node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (!ContainsNode(from)) throw new Exception($"Node {from} is not in the graph");
            if (!ContainsNode(to)) throw new Exception($"Node {to} is not in the graph");

            List<int> linkedNode = GetAdjNodes(from);
            
            if (!graph.ContainsKey(from) && !linkedNode.Contains(to)) {
                throw new Exception($"Edge ({from}, {to}) is not in graphs");
            }
            graph[from].RemoveAll(x=>x.dest == to);

            if (isUndirected) {
                graph[to].RemoveAll(x => x.dest == from);
            }
        }
        public void Clear() {
            foreach (var key in graph.Keys) graph[key].Clear();
            graph.Clear();
        }

    }
}