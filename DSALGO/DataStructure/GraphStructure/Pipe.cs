using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    // for network problem
    public class Pipe {
        public int from;
        public int to;
        public double flow;
        public double capacity;


        public Pipe(int dest, double capacity) {
            this.to = dest;
            this.capacity = capacity;
        }
        public Pipe(Pipe previous) {
            from = previous.from;
            to = previous.to;
            flow = previous.flow;
            capacity = previous.capacity;
        }
        public Pipe(int from, int to, double flow, double capacity) {
            this.from = from;
            this.to = to;
            this.flow = flow;
            this.capacity = capacity;
        }

        public override string ToString() {
            return $"({to}, {flow}/{capacity})";
        }
    }
}
