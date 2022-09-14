namespace DSALGO.DataStructure.DisjointSet {
    public class DisjointSet {
        int[] Parent;
        int[] Rank;
        public int NodeCount { get; private set; }
        public DisjointSet(int nodeCount) {
            Parent = Enumerable.Range(0, nodeCount).ToArray();
            Rank = Enumerable.Repeat(0, nodeCount).ToArray();
            NodeCount = nodeCount;
        }
        public bool IsSameSet(int A, int B) {
            if (A >= NodeCount || B >= NodeCount) throw new Exception($"node {A} or {B} not in the union set");
            return GetParent(A) == GetParent(B);

        }
        public int GetParent(int node) {
            if (node == Parent[node]) return node;
            return Parent[node] = GetParent(Parent[node]);
        }
        private void SetParent(int node, int parent) {
            Parent[node] = parent;
        }
        public void Union(int A, int B) {
            A = GetParent(A);
            B = GetParent(B);
            if (Rank[A] < Rank[B]) {
                Swap(ref A, ref B);
            }
            SetParent(B, A);
            if (Rank[A] == Rank[B]) {
                Rank[A]++;
            }
        }
        private void Swap(ref int A, ref int B) {
            (B, A) = (A, B);
        }

    }
}
