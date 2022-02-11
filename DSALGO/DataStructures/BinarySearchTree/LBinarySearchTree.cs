using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    // implement BinarySearchTree by using linked list
    public class LBinarySearchTree : BinarySearchTree {

        class TreeNode {
            public int data;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int data) {
                this.data = data;
            }
        }
        public override int Count => _count;

        TreeNode _root;
        int _count;

        public override bool Search(int data) {
            TreeNode target = search(_root, data);
            
            if (target != null) { 
                return true;
            }
            return false;
        }
        // recursion version
        TreeNode search(TreeNode root, int data) {

            if (data < root.data) { 
                return search(root.left, data);
            }
            if (data > root.data) {
                return search(root.right, data);   
            }
            return root;
        }

        public override int MaxHeight() {
            return maxHeight(_root);
        }
        public override int MinHeight() {
            return minHeight(_root);
        }

        private int maxHeight(TreeNode root) {
            if (root == null) return 0;
            int L = maxHeight(root.left);
            int R = maxHeight(root.right);

            return Math.Max(L, R) + 1;
        }

        private int minHeight(TreeNode root) {
            
            // case 0: empty binary tree
            if (_root == null) return 0;
            
            // case 1: leaf node
            if(root.right == null && root.left == null) return 1;
            
            // only one child is null
            if(root.right == null) {
                return minHeight(root.left) + 1;
            }
            if (root.left == null) {
                return minHeight(root.right) + 1;
            }
            // case 3: have two child
            else { 
                int L = minHeight(root.left);
                int R = minHeight(root.right);
                return Math.Min(L, R) + 1;
            }
        } 

        public override void Insert(int data) {
            _root = insert(_root, data);
            _count++;
        }

        private TreeNode insert(TreeNode root, int data) {
            if (root == null) {
                root = new TreeNode(data);
                return root;
            }
            if (data < root.data) {
                root.left = insert(root.left, data);
            }
            else if (data > root.data) {
                root.right = insert(root.right, data);
            }
            return root;
        }

        public override List<int> LevelOrder() {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<int> levels = new List<int>();
            queue.Enqueue(_root);
            while (queue.Count > 0) { 
                TreeNode t = queue.Dequeue();
                if (t != null) {
                    levels.Add(t.data);
                    queue.Enqueue(t.left);
                    queue.Enqueue(t.right);
                }
            }
            return levels;
        }
        public override List<int> InOrder() {
            List<int> list = new List<int>();
            inOrder(_root, list);
            return list;    
        }
        private void inOrder(TreeNode root, List<int> list) { 
            if(root != null) {
                inOrder(root.left, list); 
                list.Add(root.data);
                inOrder(root.right, list);
            }
        }
        public override List<int> PostOrder() {
            List<int> list = new List<int>();
            postOrder(_root, list);
            return list;
        }

        private void postOrder(TreeNode root, List<int> list) {
            if(root != null) {
                list.Add(root.data);
                postOrder(root.left, list);
                postOrder(root.right, list);
            }
        }

        public override List<int> PreOrder() {
            List<int> list = new List<int>();
            preOrder(_root, list);
            return list;
        }
        private void preOrder(TreeNode root, List<int> list) { 
            if(root != null) {
                preOrder(root.left, list);
                preOrder(root.right, list);
                list.Add(root.data);
            }
        }

        public override void Delete(int data) {
            _root = delete(_root, data); 
            _count--;
        }
        private TreeNode delete(TreeNode root, int data) {
            if (root == null) {
                return root;
            }

            if (data < root.data) {
                root.left = delete(root.left, data);

                return root;
            }
            else if (data > root.data) {
                root.right = delete(root.right, data);
                return root;
            }
            // find the target
            else {
                // deleted node which have one or no child
                if (root.left == null) {
                    _count--;
                    return root.right;
                }
                if (root.right == null) {
                    _count--;
                    return root.left;
                }
                // deleted node which have two child
                root.data = maxValue(root.left);
                root.left = delete(root.left, root.data);

                /* anthoer way to select successor */
                //  root.data = minValue(root.right);
                //  root.right = delete(root.right, root.data);
            }
            return root;
        }
        int minValue(TreeNode root) {
            int min = root.data;
            while (root.left != null) {
                root = root.left;
                min = root.data;
            }
            return min;
        }
        private int maxValue(TreeNode root) { 
            int max = root.data;
            while (root.right != null) {
                root = root.right;
                max = root.data;
            }
            return max;
        }
    }
}
