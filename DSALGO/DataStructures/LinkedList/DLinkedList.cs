using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {

    // Double Linked List
    public class DLinkedList : LinkedList {

        class Node {
            public int data;
            public Node left;
            public Node right;
            public Node(int data, Node left, Node right) {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }
        Node head;
        Node tail;
        public int count;
        public override int Count => count;
        public DLinkedList() {
            count = 0;
        }
        public DLinkedList(DLinkedList dlinklist) { 
            Node current = dlinklist.head;
            while (current != null) { 
                
            }
        }
        public override int this[int index] {
            get => GetValue(index);
            set => SetValue(index, value);
        }

        public override void AddFirst(int data) {
            if (count == 0) {
                Node node = new Node(data, null, null);
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, null, head);
                head.left = node;
                head = node;
            }
            count++;
        }

        public override void AddLast(int data) {
            if (count == 0) {
                Node node = new Node( data, null, null );
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, tail, null);
                tail.right = node;
                tail = node;
            }
            count++;
        }

        public override int IndexOf(int data) {
            Node current = head;
            int index = 0;
            while (current != null) {
                if (current.data == data) {
                    return index;
                }
                current = current.right;
                index++;
            }
            return -1;
        }

        public override void RemoveFirst() {
            if (count == 1) {
                head = null;
                tail = null;
                count = 0;
            }
            else if (count > 1) { 
                head = head.right;
                head.left = null;
                count --;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }

        public override void RemoveLast() {
            if (count == 1) {
                head = null;
                tail = null;
                count =0;
            }
            else if (count > 1) { 
                tail = tail.left;
                tail.right = null;
                count--;
            }
            else {
                Console.WriteLine("Linked list is empty");
            }
        }

        private  void SetValue(int index, int data) {
            if (index >= 0 && index < count) {
                Node node;
                if (index < count / 2) {
                    node = head;
                    for (int i = 0; i < index; i++) {
                        node = node.right;
                    }
                }
                else {
                    node = tail;
                    for (int i = 0; i < index; i++) {
                        node = node.left;
                    }
                }
                node.data = data;
            }
        }
        private int GetValue(int index) {
            if (index >= 0 && index < count) {
                Node node;
                if (index < count / 2) {
                    node = head;
                    for (int i = 0; i < index; i++) {
                        node = node.right;
                    }
                }
                else {
                    node = tail;
                    for (int i = 0; i < index; i++) {
                        node = node.left;
                    }
                }
                return node.data;
            }
            Console.WriteLine("Out of index");
            return 0;
        }
        public override void InsertAt(int index, int data) {
            if (index >= 0 && index < count) {
                if(index == count -1 || count <= 1) {
                    AddLast(data);
                    count++;
                    return;
                }
                Node current;
                if (index < count / 2) {
                    current = head;
                    for (int i = 0; i < index; i++) {
                        current = current.right;
                    }
                }
                else {
                    current = tail;
                    for (int i = 0; i < index; i++) {
                        current = current.left;
                    }
                }
                Node A = current;
                Node B = current.right;
                Node node = new Node(data, A, B);
                A.right = node;
                B.left = node;
            }
            else {
                Console.WriteLine("Out of Index");
            }
        }

        public override void RemoveAt(int index) {
            if (index >= 0 && index < count) {
                if(index == 0) {
                    RemoveFirst();
                }
                else if (index == count - 1) {
                    RemoveLast();
                }
                else {
                    Node current;
                    if (index < count / 2) {
                        current = head;
                        for (int i = 0; i < index; i++) {
                            current = current.right;
                        }
                    }
                    else {
                        current = tail;
                        for (int i = 0; i < index; i++) {
                            current = current.left;
                        }
                    }
                    Node A = current.left;
                    Node B = current.right;
                    A.right =B;
                    B.left = A;
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
