namespace DSALGO.Geometry {
    public class GrahamScan {
        /*
         * Step 1 : select point with lowest y (v)
         * Step 2 : sort points according the angle between horizontal and <i,v>
         * Step 3 : iterate the points, if ccw push into result
         * 1. O(n)
         * 2. O(nlgn)
         * 3. O(n)
         * Total O(nlgn)
         */
        public List<Vector2> GetConvexHull(List<Vector2> points) {
            double minY = points[0].y;
            int minYindex = 0;
            for (int i = 1; i < points.Count; i++) {
                if (points[i].y < minY) {
                    minYindex = i;
                    minY = points[i].y;
                }
            }
            Vector2 anchor = points[minYindex];
            Console.WriteLine("anchor = "+ anchor);

            points.RemoveAt(minYindex);
            // ange => dot operation with <x,y>.<1,0> = <x,0>

            Vector2 horizontal = new Vector2(1, 0);
            points = points.OrderByDescending(p => p.x / p.length).ToList();

            foreach (var p in points) {
                Console.WriteLine(p);
            }
            
            Stack<Vector2> stack = new();
            stack.Push(anchor);
            stack.Push(points[0]);
            for (int i = 1; i < points.Count; i++) {
                Vector2 C = points[i];
                Vector2 B = stack.Peek();
                Vector2 A = stack.Skip(1).First();

                if (IsCounterClockWise(B - A, C - B)) {     //  ABxBC
                    stack.Push(C);
                }
                else {
                    Vector2 pop = stack.Pop();
                    Console.WriteLine("delete " + pop);
                    i--;
                }
            }
            return stack.ToList();
        }
        private bool IsCounterClockWise(Vector2 A, Vector2 B) {
            return (A^B) >= 0;   // we only care signed area
        }
    }
}
