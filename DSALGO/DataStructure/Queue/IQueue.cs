namespace DSALGO.DataStructure {
    public interface IQueue<T> {
        int Count { get; }
        T Dequeue();
        void Enqueue(T item);
        T Peek();
        bool Contains(T item);
    }
}
