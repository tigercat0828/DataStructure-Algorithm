namespace DSALGO.DataStructure.Graph {

    public class Link {
        public int dest;
        public double weight;
        // for network flow problem
   
        public Link(int dest, double weight) {
            this.dest = dest;
            this.weight = weight;
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