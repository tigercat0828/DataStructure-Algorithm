![Annotation 2022-07-29 132235.png](https://github.com/tigercat0828/DSALGO/blob/main/TestData/Annotation%202022-07-29%20132235.png?raw=true)

``` cs
using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.GraphTheory.FindShortestPath;

List<int> vertices = new List<int> { 0,1,2,3,4,5,6,7,8,9 };
List<Edge> edges = new List<Edge>() {
    new Edge(0, 1, 5 ),
    new Edge(1, 6, 60  ),
    new Edge(1, 2, 20  ),
    new Edge(1, 5, 30  ),
    new Edge(2, 3, 10  ),
    new Edge(2, 4, 75  ),
    new Edge(3, 2, -15 ),
    new Edge(4, 9, 100 ),
    new Edge(5, 8, 50  ),
    new Edge(5, 6, 5   ),
    new Edge(5, 4, 25  ),
    new Edge(6, 7, -50 ),
    new Edge(7, 8, -10 ),
};
GraphList graph = new(vertices, edges, isUndirected: false);

List<int> path = new();
Console.WriteLine("cost = " + BellmanFordAlgo.FindPath(graph, 0, 8, ref path));
Console.Write("Path : ");
path.Print();
```
