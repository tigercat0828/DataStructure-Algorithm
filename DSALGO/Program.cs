using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.Sorting;

GraphList graph = new GraphList(false);
graph.AddEdge(0, 2);
graph.AddEdge(0, 1);
graph.AddEdge(2, 1);
graph.AddEdge(1, 3);
graph.AddEdge(3, 2);
graph.AddEdge(4, 3);
graph.AddEdge(4, 5);
graph.AddEdge(5, 5);

graph.Print();
