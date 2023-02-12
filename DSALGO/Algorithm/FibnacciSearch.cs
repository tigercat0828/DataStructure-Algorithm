using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm {
    internal class FibnacciSearch {
        public int Search(int[] A, int x) {
            int n = A.Length;
            int F1 = 1, F2 = 0;
            int F = F1 + F2;
            // init fibnacci series
            while (F < n) {
                F2 = F1;
                F1 = F;
                F = F1 + F2;
            }
            int offset = -1;
            int cmp = 0;

            while (F > 1) {

                int i = Math.Min(offset + F2, n - 1);
                Console.WriteLine($"{++cmp} A[{i}]={A[i]} ");

                if (A[i] < x) {
                    F = F1;
                    F1 = F2;
                    F2 = F - F1;
                    offset = i;
                }
                else if (A[i] > x) {
                    F = F2;
                    F1 = F1 - F2;
                    F2 = F - F1;
                }
                else
                    return i;
            }
            if (F1 == 1 && A[n - 1] == x) return n - 1;
            return -1;
        }
    }
}
