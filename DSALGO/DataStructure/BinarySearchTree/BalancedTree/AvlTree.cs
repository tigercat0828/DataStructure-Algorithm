namespace DSALGO.DataStructure.BinarySearchTree.BalancedTree
{
    public class AvlTree<T> : IBinaryTree<T> where T : IComparable
    {
        AvlNode<T> root;
        public int Count { get; private set; }
        public AvlTree()
        {
            Count = 0;
        }

        public bool Insert(T key)
        {
            if (Contains(key)) return false;
            root = insert(root, key);
            Count++;
            return true;
        }
        private AvlNode<T> insert(AvlNode<T> root, T key)
        {
            if (root == null) return new AvlNode<T>(key);
            int comparer = key.CompareTo(root.key);

            if (comparer < 0)
            {
                root.left = insert(root.left, key);
            }
            else
            {
                root.right = insert(root.right, key);
            }
            Update(root);
            return Balance(root);
        }

        private AvlNode<T> Balance(AvlNode<T> root)
        {
            if (root.factor == -2)
            {             // left heavy subtree
                if (root.left.factor <= 0)
                    return LLcase(root);
                else
                    return LRcase(root);
            }
            else if (root.factor == 2)
            {    // right heavy subtree
                if (root.right.factor >= 0)
                    return RRcase(root);
                else
                    return RLcase(root);
            }
            return root;
        }
        private AvlNode<T> RRcase(AvlNode<T> root) => LeftRotate(root);
        private AvlNode<T> LLcase(AvlNode<T> root) => RightRotate(root);

        private AvlNode<T> LRcase(AvlNode<T> root)
        {
            root.left = LeftRotate(root.left);
            return LLcase(root);
        }
        private AvlNode<T> RLcase(AvlNode<T> root)
        {
            root.right = RightRotate(root.right);
            return RRcase(root);
        }

        private void Update(AvlNode<T> node)
        {
            int heightL = -1;
            int heightR = -1;
            if (node.left != null) heightL = node.left.height;
            if (node.right != null) heightR = node.right.height;
            node.height = Math.Max(heightL, heightR) + 1;
            node.factor = heightR - heightL;
        }

        public bool Remove(T key)
        {
            if (!Contains(key)) return false;
            root = remove(root, key);
            Count--;
            return true;
        }

        private AvlNode<T> remove(AvlNode<T> root, T key)
        {
            int compare = key.CompareTo(root.key);
            if (compare < 0)
            {
                root.left = remove(root.left, key);
            }
            else if (compare > 0)
            {
                root.right = remove(root.right, key);
            }
            else
            {
                if (root.right == null)
                {  // only have left child or leaf node
                    return root.left;
                }
                if (root.left == null)
                {    // only have right child or leaf node
                    return root.right;
                }
                // have two children
                T min = FinMin(root.right);
                root.key = min;
                root.right = remove(root.right, min);
            }
            Update(root);
            return Balance(root);
        }
        private T FinMin(AvlNode<T> root)
        {
            AvlNode<T> node = root;
            while (root.left != null)
            {
                node = node.left;
            }
            return node.key;
        }
        public T Peek()
        {
            return root.key;
        }
        private AvlNode<T> RightRotate(AvlNode<T> A)
        {
            AvlNode<T> B = A.left;
            A.left = B.right;
            B.right = A;
            Update(A);
            Update(B);
            return B;
        }
        private AvlNode<T> LeftRotate(AvlNode<T> A)
        {
            AvlNode<T> B = A.right;
            A.right = B.left;
            B.left = A;
            Update(A);
            Update(B);
            return B;
        }
        public bool Contains(T key)
        {
            AvlNode<T> current = root;
            while (current != null)
            {
                int compare = key.CompareTo(current.key);
                if (compare > 0)
                {
                    current = current.right;
                }
                else if (compare < 0)
                {
                    current = current.left;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public List<T> PreOrder()
        {
            throw new NotImplementedException();
        }

        public List<T> PostOrder()
        {
            throw new NotImplementedException();
        }

        public List<T> InOrder()
        {
            List<T> result = new();
            inorder(root, result);
            return result;
        }
        private void inorder(AvlNode<T> root, List<T> list)
        {
            if (root == null) return;
            inorder(root.left, list);
            list.Add(root.key);
            inorder(root.right, list);
        }
        public List<T> LevelOrder()
        {

            throw new NotImplementedException();
        }

    }
}
