// See https://aka.ms/new-console-template for more information


using DSALGO;
using DSALGO.Algorithm;

using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.Graph.FindShortestPath;
using DSALGO.DataStructure.HashTable;

HashTableSeperateChaining<string, int> map = new();

map.Add("Alice", 1);
map.Add("Nick", 3);
map.Add("Alices", 1);
map.Add("Nick", 5);

foreach (var item in map) {
    Console.WriteLine(item);
}
