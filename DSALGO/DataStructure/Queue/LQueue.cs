namespace DSALGO.DataStructure {
    public class LQueue<T> : IQueue<T> {
        class Node<T> {
            public T data;
            public Node<T> next;
            public Node(T data, Node<T> next) {
                this.data = data;
                this.next = next;
            }
        }
        Node<T> front;
        Node<T> rear;
        private int count;

        public LQueue() {
            count = 0;
        }

        public int Count => count;

        public void Enqueue(T data) {
            if (count == 0) {
                Node<T> node = new Node<T>(data, null);
                front = node;
                rear = node;
                count = 1;
            }
            else {
                Node<T> node = new Node<T>(data, null);
                rear.next = node;
                rear = rear.next;
                count++;
            }
        }
        public T Dequeue() {
            if (count > 0) {
                T pop = front.data;
                front = front.next;
                count--;
                return pop;
            }
            else {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
        }

        public override string ToString() {
            string s = $"[{count}] ";
            Node<T> current = front;
            while (current != null) {
                s += current.data + " > ";
                current = current.next;
            }
            return s;
        }

        public T Peek() {
            return front.data;
        }

        public bool Contains(T item) {
            Node<T> current = front;
            while (current != null) {
                if (current.data.Equals(item)) {
                    return true;
                }
                current = current.next;
            }
            return false;
        }
    }
}
