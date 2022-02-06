using DSALGO.Interfaces;

namespace DSALGO.DataStructures {

    // Implement a stack using array : Astack lmao
    public class AStack : IStack {

        const int INITIAL_CAPCITY = 3;
        int[] stack;
        int capacity;
        public int Count{get;private set;}

        public AStack() {
            stack = new int[INITIAL_CAPCITY];
            capacity = INITIAL_CAPCITY;
            Count = 0;  
        }
        public void Push(int data) {
            if (Count == capacity) {
                Resize();
            }
            stack[Count] = data;
            Count++;
        }

        private void Resize() {
            capacity *= 2;
            int[] newStack = new int[capacity];
            Array.Copy(stack, newStack, stack.Length);
            stack = newStack;
        }

        public int Pop() {
            if (Count >= 1) {
                Count--;
                return stack[Count];
            }
            Console.WriteLine("Stack is empty");
            return -1;
        }
        public override string ToString() {
            string s = $"[{Count}] ";
            for (int i = Count - 1; i >= 0; i--) {
                s += stack[i] + " <- ";
            }
            return s;
        }

        public int Peek() {
            if (Count >= 1) { 
                return stack[Count-1];
            }
            Console.WriteLine("Stack is empty");
            return -1;
        }
    }
}
