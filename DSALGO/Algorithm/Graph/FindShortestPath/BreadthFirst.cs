using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.Graph.FindShortestPath
{
    public class BreadthFirstSearch
    {
        readonly Graphz graph;
        public BreadthFirstSearch(Graphz graph) {
            this.graph = graph;
        }
        public List<int> FindPath(int start, int end)
        {

            if (start == end) return new List<int>() { start };

            List<int> path = new();

            Dictionary<int, int> previous = new();
            HashSet<int> visited = new();
            Queue<int> queue = new();
            bool isTargetFound = false;

            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                int pop = queue.Dequeue();
                if (pop == end)
                {
                    isTargetFound = true;
                    break;
                }

                foreach (var node in graph.GetLinkedNodes(pop))
                {
                    if (visited.Contains(node)) continue;
                    queue.Enqueue(node);
                    visited.Add(node);
                    previous[node] = pop;
                }
            }
            if (isTargetFound)
            {
                for (int i = end; i != start; i = previous[i])
                {
                    path.Add(i);
                }
                path.Add(start);
                path.Reverse();
            }
            return path;
        }

    }
}
