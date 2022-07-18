// See https://aka.ms/new-console-template for more information


using DSALGO;
using DSALGO.Algorithm;

using static DSALGO.Utility;


string person1 = "Alice";
string person2 = "Nick";

Console.WriteLine(0x7ffffff & person1.GetHashCode());
Console.WriteLine(0x7ffffff & person2.GetHashCode());
Dictionary<int, int> map = new();



