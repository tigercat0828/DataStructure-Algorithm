namespace DSALGO.Interfaces {
    public interface ILinkedList {
        int this[int index] { get; set; }
        void AddFirst(int data);
        void AddLast(int data);
        int IndexOf(int data);
        void RemoveFirst();
        void RemoveLast();
        string ToString();
    }
}