namespace DSALGO.DataStructure.GraphStructure {
    // for network problem
    public class Pipe {
        public int from;
        public int to;
        public int flow;
        public int capacity;


        public Pipe(int dest, int capacity) {
            to = dest;
            this.capacity = capacity;
        }
        public Pipe(Pipe previous) {
            from = previous.from;
            to = previous.to;
            flow = previous.flow;
            capacity = previous.capacity;
        }
        public Pipe(int from, int to, int flow, int capacity) {
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
