namespace DSALGO.DataStructures.BinarySearchTree {
    public class TreeNode<T> {
        public T key;
        public TreeNode<T> left;
        public TreeNode<T> right;
        public TreeNode(T key, TreeNode<T> left = null, TreeNode<T> right = null) {
            this.key = key;
            this.left = left;
            this.right = right;
        }
    }
}
