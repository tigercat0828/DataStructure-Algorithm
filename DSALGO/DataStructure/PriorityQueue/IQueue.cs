namespace DSALGO.DataStructures.PriorityQueue {
    public interface IQueue<T> where T : IComparable {
        int Size { get; }
        T Dequeue();
        T Peek();
        void Enqueue(T item);
        bool Contains(T item);
    }
}