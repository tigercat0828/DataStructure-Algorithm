// See https://aka.ms/new-console-template for more information


using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.GraphTheory;
using DSALGO.Algorithm.GraphTheory.MinimumSpanningTree;

var file = GetResourceFile("GraphInput.txt");

var graph = GraphList.Parse(file);
List<Edge> mst = new();
double cost = KruskalMst.Build(graph, 0, mst);
Console.WriteLine(cost);
mst.Print();

