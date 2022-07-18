using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.BinarySearchTree.BalancedTree
{
    public class AvlNode<T>
    {
        public AvlNode(T key, AvlNode<T> left = null, AvlNode<T> right = null)
        {
            this.key = key;
            this.left = left;
            this.right = right;
            factor = 0;
            height = 0;
        }
        public AvlNode<T> left;
        public AvlNode<T> right;
        public T key;
        public int height;
        public int factor;
    }
}
