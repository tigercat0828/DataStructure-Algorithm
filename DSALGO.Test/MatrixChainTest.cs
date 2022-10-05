using DSALGO.Algorithm.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Test {
    public class MatrixChainTest {
        void Test() {
            //int[] P = new int[] { 4, 10, 3, 12, 20, 7 };
            int[] P = new int[] { 30, 35, 15, 5, 10, 20, 25 };
            MatrixChain chain = new();
            Console.WriteLine(chain.MinOperateCount(P));
            chain.PrintTable();
        }
    }
}
