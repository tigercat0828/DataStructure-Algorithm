using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Interfaces {
    public interface IStack {
        int Count { get; }
        int Pop();
        void Push(int data);
        int Peek();
    }
}
