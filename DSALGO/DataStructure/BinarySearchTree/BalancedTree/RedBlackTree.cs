namespace DSALGO.DataStructure.BinarySearchTree.BalancedTree {
    public class RedBlackTree<T> : IBinaryTree<T> where T : IComparable<T> {

        private const bool BLACK = true;
        private const bool RED = false;

        public RBnode<T> root;
        public RBnode<T> Neel;
        public RedBlackTree() {
            Count = 0;
            Neel = new RBnode<T>(default);
            Neel.SetColor(BLACK);
        }
        public int Count { get; private set; }

        public bool Contains(T key) {
            if (key == null || root == null) return false;
            RBnode<T> current = root;
            while (current != Neel) {
                int cmp = key.CompareTo(current.key);
                if (cmp < 0) current = current.left;
                else if (cmp > 0) current = current.right;
                else return true;
            }
            return false;
        }
        public void InsertFixUp(RBnode<T> node) {
            RBnode<T> P = node.parent;
            if (P == Neel || P.color == BLACK) return;
            RBnode<T> U = GetBrother(P);
            if (U.color == RED) {
                P.SetColor(BLACK);
                U.SetColor(BLACK);
                P.parent.SetColor(RED);
                InsertFixUp(P.parent);
            }
            else {  // uncle is black

                if (P.parent.left == P) {      // case LR
                    if (P.right == node) {
                        RBnode<T> current = P;
                        LeftRotate(current);
                        P = current.parent;
                    }
                    P.SetColor(BLACK);          // case LL
                    P.parent.SetColor(RED);
                    RightRotate(P.parent);
                }
                else if (P.parent.right == P) { // case RL
                    if (P.left == node) {
                        RBnode<T> current = P;
                        RightRotate(current);
                        P = current.parent;
                    }
                    P.SetColor(BLACK);          // case RR
                    P.parent.SetColor(RED);
                    LeftRotate(P.parent);
                }
            }
            root.SetColor(BLACK);
        }
        /// <summary>
        /// Get Sibling of node and output the direction
        /// </summary>
        /// <param name="node"></param>
        /// <param name="Sdir">sibling direction</param>
        /// <returns></returns>
        public RBnode<T> GetBrother(RBnode<T> node) {
            RBnode<T> P = node.parent;
            if (P.left == node)
                return P.right;
            else
                return P.left;
        }

        public bool Insert(T key) {

            RBnode<T> newLeaf = new RBnode<T>(key, Neel, Neel, RED);
            if (root == null) {
                root = newLeaf;
                root.SetColor(BLACK);
                root.SetParent(Neel);
                Count++;
                return true;
            }
            RBnode<T> previous = Neel;
            RBnode<T> current = root;
            while (current != Neel) {
                previous = current;
                int cmp = key.CompareTo(current.key);
                if (cmp < 0) current = current.left;
                else if (cmp > 0) current = current.right;
                else return false;
            }

            newLeaf.SetParent(previous);

            if (newLeaf.key.CompareTo(previous.key) < 0) {
                previous.left = newLeaf;
            }
            else {
                previous.right = newLeaf;
            }
            //PrintTree();
            //Utility.PrintLine();
            InsertFixUp(newLeaf);
            Count++;
            return true;
        }
        public void TestPrivateFun() {
            RightRotate(root);
        }
        public List<T> InOrder() {
            throw new NotImplementedException();
        }
        public void LeftRotate(RBnode<T> X) {
            RBnode<T> Y = X.right;
            RBnode<T> P = X.parent;
            // -------------------------
            X.right = Y.left;
            if (Y.left != Neel) {
                Y.left.parent = X;
            }
            // -------------------------
            Y.parent = P;
            if (P == Neel) {
                root = Y;
            }
            else if (P.left == X) {
                P.left = Y;
            }
            else {
                P.right = Y;
            }
            // ------------------------
            Y.left = X;
            X.parent = Y;
        }
        public void RightRotate(RBnode<T> X) {
            RBnode<T> Y = X.left;
            RBnode<T> P = X.parent;
            // -------------------------
            X.left = Y.right;
            if (Y.right != Neel) {
                Y.right.parent = X;
            }
            // -------------------------
            Y.parent = P;
            if (P == Neel) {
                root = Y;
            }
            else if (P.left == X) {
                P.left = Y;
            }
            else {
                P.right = Y;
            }
            // ------------------------
            Y.right = X;
            X.parent = Y;
        }
        public List<T> LevelOrder() {
            throw new NotImplementedException();
        }

        public T Peek() {
            return root.key;
        }

        public List<T> PostOrder() {
            throw new NotImplementedException();
        }
        public List<T> PreOrder() {
            throw new NotImplementedException();
        }
        public bool Remove(T key) {
            RBnode<T> target = search(key);
            if (target == null) return false;

            RBnode<T> y = null; // the node to be free
            RBnode<T> x = null;

            // get the node to be free 'y'
            if (target.right == Neel || target.left == Neel) y = target;
            else y = successor(target);

            // get child of y => x
            if (y.left != Neel) x = y.left;
            else x = y.right;

            // link to Y.parent to x
            x.parent = y.parent;
            if (y.parent == Neel) root = x;
            else if (y == y.parent.left) y.parent.left = x;
            else y.parent.right = x;

            if (y != target) target.key = y.key;
            if (y.color == BLACK) DeleteFixUp(x);
            return true;
        }
        private void DeleteFixUp(RBnode<T> N) {
            Console.WriteLine(N.parent);    // FOR debug
            // case A: sibling is black, has a red child (terminating case), LL/LR/RR/RL
            // case B: sibling is black, has both black child
            // case C: sibling is red.
            RBnode<T> S = GetBrother(N);

            if (S.color == RED) {   // case C
                S.SetColor(BLACK);
                S.parent.SetColor(RED);
                if (S.parent.left == S) RightRotate(S.parent);
                if (S.parent.right == S) LeftRotate(S.parent);
                DeleteFixUp(N);
                return;
            }
            if (S.color == BLACK) {
                if (S.left.color == BLACK && S.right.color == BLACK) { // case B
                    S.SetColor(RED);
                    if (S.parent.color == RED) {
                        S.parent.SetColor(BLACK);
                    }
                    else if (S.parent.color == BLACK) {
                        S.SetColor(RED);
                        DeleteFixUp(S.parent);

                    }
                    return;
                }
                if (S.left.color == RED) {  // case A

                    if (S.parent.left == S) {
                        if (S.right.color == RED) {     // case A-LR
                            LeftRotate(S);
                        }
                        // case A-LL
                        RightRotate(N.parent);
                        RBnode<T> GP = N.parent.parent;
                        GP.SetColor(GP.right.color);
                        GP.left.SetColor(BLACK);
                        GP.right.SetColor(BLACK);
                    }
                    else if (S.parent.right == S) {
                        if (S.left.color == RED) {      // case A-RL
                            RightRotate(S);
                        }
                        // case A-RR
                        LeftRotate(N.parent);
                        RBnode<T> GP = N.parent.parent;
                        GP.SetColor(GP.left.color);
                        GP.left.SetColor(BLACK);
                        GP.right.SetColor(BLACK);
                    }
                }
            }
        }
        private RBnode<T> successor(RBnode<T> x) {
            RBnode<T> current = x;
            // min key of right subtree
            if (current.right != null) {
                current = current.right;
                while (current.left != null) {
                    current = current.left;
                }
                return current;
            }
            // inorder successor
            RBnode<T> P = current.parent;
            while (P != null && current == P.right) {
                current = P;
                P = P.parent;
            }
            return P;
        }

        private RBnode<T> search(T key) {
            RBnode<T> current = root;
            while (current != null) {
                int cmp = key.CompareTo(current.key);
                if (cmp > 0) current = current.left;
                else if (cmp < 0) current = current.right;
                else return current;
            }
            return null;
        }
        void print(RBnode<T> root, int space) {
            int i;
            if (root != Neel) {
                space = space + 10;
                print(root.right, space);
                Console.WriteLine("");
                for (i = 10; i < space; i++) {
                    Console.Write(" ");
                }
                if (root.color == RED) {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(root.key);
                print(root.left, space);
            }
        }
        // function to print the tree.
        public void PrintTree() {
            print(root, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
