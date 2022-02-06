namespace DSALGO.Interfaces {
    public interface ILinkedList {
        int this[int index] { get; set; }
        int Count { get; }
        void AddFirst(int data);
        void AddLast(int data);
        int IndexOf(int data);
        void RemoveFirst();
        void RemoveLast();
        void InsertAt(int index, int data);
        void RemoveAt(int index);
    }
}