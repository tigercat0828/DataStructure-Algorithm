namespace DSALGO.DataStructure.FenwickTree; 
public class FenwickTree {
    private readonly double[] tree;
    private readonly double[] source;

    public FenwickTree(int size) {
        tree = new double[size + 1];   // 1-based index
        source = new double[size + 1];
    }
    public FenwickTree(double[] array) {
        int n = array.Length;
        tree = new double[n + 1];
        source = new double[n + 1];
        for (int i = 0; i < n; i++) {
            Update(i + 1, array[i]); // shift +1 for 1-based
        }
    }

    private int LSB(int index) => index & -index;

    public void Update(int index, double value) {
        double delta = value - source[index];
        source[index] = value;
        while (index < tree.Length) {
            tree[index] += delta;
            index += LSB(index);
        }
    }

    public double QuerySum(int index) {
        double sum = 0;
        while (index > 0) {
            sum += tree[index];
            index -= LSB(index);
        }
        return sum;
    }

    public double QuerySum(int l, int r) {
        if (l > r) (l, r) = (r, l); // swap
        return QuerySum(r) - QuerySum(l - 1);
    }
}
