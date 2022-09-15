using DSALGO.Algorithm.GraphTheory.CycleAndSCC;
using DSALGO.DataStructure.GraphStructure;
using System.Reflection.Metadata.Ecma335;
using static DSALGO.Utility;

Graph graph = new Graph(8);

graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 0);
graph.AddEdge(1, 3);
graph.AddEdge(2, 3);
graph.AddEdge(3, 4);
graph.AddEdge(3, 5);
graph.AddEdge(4, 2);
graph.AddEdge(4, 5);
graph.AddEdge(4, 6);
graph.AddEdge(5, 7);
graph.AddEdge(6, 5);
graph.AddEdge(7, 6);


graph.Print();
DrawBoldLine();
KosarajuSCC kosa = new();
TarjanSCC tar = new();

kosa.FindSCCs(graph).Print();
DrawBoldLine();
tar.FindSCCs(graph).Print();


