using System.IO;
namespace DSALGO {
    public static class Utility {

        public static void Print<T>(this IEnumerable<T> list) {
            Console.WriteLine(string.Join(',', list));
        }
        //public static string GetResourceFolder => getResourceDir();

        public static string GetResourceFolder => getResourceDir();
        private static string getResourceDir() {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(runningPath, @"..\..\..\"));
            return Path.Combine(projectPath, "Resource");
        }
        
        public static string GetResourceFile(string filename) {
            return Path.Combine(GetResourceFolder, filename);
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
