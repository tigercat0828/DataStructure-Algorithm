using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {

    // Binary Search Tree (Array)
    public class ABinarySearchTree : BinarySearchTree {

        const int NULL = int.MinValue;
        const int ROOT = 0;
        int[] BST;
        int _level;
        int _count;
        public ABinarySearchTree() {
            _level = 1;
            int capacity = (int)Math.Pow(2, _level) -1;
            BST = new int[capacity];
            Array.Fill(BST, NULL); // set all node value to default NULL
            _count = 0;
        }

        public override int Count => _count;

        public override void Delete(int data) {
            throw new NotImplementedException();
        }

        public override List<int> InOrder() {
            List<int> list = new List<int>();
            inOrder(ROOT, list);
            return list;
        }
        private void inOrder(int root,List<int> list) {
            if (root < BST.Length && BST[root] != NULL) {
                inOrder(root * 2 + 1, list);
                list.Add(BST[root]);
                inOrder(root * 2 + 2, list);
            }
        }

        public override void Insert(int data) {
            int root = 0;
            int capacity = BST.Length;
            
            while( root < capacity) {
                // reach the NULL node
                if (BST[root] == NULL) {
                    break;    
                }
                // go to left
                if (data < BST[root]) {
                    root = root * 2 + 1;
                    continue;
                }
                // go to right
                else if(data > BST[root]) {
                    root = root * 2 + 2;
                    continue;
                }
            }
            if(root >= capacity) {
                updateCapacity();
            }
            // to the empty tree node
            BST[root] = data;
            _count++;
        }
        private void updateCapacity() {
            _level++;
            int newCapacity = (int)Math.Pow(2, _level) - 1;
            int[] newbst = new int[newCapacity];
            Array.Fill(newbst, NULL);
            Array.Copy(BST, newbst, BST.Length);
            BST = newbst;
        }
        public override List<int> LevelOrder() {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            queue.Enqueue(ROOT);
            while( queue.Count > 0 ) {
                int root = queue.Dequeue();
                if (root < BST.Length && BST[root] != NULL) {
                    list.Add(BST[root]);
                    queue.Enqueue(root * 2 +1);
                    queue.Enqueue(root * 2 + 2);
                }
            }
            return list;
        }
        public override int MaxHeight() {
            return maxHeight(ROOT);
        }
        private int maxHeight(int root) { 
            
            // case 0 : empty tree
            if(BST[ROOT] == NULL)return 0;
            
            int capacity = BST.Length;
            int left = root * 2 + 1;
            int right = root * 2 + 2;
            
            // case 1 : leaf node
            if (left >= capacity && right >= capacity) return 1;
            if (BST[left] == NULL && BST[right] == NULL) return 1;
            
            // case 2 : only have one child
            if(BST[left] == NULL || left > capacity) {
                return maxHeight(right) + 1;
            }
            if (BST[right] == NULL || right > capacity) {
                return maxHeight(left) +1 ;
            }
            // case 3 : have two child
            int L = maxHeight(left);
            int R = maxHeight(right);
            return Math.Max(L, R) +1;
        }
        public override int MinHeight() {
            return minHeight(ROOT);
        }
        public int minHeight(int root) {
            // case 0 : empty tree
            if (BST[ROOT] == NULL) return 0;

            int capacity = BST.Length;
            int left = root * 2 + 1;
            int right = root * 2 + 2;

            // case 1 : leaf node 
            if ((left >= capacity && right >= capacity)) return 1;
            if(BST[left] == NULL && BST[right] == NULL) return 1;
            // case 2 : only one child is null
            if (left > capacity || BST[left] == NULL) {
                return minHeight(right);
            }
            if( right > capacity || BST[right] == NULL) {
                return minHeight(left);
            }
            // case 3 : have two child
            int Lheight = minHeight(right);
            int Rheight = minHeight(left);
            return Math.Min(Lheight, Rheight) + 1;

        }
        public override List<int> PostOrder() {
            List<int> list = new List<int>();   
            postOrder(ROOT, list);
            return list;
        }
        private void postOrder(int root, List<int> list) {
            if (root < BST.Length && BST[root] != NULL) {
                postOrder(root * 2 + 1, list);
                postOrder(root * 2 + 2, list);
                list.Add(BST[root]);
            }
        }
        public override List<int> PreOrder() {
            List<int> list = new List<int>();   
            preOrder(ROOT, list);
            return list;
        }
        private void preOrder(int root, List<int> list) {
            if (root < BST.Length && BST[root] == NULL) {
                list.Add(BST[root]);
                preOrder(root * 2 + 1, list);
                preOrder(root * 2 + 2, list);
            }
        }
        public override bool Search(int data) {
            int root = ROOT;
            int capacity = BST.Length;
            while (root < capacity) {
                if (data < BST[root]) {
                    root = root * 2 + 1;
                    continue;
                }
                if (data > BST[root]) {
                    root = root * 2 + 2;
                    continue;
                }
                else {
                    return true;
                }
            }
            return false;
        }
        
    }
}
