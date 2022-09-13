using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory {
    public class DepthFirstSearch {
        enum Color {
            White,  // start visit
            Grey,   // visiting
            Black,  // finish
        };
        GraphList graph;
        int[] previous;
        int[] finishTime;
        int[] discoverTime;
        Color[] color;
        int nodeCount;
        int time;
        DepthFirstSearch(GraphList graph) {
            this.graph = graph;
            nodeCount = graph.NodeCount;
            time = 0;
            discoverTime = new int[nodeCount];
            finishTime = new int[nodeCount];
            previous = new int[nodeCount];
            color = new Color[nodeCount];

            Array.Fill(previous, -1);
            Array.Fill(color, Color.White);

        }
        void DFS(int startNode) {
            if (startNode >= nodeCount) {
                throw new ArgumentException("Invalid node ID");
            }
            List<int> nodes = graph.GetAllNodes();
            foreach (var node in nodes) {
                if (color[node] == Color.White) {
                    dfs(node);
                }
            }
        }
        void dfs(int node) {
            color[node] = Color.Grey;
            time++;
            List<int> adjNodes = graph.GetAdjNodes(node);
            foreach (var adj in adjNodes) {
                if (color[adj] == Color.White) {
                    previous[adj] = node;   
                    dfs(adj);
                }
            }
            color[node] = Color.Black;
            time++;
            finishTime[node] = time;
        }
    }
}
