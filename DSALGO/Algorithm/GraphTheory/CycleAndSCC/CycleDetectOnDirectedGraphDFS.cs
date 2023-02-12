using DSALGO.DataStructure.GraphStructure;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;

namespace DSALGO.Algorithm.GraphTheory.CycleAndSCC {

    public class CycleDetector {

        enum Color {
            White, Grey, Black
        }
        DGraph graph;
        Color[] colors;
        // On Directed Graph
        public bool IsCyclic(DGraph graph) {
            this.graph = graph;
            colors = new Color[graph.NodeCount];
            foreach (var u in graph.GetAllNodes()) {
                if (colors[u] == Color.White) {
                    if (DFS(u)) return true;
                }
            }
            return false;   
        }
        public bool DFS(int u) {
            Console.WriteLine(u);
            colors[u] = Color.Grey;
            foreach (var v in graph.GetAdjacentNodes(u) ){
                if (colors[v] == Color.Grey) {
                    return true;
                }
                else if (colors[v] == Color.White && DFS(v) == true) {
                    return true;
                }
            }
            colors[u] = Color.Black;
            return false;
        }
    }
}
