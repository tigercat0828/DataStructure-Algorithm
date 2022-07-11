using DSALGO.DataStructures.BinarySearchTree;

namespace DSALGO.DataStructures {
    // implement BinarySearchTree by using linked list
    public class ListBasedBinarySearchTree<T> : IBinaryTree<T> where T : IComparable {

        TreeNode<T> _root;
        public int Count { get; private set; }

        public ListBasedBinarySearchTree(T key) {
            _root = new TreeNode<T>(key);
            Count = 1;
        }
        public ListBasedBinarySearchTree() {
            Count = 0;
        }
        public List<T> InOrder() {
            List<T> result = new List<T>();
            inorder(_root, result);
            return result;
        }
        private void inorder(TreeNode<T> root, List<T> result) {
            if (root == null) return;
            inorder(root.left, result);
            result.Add(root.key);
            inorder(root.right, result);
        }
        public bool Insert(T key) {
            if (Contains(key)) return false;    // duplicate key
            _root = insert(_root, key);
            Count++;
            return true;
        }
        private TreeNode<T> insert(TreeNode<T> root, T key) {
            if (root == null) {
                return new TreeNode<T>(key);
            }
            int compare = key.CompareTo(root.key);
            if (compare > 0) {
                root.right = insert(root.right, key);
            }
            else {
                root.left = insert(root.left, key);
            }
            return root;
        }
        public List<T> LevelOrder() {
            throw new NotImplementedException();
        }
        public T Peek() => _root.key;
        public List<T> PostOrder() {
            throw new NotImplementedException();
        }

        public List<T> PreOrder() {
            throw new NotImplementedException();
        }

        public void Remove(T key) {
            if (!Contains(key)) return;
            _root = remove(_root, key);
            Count--;
        }
        private TreeNode<T> remove(TreeNode<T> root, T key) {

            if (root == null) return null;

            int compare = key.CompareTo(root.key);
            if (compare < 0) {
                root.left = remove(root.left, key);
            }
            else if (compare > 0) {
                root.right = remove(root.right, key);
            }
            // find the target
            else {

                // case 1 : only have right child or leaf node
                if (root.left == null) {
                    return root.right;
                }
                // case 2 : only have left child or leaf node
                if (root.right == null) {
                    return root.left;
                }
                // case 3 : have 2 children
                T min = MinValue(root.right);
                root.key = min;
                root.right = remove(root.right, min);

            }
            return root;
        }

        private T MinValue(TreeNode<T> root) {
            while (root.left != null) {
                root = root.left;
            }
            return root.key;
        }
        private T Max(TreeNode<T> right) {
            throw new NotImplementedException();
        }

        public bool Contains(T key) {
            return contains(_root, key);
        }
        private bool contains(TreeNode<T> root, T key) {
            if (root == null) return false;

            int compare = root.key.CompareTo(key);
            if (compare < 0)
                return contains(root.left, key);
            else if (compare > 0)
                return contains(root.right, key);
            else
                return true;
        }
        /*
         */
        public bool Contains_Iter(T key) {
            TreeNode<T> current = _root;
            while (current != null) {
                if (current.key.CompareTo(key) < 0) {
                    current = current.left;
                }
                else if (current.key.CompareTo(key) > 0) {
                    current = current.right;
                }
                else {
                    return true;
                }
            }
            return false;
        }
    }
}
