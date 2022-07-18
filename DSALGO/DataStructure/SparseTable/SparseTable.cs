namespace DSALGO.DataStructure.SparseTable {
    public class SparseTable {
        int row;
        int col;
        private int[][] table;

        public enum Operation {
            Min,    // range
            Max,    // range
            Gcd,    // range
        }

        Operation operation;
        // All function must be associative f(a,f(b,c)) = f(f(a,b),c)
        // ex a*(b*c) = (a*b)*c
        static int Fmin(int a, int b) => Math.Min(a, b);
        static int Fmax(int a, int b) => Math.Max(a, b);
        static int Fgcd(int a, int b) {
            while (a != 0 && b != 0) {
                if (a > b) a %= b;
                else b %= a;
            }
            return a | b;
        }
        Func<int, int, int> opFunc;

        void BuildTable(int[] array) {
            for (int t = 0; t < array.Length; t++) {
                table[0][t] = array[t];
            }
            for (int r = 1; r < row; r++) {
                int offset = 1 << r - 1;
                for (int c = 0; c + offset < col; c++) {
                    table[r][c] = opFunc(table[r - 1][c], table[r - 1][c + offset]);
                }
            }
        }

        // O(nlogn)
        public SparseTable(int[] array, Operation operation) {
            // allocate memory space
            col = array.Length;
            row = (int)Math.Log2(col) + 1;
            table = new int[row][];
            for (int i = 0; i < row; i++) {
                table[i] = new int[col];
            }
            this.operation = operation;
            switch (operation) {
                case Operation.Min:
                    opFunc = Fmin;
                    break;
                case Operation.Max:
                    opFunc = Fmax;
                    break;
                case Operation.Gcd:
                    opFunc = Fgcd;
                    break;
                default:
                    opFunc = Fmin;
                    break;
            }
            // Construct table
            BuildTable(array);
        }


        public int this[int r, int c] {
            get => table[r][c];
        }
        // find the minimum of interval [L,R] 
        public int Query(int L, int R) {
            int len = R - L + 1;
            int p = (int)Math.Log2(len);  // which level the answer at
            int k = 1 << p;
            int leftInterval = table[p][L];
            int rightInterval = table[p][R - k + 1];
            return opFunc(leftInterval, rightInterval);
        }

        public override string ToString() {
            string result = "";
            for (int i = 0; i < row; i++) {
                result += string.Join(',', table[i]) + "\n";
            }
            return result;
        }
    }


}
