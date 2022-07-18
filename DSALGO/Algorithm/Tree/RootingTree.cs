using DSALGO.DataStructure.Graph;
using DSALGO.DataStructure.Tree;

namespace DSALGO.Algorithm.Tree {
    public static class RootingTree {
        public static TreeNode Build(AdjacencyList graph, int node) {

            if (!graph.Contains(node)) return null;

            TreeNode root = new TreeNode(node);
            build(graph, root);
            return root;
        }
        private static TreeNode build(AdjacencyList graph, TreeNode node) {
            foreach (var vertex in graph.GetLinkedNodes(node.key)) {
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
