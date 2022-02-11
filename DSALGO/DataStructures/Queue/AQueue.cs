using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public class AQueue : Queue {

        const int QUEUE_SIZE = 5;
        int[] queue;
        int front;
        int rear;
        private int count;
        

        public AQueue() {
            queue = new int[QUEUE_SIZE];
            front = 0;
            rear = 0;
            count = 0;
        }

        public override int Count => count;

        public override int Dequeue() {
            if(front == rear) {
                Console.WriteLine("Queue is empty");
                return -1;
            }
            int pop = queue[front];
            queue[front] = 0;
            front = (front + 1) % QUEUE_SIZE;
            count--;
            return pop;
        }

        public override void Enqueue(int data) {
            if ((rear + 1) % QUEUE_SIZE == front) {
                Console.WriteLine("Queue is full");
                return;
            }
            queue[rear] = data;
            rear = (rear + 1) % QUEUE_SIZE;
            count++;
        }

        public override string ToString() {
            string s= $"[{count}] | ";
            for (int i = 0; i < queue.Length; i++) {
                s += queue[i] + " | ";
            }
            return s;
        }
    }
}
