using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.CycleAndSCC {
    public class TarjanSCC {
        const int UNVISITED = -1;
        int[] lows;     // imply SCC group
        int[] IDs;
        bool[] onStack;
        Graph graph;
        Stack<int> stack;
        int id;
        public int[] FindSCCs(Graph graph) {

            this.graph = graph;
            stack = new Stack<int>();
            int nodeCount = graph.NodeCount;
            lows = new int[nodeCount];
            IDs = new int[nodeCount];
            onStack = new bool[nodeCount];
            id = UNVISITED;
            Array.Fill(IDs, UNVISITED);

            foreach (var node in graph.GetAllNodes()) {
                if (IDs[node] == UNVISITED) {
                    DFS(node);
                }
            }
            return lows;
        }
        void DFS(int node) {
            id++;
            lows[node] = id;
            IDs[node] = id;
            onStack[node] = true;
            stack.Push(node);
            foreach (var to in graph.GetAdjacentNodes(node)) {
                if (IDs[to] == UNVISITED) DFS(to);
                if (onStack[to]) lows[node] = Math.Min(lows[to], lows[node]);
            }
            if (IDs[node] == lows[node]) {
                for (int pop = stack.Pop(); ; pop = stack.Pop()) {
                    onStack[pop] = false;
                    //lows[n] = IDs[node];
                    Console.Write(pop + " ");
                    if (pop == node) break;
                }
                Console.WriteLine();
            }
        }
    }
}
