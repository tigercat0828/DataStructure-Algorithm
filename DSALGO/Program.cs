// See https://aka.ms/new-console-template for more information


using DSALGO;
using DSALGO.Algorithm;

using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.Graph.FindShortestPath;
using DSALGO.DataStructure.HashTable;
using DSALGO.Algorithm.Sorting;


int[] nums = Utility.RandomIntArray(100, 1,1000);

CountingSort.Run(nums);

var file = GetResourceFile("GraphInput.txt");

Graphz graph = Graphz.Parse(file);
graph.Print();


// D:\Users\u443933\Desktop\jianyi\DSALGO\DSALGO\Resource
// D:\Users\u443933\Desktop\jianyi\DSALGO\DSALGO\bin\Debug\net6.0\