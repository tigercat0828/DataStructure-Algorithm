using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
using System.Collections.Generic;
using Xunit;

namespace DSALGO.Test {
    public class TopsortOnDAGTest {
        [Fact]
        public void FindShortestPathTest() {

            DGraph graph = new(6);
            graph.AddEdge(0, 1, 5);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 6);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 4, 4);
            graph.AddEdge(2, 5, 2);
            graph.AddEdge(3, 4, -1);
            graph.AddEdge(4, 5, -2);

            TopsortOnDAG pathFinder = new TopsortOnDAG(graph);

            (List<int> path, int cost) = pathFinder.FindPath(0, 5);
            pathFinder.GetCosts();

            Assert.Equal(new int[] { 0, 5, 3, 10, 7, 5 }, pathFinder.GetCosts());
            Assert.Equal(new List<int>(0) { 0, 2, 5 }, path);
            Assert.Equal(5, cost);
        }
    }
}
