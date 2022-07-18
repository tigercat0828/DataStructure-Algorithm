namespace DSALGO.DataStructure.PriorityQueue {
    public class IndexedPriorityQueue<TKey, TValue> where TValue : IComparable {
        class Element {
            public TKey key;
            public TValue value;
            public Element(TKey key, TValue value) {
                this.key = key;
                this.value = value;
            }
        }
        Dictionary<TKey, int> NameMapCode;    // A -> 1
        Dictionary<int, TKey> CodeMapName;   // 1 -> A
        List<TValue> values;
        List<TValue> heap;
        List<int> KeyCodeToHeapIdx;   // key在heap中的index   key -> index
        List<int> HeapIdxToKeyCode;   // heap[t]中的key       index -> key
        int serial = 0;
        public int Count => heap.Count;
        private int tail => heap.Count - 1;

        public IndexedPriorityQueue() {
            NameMapCode = new ();
            CodeMapName = new();
            values = new ();
            heap = new();
            KeyCodeToHeapIdx = new();
            HeapIdxToKeyCode = new();
        }
        public void Enqueue(TKey key, TValue value) {
            if (NameMapCode.ContainsKey(key)) {
                EditPriority(key, value);
            }
            else {
                NameMapCode.Add(key, serial);
                CodeMapName.Add(serial, key);
                serial++;
                values.Add(value);
                heap.Add(value);
                // update table
                KeyCodeToHeapIdx.Add(0);
                HeapIdxToKeyCode.Add(0);
                KeyCodeToHeapIdx[NameMapCode[key]] = tail;
                HeapIdxToKeyCode[tail] = NameMapCode[key];
                SwimUp(tail);
            }
        }

        public void EditPriority(TKey key, TValue value) {
            if (NameMapCode.ContainsKey(key)) {
                int ID = NameMapCode[key];
                
                values[ID] = value;
                int heapIdx = KeyCodeToHeapIdx[ID];
                
                int cmp = value.CompareTo(heap[heapIdx]);
                heap[heapIdx] = value;
                if(cmp > 0) {
                    SinkDown(heapIdx);
                }
                else {
                    SwimUp(heapIdx);
                }                
            }
            else {
                Enqueue(key, value);
            }
        }
        public TKey Dequeue() {
            int popCode = HeapIdxToKeyCode[0];
            TKey popKey = CodeMapName[popCode];

            Swap(0, tail);

            
            HeapIdxToKeyCode[tail] = -1;
            KeyCodeToHeapIdx[popCode] = -1; // pop not in the heap;
            values[popCode] = default(TValue);
            heap.RemoveAt(tail);

            SinkDown(0);

            return popKey;            
        }
      public TKey Peek() {
            int keyCode = HeapIdxToKeyCode[0];
            return CodeMapName[keyCode];
        }
        private void SwimUp(int index) {
            while (index != 0) {
                int parent = (index - 1) / 2;
                int cmp = heap[index].CompareTo(heap[parent]);
                if (cmp > 0) break;
                Swap(parent, index);
                index = parent;
            }
        }
        private void SinkDown(int index) {
            
            while (true) {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = -1;
                // current > left;
                if(left < Count && heap[index].CompareTo(heap[left]) > 0) {
                    smallest = left;
                }
                if (right < Count && heap[index].CompareTo(heap[right]) > 0) {
                    if (heap[right].CompareTo(heap[left]) < 0) {
                        smallest = right;
                    }
                }
                if (smallest == -1) break;
                Swap(index, smallest);
                index = smallest;
            }
        }
        private void Swap(int i, int j) {
            (heap[i], heap[j]) = (heap[j], heap[i]);
            int KeyI = HeapIdxToKeyCode[i];
            int KeyJ = HeapIdxToKeyCode[j];
            (HeapIdxToKeyCode[i], HeapIdxToKeyCode[j]) = (HeapIdxToKeyCode[j], HeapIdxToKeyCode[i]);
            (KeyCodeToHeapIdx[KeyI], KeyCodeToHeapIdx[KeyJ]) = (KeyCodeToHeapIdx[KeyJ], KeyCodeToHeapIdx[KeyI]);
        }
        
        public void Show() {
            for (int i = 0; i < heap.Count; i++) {
                int keyCode = HeapIdxToKeyCode[i];
                string keyName = CodeMapName[keyCode].ToString();
                Console.WriteLine(keyName + ", " + heap[i]);
            }
        }
        public void ShowTable() {
            Console.Write("    key | ");
            for (int i = 0; i < heap.Count; i++) {
                Console.Write(CodeMapName[i] + " ");
            }
            Console.WriteLine();
            Console.Write("  value | ");
            values.Print();
            Console.Write("heapPos | ");
            KeyCodeToHeapIdx.Print();
            Console.Write("heap[i] | ");
            foreach (var code in HeapIdxToKeyCode) {
                Console.Write(CodeMapName[code] + " ");
            }
            Console.WriteLine();
        }

    }
}
