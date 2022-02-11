using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public abstract class BinarySearchTree {
        public abstract List<int> PreOrder();
        public abstract List<int> InOrder();
        public abstract List<int> PostOrder();
        public abstract List<int> LevelOrder();
        public abstract void Insert(int data);
        public abstract void Delete(int data);
        public abstract bool Search(int data);
        public abstract int MinHeight();
        public abstract int MaxHeight();
        public abstract int Count { get; }
        
    }
}
