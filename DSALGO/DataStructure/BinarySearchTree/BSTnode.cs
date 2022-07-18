namespace DSALGO.DataStructure.BinarySearchTree {
    public class BSTnode<T> {
        public T key;
        public BSTnode<T> left;
        public BSTnode<T> right;
        public BSTnode(T key, BSTnode<T> left = null, BSTnode<T> right = null) {
            this.key = key;
            this.left = left;
            this.right = right;
        }
    }
}
