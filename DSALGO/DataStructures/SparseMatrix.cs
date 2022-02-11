using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public class SparseMatrix {
        class Entry {
            public int row;
            public int col;
            public int val;
            public Entry(int row, int col, int val) {
                this.row = row;
                this.col = col;
                this.val = val;
            }
        }
        List<Entry> entries;

        public SparseMatrix() { 
            entries = new List<Entry>();
        }
        public void Transpose() {

        }

        public void AddEntry(int row, int col, int value) {
            entries.Add(new Entry(row, col, value));
        }
    }
}
