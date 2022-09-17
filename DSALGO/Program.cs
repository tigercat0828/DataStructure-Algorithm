using DSALGO;
using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
////int[] P = new int[] { 4, 10, 3, 12, 20, 7 };
//int[] P = new int[] { 30,35,15,5,10,20,25 };
//MatrixChain chain = new();
//Console.WriteLine(chain.MinOperateCount(P));
//chain.PrintTable();


Graph graph = new(7);
graph.AddEdge(0, 1, 2);
graph.AddEdge(0, 3, 3);
graph.AddEdge(1, 2, 1);
graph.AddEdge(1, 4, 4);
graph.AddEdge(3, 4, 2);
graph.AddEdge(2, 5, 5);
graph.AddEdge(4, 5, 1);

Dijkstra pathFinder = new(graph);
(List<int> path, int cost) = pathFinder.FindPath(0, 5);
path.Print();
Console.WriteLine(cost);




