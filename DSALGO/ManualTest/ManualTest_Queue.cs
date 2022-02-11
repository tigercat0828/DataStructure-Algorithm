using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.DataStructures;

namespace DSALGO.ManualTest {
    public static class ManualTest_Queue {

        enum OP {
            Enqueue, Dequeue, Clear, Exit
        }
        public static void ShowInfo() {
            Console.WriteLine($"({(int)OP.Enqueue})" + OP.Enqueue);
            Console.WriteLine($"({(int)OP.Dequeue})" + OP.Dequeue);
            Console.WriteLine($"({(int)OP.Clear})" + OP.Clear);
            Console.WriteLine($"({(int)OP.Exit})" + OP.Exit);
            Console.WriteLine("=====================================");
        }
        public static void Test(Queue queue) {
            ShowInfo();
            OP code = OP.Clear;
            int tmp;
            do {
                Console.WriteLine(queue.ToString());
                Console.Write(">>> ");
                string s = Console.ReadLine();
                code = (OP)int.Parse(s);
                switch (code) {
                    case OP.Enqueue:
                        Console.Write("(Enqueue) Input a number: ");
                        tmp = int.Parse(Console.ReadLine());
                        queue.Enqueue(tmp);
                        break;
                    case OP.Dequeue:
                        Console.WriteLine("(Dequeue)");
                        tmp = queue.Dequeue();
                        Console.WriteLine($"{tmp} exit the queue.");
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
            }while(code != OP.Exit);
        }
    }
}
