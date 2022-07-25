namespace DSALGO.DataStructure.Graph {

    public class Link {
        public int dest;
        public double cost;
        public Link(int dest, double cost) {
            this.dest = dest;
            this.cost = cost;
        }
        public override string ToString() {
            return $"{dest}({cost})";
        }
    }
}