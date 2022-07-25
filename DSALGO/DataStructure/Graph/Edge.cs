namespace DSALGO.DataStructure.Graph {
    public class Edge {
        public int from;
        public int to;
        public double weight;
        public Edge(int from, int to, double weight) {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }
        public Edge(int from, int to) {
            this.from = from;
            this.to = to;
        }
        public (int, int) ToTuple() {
            return (from, to);
        }
    }
}