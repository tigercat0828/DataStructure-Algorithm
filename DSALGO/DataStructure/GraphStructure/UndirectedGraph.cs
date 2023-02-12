namespace DSALGO.DataStructure.GraphStructure {
    public class UndirectedGraph {
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
        public UndirectedGraph(int nodeCount) {
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
            graph[to].Add(new Node(from, weight));
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
                graph[to].RemoveAll(x => x.dest == from);
            }
        }
        public void EditEdge(int from, int to, int weight) {
            if (ContainsEdge(from, to)) {
                Node node1 = new Node(to, weight);
                int index1 = graph[from].FindIndex(x => x.dest == to);
                graph[from][index1] = node1;

                Node node2 = new Node(from, weight);
                int index2 = graph[to].FindIndex(x => x.dest == from);
                graph[to][index2] = node2;
            }
        }
        public bool ContainsEdge(int from, int to) {
            if (ContainsNode(from) && ContainsNode(to)) {
                bool go = graph[from].Exists(x => x.dest == to);
                bool back = graph[to].Exists(x => x.dest == from);
                return go && back;
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
        public DGraph ToDiGraph() {
            DGraph diGraph = new(Capacity);
            for (int i = 0; i < Capacity; i++) {
                if (isAlive[i]) {
                    foreach (var node in graph[i]) {
                        diGraph.AddEdge(i, node.dest, node.weight);
                    }
                }
            }
            return diGraph;
        }
    }
}
