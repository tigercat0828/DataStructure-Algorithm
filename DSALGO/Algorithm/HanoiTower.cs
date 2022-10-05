using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm {
    public class HanoiTower {
        public void Perform(int n) {
            hanoi(n, 1, 3);
        }
        private void hanoi(int n, int from, int dest) {
            if (n == 1) {
                Console.WriteLine($"Move {from} to {dest}");
            }
            else {
                int other = 6 - from - dest;
                hanoi(n - 1, from, other);
                Console.WriteLine($"Move {from} to {dest}");
                hanoi(n - 1, other, dest);
            }
        }
    }
}
