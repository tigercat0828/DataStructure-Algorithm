using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
using System.Collections.Generic;
using Xunit;

namespace DSALGO.Test {

    public class DijsktraTest {

        [Fact]
        public void FindPathTest() {

            Graph graph = new(7);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 3, 3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 4, 4);
            graph.AddEdge(3, 4, 2);
            graph.AddEdge(2, 5, 5);
            graph.AddEdge(4, 5, 1);

            Dijkstra pathFinder = new(graph);
            (List<int> actualpath, int cost) = pathFinder.FindPath(0, 5);
            List<int> expectPath = new() { 0, 3, 4, 5 };
            Assert.Equal(expectPath, actualpath);
            Assert.Equal(6, cost);
        }
    }
}
