using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.Traversal {
    public class DepthFirstSearchRecursive {
        // this is preorder DFS
        enum Color {
            White,  // start
            Grey,   // exist in callstack
            Black,  // finish
        };
        private readonly Graph graph;
        int[] parent;
        int[] finishTime;
        int[] discoverTime;
        Color[] color;
        int time;

        List<int> Result;
        public DepthFirstSearchRecursive(Graph graph) {
            this.graph = graph;
            int nodeCount = graph.NodeCount;
            discoverTime = new int[nodeCount];
            finishTime = new int[nodeCount];
            parent = new int[nodeCount];
            color = new Color[nodeCount];
            Result = new List<int>();
        }

        private void Reset() {
            time = 0;
            Result.Clear();
            Array.Fill(parent, -1);
            Array.Fill(color, Color.White);
            Array.Fill(discoverTime, 0);
            Array.Fill(finishTime, 0);
        }
        public void Traverse(int startNode) {
            if (!graph.ContainsNode(startNode)) {
                throw new ArgumentException("Invalid node ID");
            }
            Reset();
            List<int> nodes = graph.GetAllNodes();
            foreach (var node in nodes) {
                if (color[node] == Color.White) {
                    DFS(node);
                }
            }
            Result.Print();
        }

        int indent = -1;
        void DFS(int node) {
            indent++;
            for (int i = 0; i < indent * 4; i++) Console.Write(" ");
            Console.WriteLine($"DFS({node})");

            Result.Add(node);
            color[node] = Color.Grey;
            time++;
            discoverTime[node] = time;

            foreach (var adj in graph.GetAdjacentNodes(node)) {
                if (color[adj] == Color.White) {
                    parent[adj] = node;
                    DFS(adj);
                }
            }

            color[node] = Color.Black;
            time++;
            finishTime[node] = time;
            indent--;
        }
        public void PrintMoreInfo() {
            Result.Print();
            Console.Write("Discover: ");
            discoverTime.Print();
            Console.Write("Finish: ");
            finishTime.Print();
            Console.Write("Parent:");
            parent.Print();
        }
        public List<int> GetResult() => Result;
    }
}
