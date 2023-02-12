using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.Traversal {
    public class DepthFirstSearchIterative {

        enum Color {
            White,
            Grey,
            Black
        }
        private readonly DGraph graph;

        int[] parent;
        Color[] colors;
        List<int> Result;
        public DepthFirstSearchIterative(DGraph graph) {
            this.graph = graph;
            int nodeCount = graph.NodeCount;
            parent = new int[nodeCount];
            colors = new Color[nodeCount];
            Result = new List<int>();
        }
        private void Reset() {

            Array.Fill(parent, -1);
            Array.Fill(colors, Color.White);
            Result.Clear();
        }
        public void Traverse(int startNode) {
            if (!graph.ContainsNode(startNode)) {
                throw new ArgumentException("Invalid node ID");
            }
            Reset();
            Stack<int> stack = new();
            stack.Push(startNode);

            while (stack.Count > 0) {
                int pop = stack.Pop();
                colors[pop] = Color.Grey;

                Result.Add(pop);

                foreach (var adjNode in graph.GetAdjacentNodes(pop)) {
                    if (colors[adjNode] == Color.White) {
                        parent[adjNode] = pop;
                        stack.Push(adjNode);
                    }
                }
                colors[pop] = Color.Black;

            }
        }
        public void PrintMoreInfo() {
            Result.Print();

            Console.Write("Parent:");
            parent.Print();
        }
    }
}
