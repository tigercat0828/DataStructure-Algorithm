using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.Algorithm.GraphTheory.CycleAndSCC {
    /*
    Find a cycle in undirected graphs
    An undirected graph has a cycle if and only if a depth-first search (DFS) 
    finds an edge that points to an already-visited vertex (a back edge).
    */
    public class CycleDetectOnUndirectedGraphDFS {
        
        enum Color {
            White, Grey, Black
        }
        Color[] color;
        bool[] isVisited;
        int[] parent;
        UndirectedGraph graph;
        bool isCyclic = false;

        public bool IsCyclic(UndirectedGraph graph) {
            this.graph = graph;
            isVisited = new bool[graph.Capacity];
            parent = Enumerable.Repeat(-1, graph.Capacity).ToArray();

            List<int> nodes = graph.GetAllNodes();

            foreach (var node in nodes) {
                if (!isVisited[node])
                    DFS(node);
            }
            return isCyclic;
        }

        void DFS(int node) {


            isVisited[node] = true;

            foreach (var adj in graph.GetAdjacentNodes(node)) {
                if (adj == parent[node]) {  // dont traverse my mom
                    continue;
                }
                else if (isVisited[adj]) {   // found my ancestor
                    Console.WriteLine($"[{node}, {adj}] Back Edge");
                    isCyclic = true;
                    continue;
                }
                parent[adj] = node;
                DFS(adj);

            }

        }
    }
}
