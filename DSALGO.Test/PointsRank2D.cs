using DSALGO.Geometry;
using System;
using System.Collections.Generic;
using Xunit;

namespace DSALGO.Test {
    public class PointsRank2DTest {
        [Fact]
        public void Test() {
            List<Vector2> points = new List<Vector2>();
            points.Add(new Vector2(1, 1));
            points.Add(new Vector2(2, 4));
            points.Add(new Vector2(3, 2));
            points.Add(new Vector2(4, 6));
            points.Add(new Vector2(5, 3));
            points.Add(new Vector2(6, 7));
            points.Add(new Vector2(7, 5));
            points.Add(new Vector2(8, 2));

            PointsRank2D solver = new();
            int[] ranks = solver.DivideConquer(points);
            for (int i = 0; i < points.Count; i++) {
                Console.WriteLine($"{points[i]} : {ranks[i]}");
            }

        }
    }
}
