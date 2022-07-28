using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    // for network problem
    public class Pipe {
        public int dest;
        public double flow;
        public double capacity;

        public Pipe(int dest, double flow, double capacity) {
            this.dest = dest;
            this.flow = flow;
            this.capacity = capacity;
        }
        public Pipe(int dest, double capacity) {
            this.dest = dest;
            this.capacity = capacity;
        }
        public Pipe(Pipe previous) {
            dest = previous.dest;
            flow = previous.flow;
            capacity = previous.capacity;
        }
        public override string ToString() {
            return $"({dest}, {flow}/{capacity})";
        }
    }
}
