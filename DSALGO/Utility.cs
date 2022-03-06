using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO {
    public static class Utility {
        public static void Print(List<int> list) {
            string s = "";
            foreach (var item in list) {
                s += item + ", ";
            }
            Console.WriteLine(s);
        }
        public static void Print(int[] arr) {
            string s = "";
            foreach (var item in arr) {
                s += item + ", ";
            }
            Console.WriteLine(s);
        }
    }
}
