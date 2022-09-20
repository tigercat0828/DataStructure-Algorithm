using DSALGO.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSALGO.Test {
    public class GrahamScanTest {
        [Fact]
        public void GetConvexHullTest() {
            List<Vector2> points = new();
            points.Add(new Vector2(2, 2));
            points.Add(new Vector2(3, 5));
            points.Add(new Vector2(4, 4));
            points.Add(new Vector2(1, 6));
            points.Add(new Vector2(-1, 5));
            points.Add(new Vector2(1, 4));
            points.Add(new Vector2(-2, 4));
            points.Add(new Vector2(-2, 3));
            points.Add(new Vector2(-2, 2));
            points.Add(new Vector2(-1, 3));
            points.Add(new Vector2(2, 3));
            points.Add(new Vector2(0, 1));

            GrahamScan solver = new();
            List<Vector2> vertexes = solver.GetConvexHull(points);
            vertexes.Print();
        }
    }
}
