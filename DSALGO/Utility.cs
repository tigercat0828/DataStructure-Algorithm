namespace DSALGO {
    public static class Utility {

        public static void Print<T>(this IEnumerable<T> list) {
            Console.WriteLine(string.Join(',', list));
        }
        public static int[] RandomIntArray(int length, int min, int max) {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++) {
                array[i] = random.Next(min, max + 1);
            }
            return array;
        }
        public static void DrawThinLine() {
            Console.WriteLine("----------------------------------------------");
        }
        public static void DrawBoldLine() {
            Console.WriteLine("==============================================");
        }
    }
}
