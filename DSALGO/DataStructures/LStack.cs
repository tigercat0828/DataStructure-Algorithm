using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.Interfaces;
namespace DSALGO.DataStructures {
    public class LStack : IStack {

        class Node {
            public int data;
            public Node next;
            public Node(int data, Node next) {
                this.data = data;
                this.next = next;
            }
        }
        public int Count { get; private set; }
        Node top;
        public LStack() {
            Count = 0;
        }
        public int Pop() {
            if (Count == 0) {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            int pop = top.data;
            top = top.next;
            Count--;
            return pop;
        }

        public void Push(int data) {
            if (top == null) {
                top = new Node(data, null);
                Count = 1;
                return;
            }
            Node node = new Node(data, top);
            top = node;
            Count++;
        }

        public int Peek() {
            if(top != null) {
                return top.data;
            }
            return -1;
        }
        public override string ToString() {
            string s = $"[{Count}] ";
            Node current = top;
            while (current != null) {
                s += current.data + " -> ";
                current = current.next;
            }
            return s;
        }
    }
}
