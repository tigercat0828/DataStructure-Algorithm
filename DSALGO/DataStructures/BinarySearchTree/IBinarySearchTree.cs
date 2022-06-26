namespace DSALGO.DataStructures {
    public interface IBinarySearchTree {
        List<int> PreOrder();
        List<int> InOrder();
        List<int> PostOrder();
        List<int> LevelOrder();
        void Insert(int data);
        void Delete(int data);
        bool Search(int data);
        int MinHeight();
        int MaxHeight();
        int Count { get; }
    }
}
