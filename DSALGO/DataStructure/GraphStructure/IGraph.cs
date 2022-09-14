
using DSALGO.DataStructure.GraphStructure;

namespace DSALGO.DataStructure.Graph {
    public interface IGraph {
        bool isUndirected { get; }
        int NodeCount { get; }

        void AddEdge(Edge edge);
        void AddEdge(int from, int to, int weight);
        void AddNode(int node);
        void Clear();
        bool ContainsEdge(int from, int to);
        bool ContainsNode(int node);
        void DeleteEdge(int from, int to);
        void DeleteNode(int node);
        void EditEdge(int from, int to, int newWeight);
        List<Edge> GetAdjEdges(int node);
        List<int> GetAdjNodes(int node);
        List<int> GetAllNodes();
        void Print();
        List<Edge> ToEdgeList();
    }
}