namespace DSALGO.DataStructure {
    // Single Linked List
    public class SinglyLinkedList : LinkedList {
        class Node {
            public int data;
            public Node next;
            public Node(int data, Node next) {
                this.data = data;
                this.next = next;
            }
        }
        Node head;
        Node tail;

        private int count;

        public override int Count => count;

        public SinglyLinkedList() {
            count = 0;
        }
        public SinglyLinkedList(SinglyLinkedList s) {
            Node current = s.head;
            while (current != null) {
                current = current.next;
                AddLast(current.data);
            }
        }
        public override string ToString() {
            string s = $"[{count}]: ";
            Node current = head;
            while (current != null) {
                s += current.data.ToString() + " -> ";
                current = current.next;
            }
            return s;
        }
        public override void AddFirst(int data) {
            if (count == 0) {
                Node node = new Node(data, null);
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, head);
                head = node;
            }
            count++;
        }
        public override void AddLast(int data) {
            if (count == 0) {
                Node node = new Node(data, null);
                head = node;
                tail = node;
            }
            else {
                tail.next = new Node(data, null);
                tail = tail.next;
            }
            count++;
        }
        public override void RemoveFirst() {
            if (count == 1) {
                Console.WriteLine("invoke");
                head = null;
                tail = null;
                count = 0;
            }
            else if (count > 1) {
                head = head.next;
                count--;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }
        public override void RemoveLast() {
            if (count == 1) {
                head = null;
                tail = null;
                count = 0;
            }
            else if (count > 1) {
                Node current = head;
                Node previous = head;
                while (current.next != null) {
                    previous = current;
                    current = current.next;
                }
                tail = previous;
                tail.next = null;
                count--;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }
        public override int IndexOf(int data) {
            int index = 0;
            Node current = head;
            while (current != null) {
                if (current.data == data) {
                    return index;
                }
                current = current.next;
                index++;
            }
            return -1;
        }
        public override int this[int index] {
            get => GetValue(index);
            set => SetValue(index, value);
        }
        private void SetValue(int index, int data) {
            if (index < count || index >= 0) {
                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.next;
                }
                current.data = data;
                return;
            }
            Console.WriteLine("Out of Index");
        }
        private int GetValue(int index) {
            if (index < count || index >= 0) {
                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.next;
                }
                return current.data;
            }
            Console.WriteLine("Out of Index");
            return 0;
        }

        public override void InsertAt(int index, int data) {
            if (index < count || index >= 0) {
                if (index == count - 1 || count <= 1) {
                    AddLast(data);
                    count++;
                    return;
                }
                else {
                    Node current = head.next;
                    Node previous = head;
                    for (int i = 0; i < index; i++) {
                        previous = current;
                        current = current.next;
                    }
                    Node node = new Node(data, current);
                    previous.next = node;
                    count++;
                }
            }
            else {
                Console.WriteLine("Out of Index");
            }
        }

        public override void RemoveAt(int index) {
            if (index < count && index >= 0) {
                if (index == 0) {
                    RemoveFirst();
                }
                else if (index == count - 1) {
                    RemoveLast();
                }
                else {
                    Node current = head.next;
                    Node previous = head;
                    for (int i = 0; i < index - 1; i++) {
                        previous = current;
                        current = current.next;
                    }
                    previous.next = current.next;
                    current = null;
                    count--;
                }
            }
            else {
                Console.WriteLine("Out of Index");
            }
        }

    }
}
