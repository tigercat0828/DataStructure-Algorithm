using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public class LQueue : Queue {
        class Node {
            public int data;
            public Node next;
            public Node(int data, Node next) { 
                this.data = data;
                this.next = next;
            }
        }
        Node front;
        Node rear;
        private int count;

        public LQueue() {
            count = 0;
        }
        
        public override int Count => count;

        public override void Enqueue(int data) {
            if (count == 0) {
                Node node = new Node(data, null);
                front = node;
                rear = node;
                count = 1;
            }
            else {
                Node node = new Node(data, null);
                rear.next = node;
                rear = rear.next;
                count++;
            }
        }

        public override int Dequeue() {
            if(count > 0) {
                int pop = front.data;
                front = front.next;
                count--;
                return pop;
            }
            else {
                Console.WriteLine("Queue is empty");
                return -1;
            }
        }

        public override string ToString() {
            string s = $"[{count}] ";
            Node current = front;
            while (current != null) {
                s += current.data + " > ";
                current = current.next;
            }
            return s;
        }
    }
}
