namespace DSALGO.DataStructure.GraphStructure {
    public struct Edge {
        public int from;
        public int to;
        public int weight;
        public Edge(int from, int to, int weight = 0) {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public Edge(Edge previous) {
            from = previous.from;
            to = previous.to;
            weight = previous.weight;
        }
        public override string ToString() {
            return $"[{from}, {to}, {weight}]";
        }
    }
}