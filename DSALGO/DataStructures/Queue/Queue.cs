using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public abstract class Queue {
        public abstract int Count { get; }
        public abstract void Enqueue(int data);
        public abstract int Dequeue();
    }
}
