namespace DSALGO.Algorithm.Numeric {
    public static class GreatestCommonDivisor {
        public static int GCD_iter(int a, int b) {
            while (b != 0) {
                int tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }
        public static int GCD_recur(int a, int b) {
            if (b == 0) return a;
            return GCD_recur(b, a % b);
        }
    }
}
