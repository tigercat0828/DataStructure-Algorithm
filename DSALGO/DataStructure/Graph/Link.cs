namespace DSALGO.DataStructure.Graph {

    public class Link {
        public int to;
        public double weight;
        // for network flow problem
   
        public Link(int dest, double weight) {
            this.to = dest;
            this.weight = weight;
        }

        public Link(Link previous) { 
            to = previous.to;
            weight = previous.weight;
        }

        public override string ToString() {
            return $"({to},{weight})";
        }
    }
}