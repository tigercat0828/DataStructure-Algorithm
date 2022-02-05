using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.Interfaces;
namespace DSALGO.DataStructures {
    public class DoubleLinkedList : ILinkedList {

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

        public DoubleLinkedList() {
            Count = 0;
        }

        public int this[int index] { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
      
        public void AddFirst(int data) {
            if (Count == 0) {
                Node node = new Node(data, null);
                head = node;
                tail = node;
            }
            else {

            }
        }

        public void AddLast(int data) {
            throw new NotImplementedException();
        }

        public int IndexOf(int data) {
            throw new NotImplementedException();
        }

        public void RemoveFirst() {
            throw new NotImplementedException();
        }

        public void RemoveLast() {
            throw new NotImplementedException();
        }

        private void SetValue(int index, int data) {

        }
        private void GetValue(int index) { 
        
        }
    }
}
