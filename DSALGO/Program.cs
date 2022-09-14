using static DSALGO.Utility;
using DSALGO.Algorithm.Sorting;
using DSALGO.DataStructure.GraphStructure;
using DSALGO.Algorithm.GraphTheory.Traversal;

UndirectedGraph graph = new UndirectedGraph(7);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 3);
graph.AddEdge(1, 4);
graph.AddEdge(2, 5);
graph.AddEdge(2, 6);
graph.Print();
DrawBoldLine();

BreadthFirstSearch algo = new(graph.ToDiGraph());
algo.Traverse(0);

