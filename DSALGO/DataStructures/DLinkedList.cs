using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.Interfaces;
namespace DSALGO.DataStructures {

    // Double Linked List
    public class DLinkedList : ILinkedList {

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
        public int Count { get; private set; }

        public DLinkedList() {
            Count = 0;
        }

        public int this[int index] {
            get => GetValue(index);
            set => SetValue(index, value);
        }
      
        public void AddFirst(int data) {
            if (Count == 0) {
                Node node = new Node(data, null, null);
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, null, head);
                head.left = node;
                head = node;
            }
            Count++;
        }

        public void AddLast(int data) {
            if (Count == 0) {
                Node node = new Node( data, null, null );
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, tail, null);
                tail.right = node;
                tail = node;
            }
            Count++;
        }

        public int IndexOf(int data) {
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

        public void RemoveFirst() {
            if (Count == 1) {
                head = null;
                tail = null;
                Count = 0;
            }
            else if (Count > 1) { 
                head = head.right;
                head.left = null;
                Count --;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }

        public void RemoveLast() {
            if (Count == 1) {
                head = null;
                tail = null;
                Count =0;
            }
            else if (Count > 1) { 
                tail = tail.left;
                tail.right = null;
                Count--;
            }
            else {
                Console.WriteLine("Linked list is empty");
            }
        }

        private void SetValue(int index, int data) {
            if (index >= 0 && index < Count) {
                Node node;
                if (index < Count / 2) {
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
            if (index >= 0 && index < Count) {
                Node node;
                if (index < Count / 2) {
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
        public void InsertAt(int index, int data) {
            if (index >= 0 && index < Count) {
                if(index == Count -1 || Count <= 1) {
                    AddLast(data);
                    Count++;
                    return;
                }
                Node current;
                if (index < Count / 2) {
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

        public void RemoveAt(int index) {
            if (index >= 0 && index < Count) {
                if(index == 0) {
                    RemoveFirst();
                }
                else if (index == Count - 1) {
                    RemoveLast();
                }
                else {
                    Node current;
                    if (index < Count / 2) {
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
                    Count--;
                }
            }
            else {
                Console.WriteLine("Out of Index");
            }
        }
    }
}
