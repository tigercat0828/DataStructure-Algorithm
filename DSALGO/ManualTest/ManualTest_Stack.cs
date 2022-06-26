
using DSALGO.DataStructures;
namespace DSALGO.ManualTest {
    public static class ManualTest_Stack {
        enum OP {
            Pop, Push, Peek, Clear, Exit
        }
        public static void ShowInfo() {
            Console.WriteLine($"({(int)OP.Pop}) " + OP.Pop);
            Console.WriteLine($"({(int)OP.Push}) " + OP.Push);
            Console.WriteLine($"({(int)OP.Peek}) " + OP.Peek);
            Console.WriteLine($"({(int)OP.Clear}) " + OP.Clear);
            Console.WriteLine($"({(int)OP.Exit}) " + OP.Exit);
            Console.WriteLine("=====================================");
        }
        public static void Test(IStack stack) {
            OP code = OP.Clear;
            int tmp;
            ShowInfo();
            do {
                Console.WriteLine(stack.ToString());
                string s = Console.ReadLine();
                code = (OP)int.Parse(s);
                switch (code) {
                    case OP.Pop:
                        Console.WriteLine("(Pop)");
                        stack.Pop();
                        break;
                    case OP.Push:
                        Console.Write("(Push) Input a number: ");
                        tmp = int.Parse(Console.ReadLine());
                        stack.Push(tmp);
                        break;
                    case OP.Peek:
                        Console.WriteLine($"(Peek) top:{stack.Peek()}");
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
            } while (code != OP.Exit);
        }
    }
}
