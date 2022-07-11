namespace DSALGO.DataStructures {

    // Binary Search Tree (Array)
    public class ArrayBasedBinarySearchTree<T> : IBinaryTree<T> where T:IComparable {
        
        const int ROOT = 0;
        T[] tree;
        int _level;
        public int Count { get; private set; }
        public ArrayBasedBinarySearchTree() {
            _level = 1;
            int capacity = (int)Math.Pow(2, _level) - 1;
            tree = new T[capacity];
            Count = 0;
        }

        public void Remove(int data) {
            throw new NotImplementedException();
        }

        public List<T> InOrder() {
            List<T> list = new List<T>();
            inorder(ROOT, list);
            return list;
        }
        private void inorder(int root, List<T> list) {
            if (root < tree.Length && tree[root] != null) {
                inorder(root * 2 + 1, list);
                list.Add(tree[root]);
                inorder(root * 2 + 2, list);
            }
        }

        public bool Insert(T data) {
            int root = 0;
            int capacity = tree.Length;
            if(Contains(data)) {
                return false;
            }
            while (root < capacity) {
                int comapre = data.CompareTo(tree[root]);

                if (tree[root] == null) {    // reach the NULL node
                    break;
                }
                else if (comapre < 0) {     // go to left
                    root = root * 2 + 1;
                }
                else if (comapre > 0) {     // go to right
                    root = root * 2 + 2;
                }
            }
            if (root >= capacity) {
                updateCapacity();
            }
            // to the empty tree node
            tree[root] = data;
            Count++;
            return true;
        }
        private void updateCapacity() {
            _level++;
            int newCapacity = (int)Math.Pow(2, _level) - 1;
            T[] newbst = new T[newCapacity];
            Array.Copy(tree, newbst, tree.Length);
            tree = newbst;
        }
        public List<T> LevelOrder() {
            Queue<int> queue = new Queue<int>();
            List<T> list = new List<T>();
            queue.Enqueue(ROOT);
            while (queue.Count > 0) {
                int root = queue.Dequeue();
                if (root < tree.Length && tree[root] != null) {
                    list.Add(tree[root]);
                    queue.Enqueue(root * 2 + 1);
                    queue.Enqueue(root * 2 + 2);
                }
            }
            return list;
        }
  
        public List<T> PostOrder() {
            List<T> list = new List<T>();
            postorder(ROOT, list);
            return list;
        }
        private void postorder(int root, List<T> list) {
            if (root < tree.Length && tree[root] != null) {
                postorder(root * 2 + 1, list);
                postorder(root * 2 + 2, list);
                list.Add(tree[root]);
            }
        }
        public List<T> PreOrder() {
            List<T> list = new List<T>();
            preorder(ROOT, list);
            return list;
        }
        private void preorder(int root, List<T> list) {
            if (root < tree.Length && tree[root] == null) {
                list.Add(tree[root]);
                preorder(root * 2 + 1, list);
                preorder(root * 2 + 2, list);
            }
        }
        public bool Search(int data) {
            int root = ROOT;
            int capacity = tree.Length;
            while (root < capacity) {
                int compare = data.CompareTo(tree[root]);
                if (compare <0) {
                    root = root * 2 + 1;
                }
                else if (compare > 0) {
                    root = root * 2 + 2;
                    continue;
                }
                else {
                    return true;
                }
            }
            return false;
        }

        public void Remove(T value) {
            throw new NotImplementedException();
        }

        public T Peek() {
            return tree[ROOT];
        }

        public bool Contains(T value) {
            throw new NotImplementedException();
        }
    }
}
