namespace DSALGO.DataStructures {
    public abstract class QueueBase {
        public abstract int Count { get; }
        public abstract void Enqueue(int data);
        public abstract int Dequeue();
    }
}
