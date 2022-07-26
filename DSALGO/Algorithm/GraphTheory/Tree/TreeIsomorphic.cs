using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.Tree;
using System.Text;

namespace DSALGO.Algorithm.GraphTheory.Tree {
    public static class TreeIsomorphic {
        public static bool AreIsomorphic(Graphz treeGraph1, Graphz treeGraph2) {
            List<int> center1 = TreeCenter.Get(treeGraph1);
            List<int> center2 = TreeCenter.Get(treeGraph2);

            TreeNode tree1 = RootingTree.Build(treeGraph1, center1[0]);
            string treeCode1 = encode(tree1);


            for (int i = 0; i < center2.Count; i++) {
                TreeNode tree2 = RootingTree.Build(treeGraph2, center2[i]);

                string treeCode2 = encode(tree2);

                if (treeCode1 == treeCode2) return true;
            }
            return false;
        }
        // encoding code with DPS
        private static string encode(TreeNode tree) {
            if (tree == null) return "";
            List<string> codeStrs = new();
            foreach (var node in tree.children) {
                codeStrs.Add(encode(node));
            }
            // for uniqueness 
            codeStrs.Sort();

            // list to strings
            StringBuilder sb = new();
            foreach (var str in codeStrs) {
                sb.Append(str);
            }
            return "(" + sb.ToString() + ")";
        }
    }
}
