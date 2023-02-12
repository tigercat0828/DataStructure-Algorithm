namespace DSALGO.Geometry {

    // Time Complexity : O(n^2)
    public class JarvisMarch {
        public List<Vector2> GetConvexHull(List<Vector2> points) {

            GetFirstVector(points);

            bool[] inPolygon = new bool[points.Count];
            List<Vector2> result = new();
            result.Add(points[0]);
            result.Add(points[1]);
            inPolygon[0] = true;
            inPolygon[1] = true;

            for (int i = 2; i < points.Count; i++) {
                Vector2 A = points[i - 2];
                Vector2 B = points[i - 1];
                double maxCos = -1;
                int index = i;
                for (int j = 2; j < points.Count; j++) {
                    if (inPolygon[index]) continue;
                    Vector2 C = points[j];
                    double cos = CosTheta(B - A, C - B); // AB * BC
                    if (cos > maxCos) {
                        index = j;
                        maxCos = cos;
                    }
                }
                inPolygon[index] = true;
                result.Add(points[index]);
            }
            return result;
        }
        public void GetFirstVector(List<Vector2> points) {
            // select point with lowest Y position and move to first index 
            int minYindex = 0;
            double minY = points[0].y;
            for (int i = 0; i < points.Count; i++) {
                if (points[i].y < minY) {
                    minYindex = i;
                    minY = points[i].y;
                }
            }
            SwapByIndex(points, 0, minYindex);

            // build first vector V(p1-p0)
            Vector2 horizontal = new Vector2(1, 0);
            double maxCos = -1;
            Vector2 first;
            int index = 1;
            for (int i = 1; i < points.Count; i++) {
                first = points[i] - points[0];
                double cos = CosTheta(first, horizontal);
                if (cos > maxCos) {
                    index = i;
                    maxCos = cos;
                }
            }
            SwapByIndex(points, 1, index);
        }
        private double CosTheta(Vector2 A, Vector2 B) {
            return (A * B) / (A.length * B.length);
        }
        private void SwapByIndex(List<Vector2> points, int i, int j) {
            (points[i], points[j]) = (points[j], points[i]);
        }
    }
}
