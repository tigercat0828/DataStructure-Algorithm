using DSALGO.Algorithm.GraphTheory;
using DSALGO.DataStructure.GraphStructure;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DSALGO.Test {
    public class TopologicalSortTest {

        [Fact]
        public void TopsortTest() {
            DGraph graph = new(8);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(1, 6);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 6);
            graph.AddEdge(4, 7);
            graph.AddEdge(5, 7);
            TopologicalSort sorter = new(graph);
            List<int> result = sorter.Topsort().ToList();

            int index0 = result.IndexOf(0);
            int index1 = result.IndexOf(1);
            int index2 = result.IndexOf(2);
            int index3 = result.IndexOf(3);
            int index4 = result.IndexOf(4);
            int index5 = result.IndexOf(5);
            int index6 = result.IndexOf(6);
            int index7 = result.IndexOf(7);

            Assert.True(index0 < index1);
            Assert.True(index1 < index3);
            Assert.True(index1 < index6);
            Assert.True(index1 < index5);
            Assert.True(index2 < index4);
            Assert.True(index2 < index6);
            Assert.True(index4 < index7);
            Assert.True(index5 < index7);
        }
    }
}
