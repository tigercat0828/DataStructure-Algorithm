namespace DSALGO.DataStructures {
    public interface IBinarySearchTree<T> where T : IComparable {
        public int Count { get; }
        bool Insert(T value);
        void Remove(T value);
        T Peek();
        bool Contains(T value);
        List<T> PreOrder();
        List<T> PostOrder();
        List<T> InOrder();
        List<T> LevelOrder();
    }
}
