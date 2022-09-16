using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.DynamicProgramming {
    public class MatrixChain {

        // M[i,j] = min i<=k<j{ M[i,k] + M[k+1,j] + e[i-1] * e[k] * e[j] };
        int[,] M;
        int[,] S;
        int count = 0;
        public (int, int) MinOperateCount(int[] P) {
            int n = P.Length;

            AllocateSpace(n);

            for (int i = 1; i <= n - 1; i++) {
                for (int j = 1; j <= n - 1 - i; j++) {
                    int I = j;
                    int J = j + i;
                    //Console.Write($"M[{R}, {C}]   ");
                    for (int k = I; k < J; k++) {
                        
                        int next = M[I, k] + M[k + 1, J] + P[I - 1] * P[k] * P[J];
                        if (next < M[I, J]) {
                            M[I, J] = next;
                            S[I, J] = k;
                        }
                        count++;
                    }
                }
                //Console.WriteLine();
            }
            return (M[1, n - 1], 1);
        }
        public void PrintTable() {
            Console.WriteLine("DP table");
            for (int i = 1; i < M.GetLength(0); i++) {
                Console.Write("|");
                for (int j = 1; j < M.GetLength(1); j++) {
                    if (i <= j) {
                        Console.Write($"{M[i, j],6} |");
                    }
                    else {
                        Console.Write("       |");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Optimal table");
            for (int i = 1; i < M.GetLength(0); i++) {
                Console.Write("|");
                for (int j = 1; j < M.GetLength(1); j++) {
                    if (i <= j) {
                        Console.Write($"{S[i, j],2} |");
                    }
                    else {
                        Console.Write("   |");
                    }
                }
                Console.WriteLine();
            }
        }
        public void AllocateSpace(int n) {
            M = new int[n, n];
            S= new int[n, n];
            for (int i = 0; i < M.GetLength(0); i++) {
                for (int j = 0; j < M.GetLength(1); j++) {
                    M[i, j] = int.MaxValue;
                }
            }
            for (int i = 0; i < M.GetLength(0); i++) {
                M[i, i] = 0;
            }
            
        }
    }
}