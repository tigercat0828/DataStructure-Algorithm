namespace DSALGO.DataStructures.Graph {
    public class Edge {
        public int from;
        public int to;
        public int weight;
        public Edge(int from, int to, int weight) {
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