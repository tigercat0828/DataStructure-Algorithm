using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.Traversal {
    public class BreadthFirstSearch {
        enum Color {
            White, Grey, Black
        }

        private readonly DGraph graph;
        List<int> Result;
        Color[] colors;
        int[] parent;
        public BreadthFirstSearch(DGraph graph) {
            this.graph = graph;
            Result = new();
            colors = new Color[graph.NodeCount];
            parent = new int[graph.NodeCount];
        }
        private void Reset() {
            Result.Clear();
            Array.Fill(colors, Color.White);
            Array.Fill(parent, -1);
        }
        public void Traverse(int startNode) {
            Reset();
            if (!graph.ContainsNode(startNode)) {
                throw new Exception("Invalid node ID");
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            while (queue.Count > 0) {
                int pop = queue.Dequeue();
                Result.Add(pop);
                colors[pop] = Color.Grey;
                foreach (var adj in graph.GetAdjacentNodes(pop)) {
                    if (colors[adj] == Color.White) {
                        parent[adj] = pop;
                        queue.Enqueue(adj);
                    }
                }
                colors[pop] = Color.Black;
            }
            Result.Print();
        }
        public List<int> GetResult() => Result;
    }
}
