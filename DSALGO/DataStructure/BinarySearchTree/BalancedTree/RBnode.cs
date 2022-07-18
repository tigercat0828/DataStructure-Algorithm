namespace DSALGO.DataStructure.BinarySearchTree.BalancedTree
{
    public class RBnode<T>
    {

        public const bool Black = true;
        public const bool Red = false;

        public T key;
        public bool color;
        public RBnode<T> left;
        public RBnode<T> right;
        public RBnode<T> parent;
        public RBnode(T key, RBnode<T> left = null, RBnode<T> right = null, bool color = Red)
        {
            this.key = key;
            this.color = color;
            this.left = left;
            this.right = right;
        }
        public void SetColor(bool color)
        {
            this.color = color;
        }
        public void SetParent(RBnode<T> parent)
        {
            this.parent = parent;
        }

    }
}
