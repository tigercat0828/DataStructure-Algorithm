using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public abstract class Stack {
        public abstract int Count { get; }
        public abstract int Pop();
        public abstract void Push(int data);
        public abstract int Peek();
    }
}
