namespace DSALGO.DataStructure.DynamicArray {
    public interface IDynamicArray {
        int Count { get; }

        void Add(int data);
        void InsertAt(int index, int value);
        void InsertFirst(int value);
        void InsertLast(int value);
        void RemoveAt(int index);
        void RemoveFirst();
        void RemoveLast();

        void IndexOf(int value);

    }
}