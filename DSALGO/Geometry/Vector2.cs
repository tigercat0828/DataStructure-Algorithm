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
        public static Vector2 operator +(Vector2 A, Vector2 B) {
            return new Vector2(A.x + B.x, A.y + B.y);
        }
        public static Vector2 operator -(Vector2 A, Vector2 B) {
            return new Vector2(A.x - B.x, A.y - B.y);
        }
        public Vector2 normalized => new Vector2(x / length, y / length);
        public double length => Math.Sqrt(x * x + y * y);






        public override string ToString() {
            return $"({x}, {y})";
        }
    }
}
