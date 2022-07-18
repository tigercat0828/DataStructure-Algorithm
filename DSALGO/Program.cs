// See https://aka.ms/new-console-template for more information


using DSALGO;
using DSALGO.Algorithm;

using static DSALGO.Utility;
using DSALGO.DataStructure.HashTable;

HashTableSeperateChaining<string, int> table = new();
table.Add("Alice", 1);
table.Add("NIck", 2);


table.Print();

table["Alice"] = 3;

Utility.DrawBoldLine();

table.Print();

