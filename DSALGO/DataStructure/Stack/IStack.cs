namespace DSALGO.DataStructures {
    public interface IStack {
        int Count { get; }
        int Pop();
        void Push(int data);
        int Peek();
    }
}
