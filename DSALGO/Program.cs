using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;

DGraph graph = new(5);
graph.AddEdge(0, 3, -5);
graph.AddEdge(0, 4, 2);
graph.AddEdge(1, 0, 6);
graph.AddEdge(2, 0, 1);
graph.AddEdge(2, 1, 7);
graph.AddEdge(3, 2, 4);
graph.AddEdge(4, 1, -4);
graph.AddEdge(4, 2, 3);
graph.AddEdge(4, 3, 8);
FloydWarshall algo = new(graph);
