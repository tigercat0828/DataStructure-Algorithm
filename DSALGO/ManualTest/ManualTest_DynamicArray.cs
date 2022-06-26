using DSALGO.DataStructures.DynamicArray;

namespace DSALGO.ManualTest {
    public static class ManualTest_DynamicArray {

        enum OP {
            Add, Clear, Exit
        }
        public static void ShowInfo() {
            Console.WriteLine($"({(int)OP.Add}) " + OP.Add);
            Console.WriteLine($"({(int)OP.Clear}) " + OP.Clear);
            Console.WriteLine($"({(int)OP.Exit}) " + OP.Exit);
            Console.WriteLine("===============================================");
        }
        public static void Test(DynamicArray dArray) {
            OP code = OP.Clear;
            int tmp;

            ShowInfo();
            do {
                string s = Console.ReadLine();
                code = (OP)int.Parse(s);
                switch (code) {
                    case OP.Add:
                        Console.Write("(Add) Input a number: ");
                        tmp = int.Parse(Console.ReadLine());
                        dArray.Add(tmp);
                        break;
                    case OP.Clear:
                        Console.Clear();
                        ShowInfo();
                        break;
                    case OP.Exit:
                        return;
                    default:
                        break;
                }
                Console.WriteLine(dArray.ToString() + '\n');
            } while (code != OP.Exit);
        }
    }
}
