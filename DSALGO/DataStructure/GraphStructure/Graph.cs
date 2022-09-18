namespace DSALGO.DataStructure.GraphStructure {
    public class Graph {    // Directed Weighted Graph
        private struct Link {
            public int dest;
            public int weight;
            public Link(int dest, int weight = 1) {
                this.dest = dest;
                this.weight = weight;
            }
            public override string ToString() {
                return $"[{dest}, {weight}]";
            }
        }
        public const int CANT_REACH = 1000000000;
        List<List<Link>> graph;
        List<bool> isAlive;
        public int MaxID { get; private set; }
        public int NodeCount {
            get {
                int sum = 0;
                for (int i = 0; i < MaxID; i++)
                    if (isAlive[i]) sum++;
                return sum;
            }
        }
        public Graph(int nodeCount) {
            MaxID = nodeCount;
            isAlive = Enumerable.Repeat(false, nodeCount).ToList();
            graph = new List<List<Link>>();
            for (int i = 0; i < MaxID; i++) {
                graph.Add(new List<Link>());
            }
        }
        public void AddEdge(int from, int to, int weight = 1) {
            AddNode(from);
            AddNode(to);
            isAlive[from] = true;
            isAlive[to] = true;
            graph[from].Add(new Link(to, weight));
        }
        public void AddNode(int node) {
            if (node >= MaxID) {
                int newSlotCount = node - MaxID + 1;
                MaxID = node + 1;
                for (int i = 0; i < newSlotCount; i++) {
                    graph.Add(new List<Link>());
                    isAlive.Add(false);
                }
            }
            isAlive[node] = true;
        }
        public void DeleteNode(int node) {
            if (!ContainsNode(node)) return;
            isAlive[node] = false;
            graph[node].Clear();
            for (int i = 0; i < MaxID; i++) {
                graph[i].RemoveAll(x => x.dest == node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (ContainsEdge(from, to)) {
                graph[from].RemoveAll(x => x.dest == to);
            }
        }
        public void DeleteEdge(int from, int to, int weight) {
            if (ContainsEdge(from, to)) {
                graph[from].RemoveAll(x => x.dest == to && x.weight == weight);
            }
        }
        public void EditEdge(int from, int to, int weight) {
            if (ContainsEdge(from, to)) {
                Link node = new Link(to, weight);
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
            return !(node >= MaxID || !isAlive[node]);
        }
        public List<int> GetAllNodes() {
            List<int> nodes = new();
            for (int i = 0; i < MaxID; i++) {
                if (isAlive[i]) nodes.Add(i);
            }
            return nodes;
        }
        public List<int> GetAdjacentNodes(int node) {
            return graph[node].Select(x => x.dest).ToList();

        }
        public List<Edge> GetAdjacentEdges(int node) {
            List<Edge> result = new();

            foreach (var n in graph[node]) {
                result.Add(new Edge(node, n.dest, n.weight));
            }
            return result;
        }
        public void Print() {
            for (int i = 0; i < MaxID; i++) {
                Console.Write($"[{i}]:");
                graph[i].Print();
            }
        }
        public List<Edge> ToEdgeList() {
            List<Edge> result = new();
            for (int i = 0; i < MaxID; i++) {
                if (isAlive[i]) {
                    foreach (var edge in GetAdjacentEdges(i)) {
                        result.Add(edge);
                    }
                }
            }
            return result;
        }
        public int[][] ToMatrix() {
            int n = MaxID;
            int[][] mat = new int[n][];
            for (int i = 0; i < n; i++) {
                mat[i] = new int[n];
                Array.Fill(mat[i], CANT_REACH);
                mat[i][i] = 0;
            }
            
            for (int i = 0; i < MaxID; i++) {
                if (isAlive[i]) {
                    foreach (var edge in GetAdjacentEdges(i)) {
                        mat[edge.from][ edge.to] = edge.weight;
                    }
                }
            }
            return mat;
        }
    }
}
