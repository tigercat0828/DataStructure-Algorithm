using DSALGO.DataStructures;

namespace DSALGO.ManualTest {
    public static class ManualTest_LinkedList {

        enum OP {
            AddFirst, AddLast, RemoveFirst, RemoveLast, InsertAt, RemoveAt, IndexOf, SetValue, GetValue, Clear, Exit
        }

        private static void ShowInfo() {
            Console.WriteLine($"({(int)OP.AddFirst})" + OP.AddFirst);
            Console.WriteLine($"({(int)OP.AddLast})" + OP.AddLast);
            Console.WriteLine($"({(int)OP.RemoveFirst})" + OP.RemoveFirst);
            Console.WriteLine($"({(int)OP.RemoveLast})" + OP.RemoveLast);
            Console.WriteLine($"({(int)OP.InsertAt})" + OP.InsertAt);
            Console.WriteLine($"({(int)OP.RemoveAt})" + OP.RemoveAt);
            Console.WriteLine($"({(int)OP.IndexOf})" + OP.IndexOf);
            Console.WriteLine($"({(int)OP.SetValue})" + OP.SetValue);
            Console.WriteLine($"({(int)OP.GetValue})" + OP.GetValue);
            Console.WriteLine($"({(int)OP.Clear})" + OP.Clear);
            Console.WriteLine($"({(int)OP.Exit})" + OP.Exit);
            Console.WriteLine("===============================================");
        }
        public static void Test(LinkedList linkedList) {
            ShowInfo();
            OP code = OP.Clear;
            int tmp, index;
            string[] tokens;

            do {
                Console.WriteLine('\n' + linkedList.ToString());
                Console.Write(">>> ");
                string s = Console.ReadLine();
                code = (OP)int.Parse(s);
                switch (code) {
                    case OP.AddFirst:
                        Console.Write("(Addfirst) Input a number: ");
                        tmp = int.Parse(Console.ReadLine());
                        linkedList.AddFirst(tmp);
                        break;
                    case OP.AddLast:
                        Console.Write("(AddLast) Input a number: ");
                        tmp = int.Parse(Console.ReadLine());
                        linkedList.AddLast(tmp);
                        break;
                    case OP.RemoveFirst:
                        Console.WriteLine("(RemoveFirst)");
                        linkedList.RemoveFirst();
                        break;
                    case OP.RemoveLast:
                        Console.WriteLine("(RemoveLast)");
                        linkedList.RemoveLast();
                        break;
                    case OP.InsertAt:
                        Console.Write("(InaserAt) Input index and value: ");
                        tokens = Console.ReadLine().Split(' ');
                        index = int.Parse(tokens[0]);
                        tmp = int.Parse(tokens[1]);
                        linkedList.InsertAt(index, tmp);
                        break;
                    case OP.RemoveAt:
                        Console.Write("(RemoveAt) Input a index: ");
                        index = int.Parse(Console.ReadLine());
                        linkedList.RemoveAt(index);
                        break;
                    case OP.IndexOf:
                        Console.Write("(IndexOf) Input a number to locate: ");
                        tmp = int.Parse(Console.ReadLine());
                        Console.WriteLine(linkedList.IndexOf(tmp));
                        break;

                    case OP.SetValue:
                        Console.Write("(SetValue) Input index and value: ");
                        tokens = Console.ReadLine().Split(' ');
                        index = int.Parse(tokens[0]);
                        tmp = int.Parse(tokens[1]);
                        linkedList[index] = tmp;
                        break;
                    case OP.GetValue:
                        Console.Write("(GetValue) Input index :");
                        tmp = int.Parse(Console.ReadLine());
                        Console.WriteLine(">>" + linkedList[tmp]);
                        break;
                    case OP.Exit:
                        Console.WriteLine("Exit ... ");
                        return;
                    case OP.Clear:
                        Console.Clear();
                        ShowInfo();
                        break;
                    default:
                        break;
                }
            } while (code != OP.Exit);
        }
    }
}
