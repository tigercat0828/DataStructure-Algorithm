namespace DSALGO.DataStructure {
    public class AQueue<T> : IQueue<T> {

        T[] queue;
        int front;
        int rear;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public AQueue(int capcity) {
            this.Capacity = capcity;
            queue = new T[capcity];
            front = 0;
            rear = 0;
            Count = 0;
        }

        public T Dequeue() {
            if (front == rear) {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            T pop = queue[front];
            
            front = (front + 1) % Capacity;
            Count--;
            return pop;
        }

        public void Enqueue(T data) {
            if ((rear + 1) % Capacity == front) {
                Console.WriteLine("Queue is full");
                return;
            }
            queue[rear] = data;
            rear = (rear + 1) % Capacity;
            Count++;
        }

        public override string ToString() {
            string s = $"[{Count}] | ";
            for (int i = 0; i < queue.Length; i++) {
                s += queue[i] + " | ";
            }
            return s;
        }

        public T Peek() {
            return queue[front];
        }

        public bool Contains(T item) {
            int current = front;
            while (true) {
                if (queue[current].Equals(item)) {
                    return true;
                }
                if (current == rear) break;
                current = (current + 1) % Capacity;
            }
            return false;
        }
    }
}
