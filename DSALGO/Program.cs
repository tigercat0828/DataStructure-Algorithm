// See https://aka.ms/new-console-template for more information


using DSALGO;
using DSALGO.Algorithm;
using DSALGO.Algorithm.Graph;
using DSALGO.Algorithm.Graph.FindShortestPath;
using DSALGO.DataStructure.BinarySearchTree;
using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.PriorityQueue;

List<Edge> edges = new List<Edge>();

edges.Add(new Edge(0,1, 1));
edges.Add(new Edge(0,2, 4));
edges.Add(new Edge(1,2, 2));
edges.Add(new Edge(1,3, 10));
edges.Add(new Edge(2,4, 2));
edges.Add(new Edge(3,5, 1));
edges.Add(new Edge(4,3, 2));
edges.Add(new Edge(4,5, 4));

List<int> vertexs = new List<int>() {
    0,1,2,3,4,5
};
AdjacencyList graph = new AdjacencyList(vertexs, edges);
Console.WriteLine(graph);
SSSPonDAG.FindPath(graph, 0, 5).Print();


