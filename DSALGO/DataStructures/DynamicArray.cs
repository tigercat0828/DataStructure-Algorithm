using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructures {
    public class DynamicArray {
        const int INITIAL_CAPACITY = 3;
        public int Count { get; private set; }
        public int[] array;
        private int capacity;
        public DynamicArray() { 
            array = new int[INITIAL_CAPACITY];
            capacity = INITIAL_CAPACITY;
            Count = 0;
        }
        public DynamicArray(int[] array) { 
            this.array = array;
            Count = array.Length;
            capacity = array.Length;
        }
        public DynamicArray(DynamicArray dArray) {
            Count = dArray.Count;
            capacity = dArray.capacity;
            array = new int[capacity];
            dArray.array.CopyTo(array, 0);
        }
        public void Add(int data) {
            if (Count == capacity) {
                Resize();
            }
            array[Count] = data;
            Count++;
        }
        private void Resize() {
            Console.WriteLine("Resize ... ");
            capacity *= 2;
            int[] newArray = new int[capacity];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }
        public override string ToString() {
            string s = $"[{Count}] ";
            for (int i = 0; i < Count; i++) {
                s += array[i] + ", ";
            }
            return s;
        }
    }
}
