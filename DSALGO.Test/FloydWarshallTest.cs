using DSALGO.Algorithm.GraphTheory.ShortestPath;
using DSALGO.DataStructure.GraphStructure;
using System.Collections.Generic;

namespace DSALGO.Test {
    public class FloydWarshallTest {
        public void Test() {
            DGraph graph = new(5);
            graph.AddEdge(0, 4, 1);
            graph.AddEdge(4, 0, 6);
            graph.AddEdge(3, 4, 6);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 2, 1);
            graph.AddEdge(2, 0, 7);
            graph.AddEdge(0, 2, 7);
            graph.AddEdge(0, 1, 5);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(2, 1, 5);
            graph.Print();
            int[][] mat = graph.ToMatrix();

            //for (int i = 0; i < mat.Length; i++) {
            //    for (int j = 0; j < mat[0].Length; j++) {
            //        if (mat[i][j] == Graph.CANT_REACH) {
            //            Console.Write($"{"-",4}");
            //        }
            //        else {
            //            Console.Write($"{mat[i][j],4}");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            FloydWarshall pathFinder = new(graph);
            (List<int> path, int cost) = pathFinder.FindPath(4, 2);
            path.Print();
            //Console.WriteLine(cost);
        }
    }
}
