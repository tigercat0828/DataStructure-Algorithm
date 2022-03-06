using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm {
    public static class MergeSort {
        /* 
         * Time Complexity : O(nlogn)
         * Stable : yes
         * in-place : yes
         */
        public static void Run(int[] arr) {
            Sort(arr, 0, arr.Length-1);
        }
        private static void Sort(int[] arr, int left, int right) {
            if (left < right) {
                //int mid = (left + right)/2;
                int mid = left + (right - left) / 2;
                Sort(arr, left, mid);
                Sort(arr, mid + 1, right);
                merge(arr, left, mid, right);
            }

        }
       
        private static void merge(int[] arr, int L, int M, int R) {
            int Lnum = M - L + 1;
            int Rnum = R - M;
            
            int[] Larr = new int[Lnum];
            int[] Rarr = new int[Rnum];

            // copy arr data to two tmo array
            for (int t = 0; t < Lnum; t++) { 
                Larr[t] = arr[L+t];
            }
            for (int t = 0; t < Rnum; t++) {
                Rarr[t] = arr[M + 1 + t];
            }

            int i = 0; // index for Larr
            int j = 0; // index for Rarr
            int k = L; // starting index in arr
            while (i < Lnum && j < Rnum) { 
                if(Larr[i] <= Rarr[j]) {
                    arr[k] = Larr[i];
                    i++;
                }
                else {
                    arr[k] = Rarr[j];
                    j++;
                }
                k++;
            }
            // put the remain element into arr
            while(i < Lnum) {
                arr[k] = Larr[i];
                i++;
                k++;
            }
            while (j < Rnum) {
                arr[k] = Rarr[j];
                j++;
                k++;
            }
        }
        
        
    }
}
