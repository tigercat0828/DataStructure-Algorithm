using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Interfaces {
    public interface IQueue {
        int Count { get; }
        void Enqueue(int data);
        int Dequeue(int data);
        string ToString();
    }
}
