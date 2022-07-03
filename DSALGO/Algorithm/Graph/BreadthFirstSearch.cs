

using DSALGO.DataStructures.Graph;

namespace DSALGO.Algorithm.Graph {
    public class BreadthFirstSearch {

        public List<int> FindPath(AdjacencyList graph, int start, int end) {

            if (start == end) return new List<int>() { start };

            List<int> path = new();

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

                foreach (var node in graph[pop]) {
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
            return path;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">2d array represent the maze</param>
        /// <param name="sr">start row</param>
        /// <param name="sc">start column</param>
        /// <param name="er">end row</param>
        /// <param name="ec">end column</param>
        /// <returns></returns>
        public List<(int, int)> FindPath(int[][] matrix, int sr, int sc, int er, int ec) {
            return new List<(int, int)>();
        }
    }
}
