using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public static class BreadthFirstSearch {
        public static int FindPath(GraphList graph, int start, int end, ref List<int> path) {

            if (start == end) {
                path = new List<int>() { start };
                return 0;
            }

            Dictionary<int, int> previous = new();
            HashSet<int> visited = new();
            Queue<int> queue = new();
            bool isTargetFound = false;

            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0) {
                int pop = queue.Dequeue();
                if (pop == end) {
                    isTargetFound = true;
                    break;
                }

                foreach (var node in graph.GetAdjNodes(pop)) {
                    if (visited.Contains(node)) continue;
                    queue.Enqueue(node);
                    visited.Add(node);
                    previous[node] = pop;
                }
            }
            if (isTargetFound) {
                for (int i = end; i != start; i = previous[i]) {
                    path.Add(i);
                }
                path.Add(start);
                path.Reverse();
            }
            return path.Count;
        }

    }
}
