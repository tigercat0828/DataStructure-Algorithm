using System.Text;

namespace DSALGO.DataStructure.DisjointSet {
    public class DisjointSet {
        int[] parent;
        int[] rank;
        int nodeCount;
        public DisjointSet(int nodeCount) {
            parent = new int[nodeCount];
            rank = new int[nodeCount];
            this.nodeCount = nodeCount;
        }
        public bool IsSameSet(int A, int B) {
            if (A >= nodeCount || B >= nodeCount) throw new Exception($"node {A} or {B} not in the union set");
            return GetParent(A) == GetParent(B);
            
        }
        public int GetParent(int node) {
            throw new NotImplementedException();
        }
        public int Unify(int A, int B) {
            throw new NotImplementedException();
        }
      
    }
}
