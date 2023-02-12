using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
using System.Collections.Generic;
using Xunit;

namespace DSALGO.Test {

    public class DijsktraTest {

        [Fact]
        public void FindPathTest() {

            DGraph graph = new(5);
            graph.AddEdge(0, 1, 6);
            graph.AddEdge(0, 2, 7);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(1, 3, 5);
            graph.AddEdge(1, 4, -4);
            graph.AddEdge(2, 3, -3);
            graph.AddEdge(2, 4, 9);
            graph.AddEdge(3, 1, -2);
            graph.AddEdge(3, 1, -2);
            graph.AddEdge(4, 3, 7);

            Dijkstra pathFinder = new(graph);
            (List<int> actualpath, int cost) = pathFinder.FindPath(0, 4);
            List<int> expectPath = new() { 0, 3, 4, 5 };
            Assert.Equal(expectPath, actualpath);
            Assert.Equal(6, cost);
        }
    }
}
