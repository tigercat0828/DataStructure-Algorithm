using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.CycleAndSCC {

    /*
    Find a cycle in directed graphs
    In addition to visited vertices we need to keep track of vertices currently 
    in recursion stack of function for DFS traversal. If we reach a vertex that 
    is already in the recursion stack, then there is a cycle in the tree.
     */
    public class CycleDetectOnDirectedGraphDFS {

        enum Color {
            White, Grey, Black
        }
        Graph graph;
        Color[] colors;
        int[] parents;
        bool isCyclic;

        public bool IsCyclic(Graph graph) {
            this.graph = graph;
            int nodeCount = graph.NodeCount;
            colors = new Color[nodeCount];
            parents = new int[nodeCount];

            List<int> nodes = graph.GetAllNodes();
            foreach (var node in nodes) {
                if (colors[node] == Color.White) {
                    DFS(node);
                }
            }
            return isCyclic;
        }
        void DFS(int node) {
            colors[node] = Color.Grey;
            foreach (var adj in graph.GetAdjacentNodes(node)) {
                if (colors[adj] == Color.White) {
                    parents[adj] = node;
                    DFS(adj);
                }
                else if (colors[adj] == Color.Grey) {
                    Console.WriteLine($"[{node}, {adj}] Back Edge");
                    isCyclic = true;
                }
            }
            colors[node] = Color.Black;
        }
    }
}
