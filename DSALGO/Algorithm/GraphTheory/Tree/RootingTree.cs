using DSALGO.DataStructure.GraphStructure;
using DSALGO.DataStructure.Tree;

namespace DSALGO.Algorithm.GraphTheory.Tree {
    public static class RootingTree {
        public static TreeNode Build(GraphList graph, int node) {

            if (!graph.ContainsNode(node)) return null;

            TreeNode root = new TreeNode(node);
            build(graph, root);
            return root;
        }
        private static TreeNode build(GraphList graph, TreeNode node) {
            foreach (var vertex in graph.GetAdjNodes(node.key)) {
                // avoid adding parent as its child
                if (node.parent != null && node.parent.key == vertex) continue;
                TreeNode newNode = new TreeNode(vertex);
                node.AddChild(newNode);
                build(graph, newNode);
            }
            return node;
        }
    }
}
