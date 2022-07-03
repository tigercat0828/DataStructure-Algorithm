using System.Text;

namespace DSALGO.DataStructures.Graph {
    public class AdjacencyList {

        private Dictionary<int, List<int>> graph;  // adjacency list 
        public int nodeCount => graph.Count;
        public bool isUndirected { get; }

        List<int> traversal = new List<int>();
        HashSet<int> visited;
        public List<int> this[int node] {
            get => graph[node];
        }

        public AdjacencyList(List<Edge> edgeList, bool isUndirected = false) {

            this.isUndirected = isUndirected;
            if (isUndirected) {
                int n = edgeList.Count;
                for (int i = 0; i < n; i++) {
                    Edge e = edgeList[i];
                    edgeList.Add(new Edge(e.to, e.from));
                }
            }

            graph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
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
                dfsHelper(n);
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
                    if (visited.Contains(n)) continue;

                    queue.Enqueue(n);
                    traversal.Add(n);
                    visited.Add(n);
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
            foreach (var nodeAdj in graph) {
                sb.Append(nodeAdj.Key + " : ");
                sb.Append(string.Join(',', nodeAdj.Value));
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public void AddEdge(Edge edge) {
            if (!graph.ContainsKey(edge.from)) AddNode(edge.from);
            if (!graph.ContainsKey(edge.to)) AddNode(edge.to);
            if (graph[edge.from].Contains(edge.to)) {
                Console.WriteLine($"Edge ({edge.from}, {edge.to}) already existing in graph");
                return;
            }
            graph[edge.from].Add(edge.to);
        }
        public void AddNode(int node) {
            if (graph.ContainsKey(node)) {
                Console.WriteLine($"node ({node}) already existing in graph");
                return;
            }
            graph.Add(node, new List<int>());
        }
        public void DeleteNode(int node) {
            if (!graph.ContainsKey(node)) {
                Console.WriteLine($"node ({node}) is not in graph");
                return;
            }
            graph[node].Clear();
            graph.Remove(node);
        }
        public void DeleteEdge(int from, int to) {
            if (!graph.ContainsKey(from) && !graph[from].Contains(to)) {
                Console.WriteLine($"No edge ({from}, {to}) is not in graphs");
            }
            graph[from].Remove(to);
            if (isUndirected) {
                graph[to].Remove(from);
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