using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.Interfaces;
namespace DSALGO.Test {
    public static class Test_LinkedList {


        enum OP {
            AddFirst, AddLast, RemoveFirst, RemoveLast, SetValue, GetValue,Clear ,Exit
        }

        public static void ShowInfo() {
            Console.WriteLine($"({(int)OP.AddFirst})" + OP.AddFirst);
            Console.WriteLine($"({(int)OP.AddLast})" + OP.AddLast);
            Console.WriteLine($"({(int)OP.RemoveFirst})" + OP.RemoveFirst);
            Console.WriteLine($"({(int)OP.RemoveLast})" + OP.RemoveLast);
            Console.WriteLine($"({(int)OP.SetValue})" + OP.SetValue);
            Console.WriteLine($"({(int)OP.GetValue})" + OP.GetValue);
            Console.WriteLine($"({(int)OP.Clear})" + OP.Clear);
            Console.WriteLine($"({(int)OP.Exit})" + OP.Exit);
            Console.WriteLine("===============================================");
        }
        public static void Test(ILinkedList linkedList) {
            ShowInfo();
            OP code = OP.Clear;
            int tmp;
            string[] tokens;

            do {
                Console.WriteLine('\n' + linkedList.ToString());
                Console.Write(">>> ");
                string s = Console.ReadLine();
                code = (OP)int.Parse(s);
                switch (code) {
                    case OP.AddFirst:
                        Console.Write("Input a number to Addfirst: ");
                        tmp = int.Parse(Console.ReadLine());
                        linkedList.AddFirst(tmp);
                        break;
                    case OP.AddLast:
                        Console.Write("Input a number to AddLast: ");
                        tmp = int.Parse(Console.ReadLine());
                        linkedList.AddLast(tmp);
                        break;
                    case OP.RemoveFirst:
                        linkedList.RemoveFirst();
                        break;
                    case OP.RemoveLast:
                        linkedList.RemoveLast();
                        break;
                    case OP.SetValue:
                        Console.Write("Input index and value :");
                        tokens = Console.ReadLine().Split(' ');
                        int index = int.Parse(tokens[0]);
                        int data = int.Parse(tokens[1]);
                        linkedList[index] = data;
                        break;
                    case OP.GetValue:
                        Console.Write("Input index :");
                        tmp = int.Parse(Console.ReadLine());
                        Console.WriteLine(">>" + linkedList[tmp]);
                        break;
                    case OP.Exit:
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
