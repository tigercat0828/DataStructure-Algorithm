
namespace DSALGO.DataStructures {

    // Implement a stack using array : Astack lmao
    public class AStack : Stack {

        const int INITIAL_CAPCITY = 3;
        int[] stack;
        int capacity;
        private int count;
        
        public override int Count => count;
        public AStack() {
            stack = new int[INITIAL_CAPCITY];
            capacity = INITIAL_CAPCITY;
            count = 0;  
        }
        public override void Push(int data) {
            if (count == capacity) {
                resize();
            }
            stack[count] = data;
            count++;
        }

        private void resize() {
            capacity *= 2;
            int[] newStack = new int[capacity];
            Array.Copy(stack, newStack, stack.Length);
            stack = newStack;
        }

        public override int Pop() {
            if (count >= 1) {
                count--;
                return stack[count];
            }
            Console.WriteLine("Stack is empty");
            return -1;
        }
        public override string ToString() {
            string s = $"[{count}] ";
            for (int i = count - 1; i >= 0; i--) {
                s += stack[i] + " <- ";
            }
            return s;
        }

        public override int Peek() {
            if (count >= 1) { 
                return stack[count-1];
            }
            Console.WriteLine("Stack is empty");
            return -1;
        }
    }
}
