using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Geometry {
    public struct Vector2 {
        public double x;
        public double y;
        public Vector2(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public static double operator *(Vector2 A, Vector2 B) {
            return A.x * B.x + A.y * B.y;
        }
        public static double operator ^(Vector2 A, Vector2 B) { 
            return A.x * B.y - A.y * B.x;
        }
        public override string ToString() {
            return $"({x}, {y})";
        }
    }
}
