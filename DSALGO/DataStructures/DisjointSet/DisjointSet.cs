using System.Text;

namespace DSALGO.DataStructures.DisjointSet {
    public class DisjointSet {
        int[] parent;
        int[] rank;
        List<(int, int)> edges;
        public bool ExistCircle { get; private set; }
        public int x;
        public DisjointSet(int nodeCount, List<(int, int)> edges) {

            parent = new int[nodeCount];
            rank = new int[nodeCount];

            for (int i = 0; i < parent.Length; i++) {
                parent[i] = i;     // point to itself
                rank[i] = 1;
            }
            this.edges = edges.ToList();

            // union & find opeartions
            foreach (var edge in edges) {
                int x = edge.Item1;
                int y = edge.Item2;
                UnionTest(x, y);
            }
            /// /compression all path to rank 1
            //for (int i = 0; i < parent.Length; i++) {
            //    parent[i] = GetRoot(parent[i]);
            //}
        }
        public int GetRoot(int node) {
            /* recursive ver
            if (node == parent[node]) return node;
            return parent[node] = GetRoot(parent[node]);
             */
            int root = node;
            while (parent[root] != root) {
                root = parent[root];
            }
            // compression path
            while (node != root) {
                int next = parent[node];
                parent[node] = root;
                node = next;
            }
            return root;
        }
        public void UnionTest(int node1, int node2) {
            int root1 = GetRoot(node1);
            int root2 = GetRoot(node2);
            if (root1 == root2) {
                ExistCircle = true;
            }
            // unify
            if (rank[node1] < rank[node2]) {
                parent[root1] = root2;
                rank[node2] += rank[node1];
                rank[node1] = 0;
            }
            else {
                parent[root2] = root1;
                rank[node1] += rank[node2];
                rank[node2] = 0;
            }
            // parent[root1] = root2;
        }

        public void PrintRootTable() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parent.Length; i++) {
                sb.Append(i.ToString("D2") + " ");
            }
            sb.Append('\n');
            for (int i = 0; i < parent.Length; i++) {
                sb.Append(parent[i].ToString("D2") + " ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
