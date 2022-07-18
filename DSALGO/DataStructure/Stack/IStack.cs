namespace DSALGO.DataStructure {
    public interface IStack {
        int Count { get; }
        int Pop();
        void Push(int data);
        int Peek();
    }
}
