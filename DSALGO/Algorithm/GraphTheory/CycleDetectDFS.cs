using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory {
    public  class CycleDetectDFS {
        /*
        # Find a cycle in undirected graphs
        An undirected graph has a cycle if and only if a depth-first search (DFS) 
        finds an edge that points to an already-visited vertex (a back edge).
        
        # Find a cycle in directed graphs
        In addition to visited vertices we need to keep track of vertices currently 
        in recursion stack of function for DFS traversal. If we reach a vertex that 
        is already in the recursion stack, then there is a cycle in the tree.
         
         */
        enum Color {
            White, Grey, Black
        }
        Color[] color;
        bool[] isVisited;
        int[] parent;  
        UndiGraph graph;
        bool isCyclic = false;
        public bool IsCyclic(UndiGraph graph) {
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
        int indent = -1;
        void DFS(int node) {
            indent++;
            for (int i = 0; i < indent*4; i++) {
                Console.Write(" ");
            }
            Console.WriteLine($"DFS({node})");
            isVisited[node] = true;

            List<int> adjNodes = graph.GetAdjacentNodes(node);
            
            foreach (var adj in adjNodes) {
                if (adj == parent[node]) {  // dont traverse my mom
                    continue;
                }
                if (isVisited[adj]) {   // found my ancestor
                    Console.WriteLine($"Back Edge[{adj}{node}]");
                    isCyclic = true;
                    indent--;
                    return;
                }
                parent[adj] = node;
                DFS(adj);
       
            }
            indent--;
        }
    }
}
