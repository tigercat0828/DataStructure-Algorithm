namespace DSALGO.DataStructure.BinarySearchTree {
    public interface IBinaryTree<T> {
        public int Count { get; }
        bool Insert(T value);
        bool Remove(T value);
        T Peek();
        bool Contains(T value);
        List<T> PreOrder();
        List<T> PostOrder();
        List<T> InOrder();
        List<T> LevelOrder();
    }
}
