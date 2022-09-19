using DSALGO;
using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
using DSALGO.Geometry;

List<Vector2> points = new List<Vector2>();
points.Add(new Vector2(1, 1));
points.Add(new Vector2(2, 4));
points.Add(new Vector2(3, 2));
points.Add(new Vector2(4, 6));
points.Add(new Vector2(5, 3));
points.Add(new Vector2(6, 7));
points.Add(new Vector2(7, 5));
points.Add(new Vector2(8, 2));

FindPointsRank solver = new();
int[] ranks = solver.DivideConquer(points);
for (int i = 0; i < points.Count; i++) {
    Console.WriteLine($"{points[i]} : {ranks[i]}");
}
Console.WriteLine(solver.times);