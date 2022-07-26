// See https://aka.ms/new-console-template for more information


using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.GraphTheory;
using DSALGO.Algorithm.GraphTheory.FindShortestPath;

var file = GetResourceFile("GraphInput.txt");

Graphz graph = Graphz.Parse(file);

graph.Print();
DijkstraAlgo.FindPath(graph, 0, 7,out double cost);



// D:\Users\u443933\Desktop\jianyi\DSALGO\DSALGO\Resource
// D:\Users\u443933\Desktop\jianyi\DSALGO\DSALGO\bin\Debug\net6.0\