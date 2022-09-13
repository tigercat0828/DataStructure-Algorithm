using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.Sorting;
using DSALGO.Algorithm.GraphTheory;

UndiGraph graph = new UndiGraph(9);
//graph.AddEdge(0, 1);
//graph.AddEdge(0, 2);
//graph.AddEdge(1, 3);
//graph.AddEdge(2, 4);
//graph.AddEdge(3, 5);
//graph.AddEdge(3, 6);
//graph.AddEdge(4, 7);
//graph.AddEdge(4, 8);
//graph.AddEdge(4, 3);
graph.Print();
CycleDetectDFS algo = new();
Console.WriteLine(algo.IsCyclic(graph));
