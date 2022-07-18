namespace DSALGO.DataStructure {
    public abstract class LinkedList {
        public abstract int this[int index] { get; set; }
        public abstract void AddFirst(int data);
        public abstract void AddLast(int data);
        public abstract int IndexOf(int data);
        public abstract void RemoveFirst();
        public abstract void RemoveLast();
        public abstract void InsertAt(int index, int data);
        public abstract void RemoveAt(int index);
        public abstract int Count { get; }

    }
}