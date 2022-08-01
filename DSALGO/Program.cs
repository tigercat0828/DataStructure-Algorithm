using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.GraphTheory.FindShortestPath;
List<Edge> edges = new List<Edge>() {
new Edge(0, 2, 6),
new Edge(0, 1, 2),
new Edge(0, 3, 4),
new Edge(1, 2, 3),
new Edge(2, 3, 1),
new Edge(2, 0, 7),
new Edge(3, 0, 5),
new Edge(3, 2, 12),
};
GraphMatrix graph = new(4, isUndirected: false, edges);
graph.Print();
double[][] matrix =  graph.GetMatrix();


List<int> vs = new List<int>();
FloydWarshall.FindPath(graph, 1, 3, ref vs);