namespace DSALGO.Geometry {
    public class PointsRank2D {
        struct Node {
            public Vector2 pt;
            public int id;  // for recognize point
            public Node(int id, Vector2 pt) {
                this.id = id;
                this.pt = pt;
            }
        }
        public int[] BurteForce(List<Vector2> points) {
            size = points.Count;
            int[] ranks = new int[size];

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i == j) continue;
                    if (points[i].x > points[j].x && points[i].y > points[j].y) {
                        ranks[i]++;
                    };
                }
            }
            return ranks;
        }
        Node[] nodes;
        int[] ranks;
        int size;
        public int[] DivideConquer(List<Vector2> points) {
            // name this points
            size = points.Count;
            nodes = new Node[size];
            ranks = new int[size];
            for (int i = 0; i < size; i++) {
                nodes[i] = new Node(i, points[i]);
            }
            foreach (var node in nodes) {
                Console.WriteLine(node.id + " " + node.pt);
            }
            nodes = nodes.OrderBy(n => n.pt.x).ThenBy(n => n.pt.y).ToArray();
            solve(0, points.Count - 1);

            return ranks;
        }
        private void solve(int L, int R) {
            if (L >= R) return;
            int mid = (L + R) / 2;
            for (int i = mid + 1; i <= R; i++) {
                for (int j = L; j <= mid; j++) {
                    if (nodes[i].pt.y > nodes[j].pt.y) {
                        int id = nodes[i].id;
                        ranks[id]++;
                    }
                }
            }
            solve(L, mid);
            solve(mid + 1, R);
        }
    }
}
