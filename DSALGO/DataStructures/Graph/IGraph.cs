
namespace DSALGO.DataStructures.Graph {
    public interface IGraph {
        List<int> this[int node] { get; }

        bool isUndirected { get; }
        int nodeCount { get; }

        void AddEdge(Edge edge);
        void AddNode(int node);
        List<int> BFtraversal(int node);
        bool Contains(int node);
        void DeleteEdge(int from, int to);
        void DeleteNode(int node);
        List<int> DFtraversal(int Node);
        void Print();
    }
}