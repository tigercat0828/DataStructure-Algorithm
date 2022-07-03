

using DSALGO.DataStructures.Tree;

namespace DSALGO.Algorithm.Tree {
    public static class TreeSum {
        public static int Calc(TreeNode root) {
            if (root == null) return 0;
            int sum = root.key;
            foreach (var node in root.children) {
                sum += Calc(node);
            }
            return sum;
        }

    }
}
