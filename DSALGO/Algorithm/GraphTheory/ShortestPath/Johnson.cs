namespace DSALGO.Algorithm.GraphTheory.ShortestPath {

    // Time Complexity O(VE + V^2logV)
    // allow negative 
    public class Johnson {
        /*
        step 1 add a new Node S to each node, and weight is 0 (s, v, 0)
        step 2 perform BellmanFord, produce h(v) is cost of s to v 
        step 3 rewrite each edge with w(u,v) = w(u,v) + h(u) - h(v)
        step 4 perform Dijsktra on each node                     
        1. O(V)
        2. O(VE)
        3. O(E) 
        4. V * O(E+VlogV)
        */
    }
}
