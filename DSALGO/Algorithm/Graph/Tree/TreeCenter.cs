using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.Graph.Tree {
    public static class TreeCenter {
        public static List<int> Get(DataStructure.Graph.Graphz graph) {
            Dictionary<int, int> degreeMap = new();
            List<int> leaves = new();

            foreach (var vertex in graph.GetAllNodes()) {
                degreeMap[vertex] = graph.GetLinkedNodes(vertex).Count;
                if (graph.GetLinkedNodes(vertex).Count <= 1) {
                    leaves.Add(vertex);
                }
            }

            int processLeaves = leaves.Count;
            int total = graph.nodeCount;
            while (processLeaves < total) {
                List<int> newLeaves = new();

                foreach (var leaf in leaves) {

                    foreach (var node in graph.GetLinkedNodes(leaf)) {
                        if (--degreeMap[node] == 1) {
                            newLeaves.Add(node);
                        }
                    }

                    degreeMap[leaf] = 0;
                }
                processLeaves += newLeaves.Count;
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
