namespace DSALGO.Algorithm.String {
    public class Permutation {
        List<string> result = new List<string>();
        int len;
        public List<string> Permutate(string input) {
            len = input.Length;

            perm(input.ToCharArray(), 0, len);
            return result;
        }
        private void perm(char[] str, int i, int len) {
            if (i == len - 1) {
                result.Add(new string(str));
            }
            else {
                for (int j = i; j < len; j++) {
                    swap(str, i, j);
                    perm(str, i + 1, len);
                    swap(str, i, j);
                }
            }
        }
        private void swap(char[] str, int i, int j) {
            (str[i], str[j]) = (str[j], str[i]);
        }
    }
}
