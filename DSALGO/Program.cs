// See https://aka.ms/new-console-template for more information


using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.GraphTheory;
using DSALGO.Algorithm.GraphTheory.MinimumSpanningTree;

var file = GetResourceFile("NetworkInput.txt");

// var graph = GraphList.Parse(file);
NetworkList network = NetworkList.Parse(file);
network.EditPipeCapacity(1, 3, 30);
network.EditPipeFlow(1, 3, 14);
network.Print();