namespace DSALGO.DataStructure.FenwickTree {
    public class FenwickTree {
        // Binary Indexed Tree
        double[] source;
        double[] tree;   // allow numeric type int, float, double ...
        public FenwickTree(double[] array) {
            tree = array.ToArray();
            source = array.ToArray();
            for (int i = 1; i < array.Length; i++) {
                int j = i + LSB(i);
            }
        }
        public FenwickTree(int size) {
            tree = new double[size];
            source = new double[size];
        }
        public double QuerySum(int i) {
            double sum = 0;
            while (i != 0) {
                sum += tree[i];
                i = i - LSB(i);
            }
            return sum;
        }
        public double QuerySum(int i, int j) {
            return QuerySum(i) - QuerySum(j - 1);
        }
        private int LSB(int index) {
            return index & -index;
        }
        public void Update(int index, double value) {
            double delta = value - source[index];
            int i = index;
            while (i < tree.Length) {
                tree[i] += value;
                i += LSB(i);
            }
        }
    }
}
