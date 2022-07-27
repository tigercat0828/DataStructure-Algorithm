namespace DSALGO.DataStructure.Graph {

    public class Link {
        public int dest;
        public double weight;
        public Link(int dest, double cost) {
            this.dest = dest;
            this.weight = cost;
        }
        public Link(Link previous) { 
            dest = previous.dest;
            weight = previous.weight;
        }
        public override string ToString() {
            return $"({dest},{weight})";
        }
    }
}