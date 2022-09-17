using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.CycleAndSCC {
    // Kosaraju' algorithm : find strong connected component 
    public class KosarajuSCC {
        /*
        1. Perform Postorder DFS, push the element into the stack
        2. reverse the graph
        3. DFS the vertex on stack
         */
        int[] SCCs;
        int SCCid;
        Graph originGraph;
        Graph reverseGraph;
        bool[] visited;
        Stack<int> orderStack;
        public int[] FindSCCs(Graph graph) {
            SCCid = 0;
            originGraph = graph;
            GetReverseGraph();
            // reverseGraph.Print();
            orderStack = new();
            visited = new bool[graph.NodeCount];
            SCCs = new int[graph.NodeCount];
            // 1st order : define second DFS visit order
            foreach (var node in originGraph.GetAllNodes()) {
                if (!visited[node]) {
                    DFS1st(node);
                }
            }
            // 2nd order : recognize SCC
            visited = new bool[graph.NodeCount];
            while (orderStack.Count > 0) {
                int pop = orderStack.Pop();
                if (!visited[pop]) {
                    DFS2nd(pop);
                    Console.WriteLine();
                    SCCid++;
                }
            }
            return SCCs;
        }
        void DFS1st(int node) {
            visited[node] = true;

            foreach (var adj in originGraph.GetAdjacentNodes(node)) {
                if (!visited[adj]) {
                    DFS1st(adj);
                }
            }
            orderStack.Push(node);
        }
        void DFS2nd(int node) {

            Console.Write(node + " ");
            SCCs[node] = SCCid;

            visited[node] = true;
            foreach (var adj in reverseGraph.GetAdjacentNodes(node)) {
                if (!visited[adj]) {
                    DFS2nd(adj);
                }
            }
        }
        private void GetReverseGraph() {
            List<Edge> edges = originGraph.GetEdgeList();
            reverseGraph = new Graph(originGraph.Capacity);
            foreach (var e in edges) {
                reverseGraph.AddEdge(e.to, e.from, e.weight);
            }
        }

    }
}
