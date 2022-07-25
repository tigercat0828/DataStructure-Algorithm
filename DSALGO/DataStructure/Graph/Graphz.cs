using System.Collections;
using System.Linq;
using System.Text;

namespace DSALGO.DataStructure.Graph {
    public class Graphz {

        public static Graphz Parse(string filePath) {

            List<Edge> edges = new List<Edge>();
            List<int> vertexs = new List<int>();
            string[] lines = File.ReadAllLines(filePath);
            bool isUndireted = bool.Parse(lines[0]);
            string[] vStr = lines[1].Split(" ");
            foreach (var v in vStr) {
                vertexs.Add(int.Parse(v));
            }
            for (int i = 2; i < lines.Length; i++) {
                string[] eStr = lines[i].Split(" ");
                int from = int.Parse(eStr[0]);
                int to = int.Parse(eStr[1]);
                double wei = double.Parse(eStr[2]);
                Edge e = new Edge(from, to, wei);
                edges.Add(e);
            }

            return new Graphz(vertexs, edges, isUndireted);
        }
        private Dictionary<int, List<Link>> graph;  // adjacency list 
        public int nodeCount => graph.Count;
        public bool isUndirected { get; }

        List<int> traversal = new List<int>();
        HashSet<int> visited;

        public List<int> GetLinkedNodes(int node) {
            List<Link> links = graph[node];
            List<int> linkedNodes = new();
            foreach (var link in links) {
                linkedNodes.Add(link.dest);
            }
            return linkedNodes;
        }
        public List<Link> GetLinkedEdges(int node) => graph[node];
        public Graphz(List<int> vertexes, List<Edge> edgeList, bool isUndirected = false) {

            this.isUndirected = isUndirected;

            graph = new Dictionary<int, List<Link>>();
            visited = new HashSet<int>();

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
        public bool Contains(int node) => graph.ContainsKey(node);
        public List<int> DFtraversal(int Node) {
            Reset();
            dfsHelper(Node);
            return traversal;
        }
        private void dfsHelper(int node) {
            if (visited.Contains(node)) return;
            traversal.Add(node);
            visited.Add(node);
            foreach (var n in graph[node]) {
                dfsHelper(n.dest);
            }
        }
        public List<int> BFtraversal(int node) {
            Reset();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            traversal.Add(node);
            visited.Add(node);

            while (queue.Count > 0) {
                int pop = queue.Dequeue();

                foreach (var n in graph[pop]) {
                    if (visited.Contains(n.dest)) continue;

                    queue.Enqueue(n.dest);
                    traversal.Add(n.dest);
                    visited.Add(n.dest);
                }
            }
            return traversal;
        }

        // reset isVisited & traversal
        private void Reset() {
            visited.Clear();
            traversal.Clear();
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            List<int> nodes = GetAllNodes();
            foreach (var node in nodes) {
                sb.Append(node + " : ");
                List<int> linkedNode = GetLinkedNodes(node);
                sb.Append(String.Join(',', linkedNode));
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public void Print() {

            List<int> nodes = GetAllNodes();
            foreach (var node in nodes) {
                Console.Write(node + " : ");
                List<Link> links = GetLinkedEdges(node);
                Console.WriteLine(String.Join(", ", links));
            }
        }
        public void AddEdge(Edge edge) {

            if (!graph.ContainsKey(edge.from)) AddNode(edge.from);
            if (!graph.ContainsKey(edge.to)) AddNode(edge.to);
            graph[edge.from].Add(new Link(edge.to, edge.weight));
        }
        public void AddNode(int node) {
            if (graph.ContainsKey(node)) {
                Console.WriteLine($"node ({node}) already existing in graph");
                return;
            }
            graph.Add(node, new List<Link>());
        }
        public void DeleteNode(int target) {
            if (!graph.ContainsKey(target)) {
                Console.WriteLine($"node ({target}) is not in graph");
                return;
            }
            graph[target].Clear();
            graph.Remove(target);

            foreach (var n in GetAllNodes()) {
                List<int> linkedNode = GetLinkedNodes(n);
                int targetIdx = linkedNode.IndexOf(target);
                if (targetIdx != -1) {
                    graph[n].RemoveAt(targetIdx);
                }
            }
        }
        public void DeleteEdge(int from, int to) {
            if (!graph.ContainsKey(from)) return;
            List<int> linkedNode = GetLinkedNodes(from);

            if (!graph.ContainsKey(from) && !linkedNode.Contains(to)) {
                Console.WriteLine($"No edge ({from}, {to}) is not in graphs");
            }

            int toIdx = linkedNode.IndexOf(to);
            graph[from].RemoveAt(toIdx);

            if (isUndirected) {
                DeleteEdge(to, from);
            }
        }
        public void Clear() {
            foreach (var key in graph.Keys) {
                graph[key].Clear();
            }
            graph.Clear();
        }
        public List<int> GetAllNodes() => graph.Keys.ToList();


    }
}