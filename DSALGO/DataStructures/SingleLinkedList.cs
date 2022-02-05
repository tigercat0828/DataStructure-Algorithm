using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.Interfaces;
namespace DSALGO.DataStructures {
    public class SingleLinkedList : ILinkedList {
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
        public int Count { get; private set; }
        public SingleLinkedList() {
            Count = 0;
        }
    
        public override string ToString() {
            string s = $"[{Count}]: ";
            Node current = head;
            while (current != null) {
                s += current.data.ToString() + " -> ";
                current = current.next;
            }
            return s;
        }
        public void AddFirst(int data) {
            if (Count==0) {
                Node node = new Node(data, null);
                head = node;
                tail = node;
            }
            else {
                Node node = new Node(data, head);
                head = node;
            }
            Count++;
        }
        public void AddLast(int data) {
            if (Count == 0) {
                Node node = new Node(data, null);
                head = node;
                tail = node;
            }
            else {
                tail.next = new Node(data, null);
                tail = tail.next;
            }
            Count++;
        }
        public void RemoveFirst() {
            if (Count == 1) {
                Console.WriteLine("invoke");
                head = null;
                tail = null;
                Count = 0;
            }
            else if (Count > 0) {
                head = head.next;
                Count--;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }
        public void RemoveLast() {
            if (Count == 1) {
                Console.WriteLine("invoke");
                head = null;
                tail = null;
                Count = 0;
            }
            else if (Count > 0) {
                Node current = head;
                Node previous = head;
                while (current.next != null) {
                    previous = current;
                    current = current.next;
                }
                tail = previous;
                tail.next = null;
                Count--;
            }
            else {
                Console.WriteLine("Linked list is empty!");
            }
        }
        public int IndexOf(int data) {
            int i = -1;
            Node current = head;
            while (current != null) {
                i++;
                if (current.data == data) {
                    return i;
                }
                current = current.next;
            }
            return -1;
        }
        public int this[int index] {
            get => GetValue(index);
            set => SetValue(index, value);
        }
        private void SetValue(int index, int data) {
            if (index < Count) {
                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.next;
                }
                current.data = data;
                return;
            }
            Console.WriteLine("Out of index");
        }
        private int GetValue(int index) {
            if (index < Count) {
                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.next;
                }
                return current.data;
            }
            Console.WriteLine("Out of index");
            return 0;
        }
    }
}
