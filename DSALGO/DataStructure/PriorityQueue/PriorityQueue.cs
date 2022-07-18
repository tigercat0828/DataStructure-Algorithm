

namespace DSALGO.DataStructure.PriorityQueue {
    public class PriortyQueue<TKey, TValue> where TValue : IComparable {

        class Element {
            public TKey key;
            public TValue value;
            public Element(TKey key, TValue value) {
                this.key = key;
                this.value = value;
            }
        }

        private List<Element> heap = new List<Element>();   // min heap, binary tree, 0-based, 
        private int tail => heap.Count - 1;
        public int Count => heap.Count;
        public TKey Peek() => heap[0].key;
        public PriortyQueue() {
        }
        public void Enqueue(TKey key, TValue value) {
            heap.Add(new Element(key, value));
            SwimUp();
        }
        public TKey Dequeue() {
            TKey pop = heap[0].key;
            heap[0] = heap[tail];
            heap.RemoveAt(Count - 1);
            SinkDown();
            return pop;
        }

        private void SwapByIndex(int index1, int index2) {

            (heap[index1], heap[index2]) = (heap[index2], heap[index1]);
        }
        private void SwimUp() {
            int i = tail;
            while (i != 0) {
                int parent = (i - 1) / 2;
                if (heap[i].value.CompareTo(heap[parent].value) >= 0) break;
                SwapByIndex(i, parent);
                i = parent;
            }
        }
        private void SinkDown() {
            int i = 0;
            while (true) {

                int left = 2 * i + 1;
                int right = 2 * i + 2;

                int smallest = -1;
                // left < current
                if (left < Count && heap[i].value.CompareTo(heap[left].value) > 0) {
                    smallest = left;
                }
                // right < current
                if (right < Count && heap[i].value.CompareTo(heap[right].value) > 0) {
                    if (heap[right].value.CompareTo(heap[left].value) < 0)
                        smallest = right;
                }

                if (smallest == -1) break;

                SwapByIndex(i, smallest);
                i = smallest;
            }
        }

        public bool Contains(TKey key) {
            foreach (var element in heap) {
                if (key.Equals(element.key)) return true;
            }
            return false;
        }
        public override string ToString() {
            return string.Join(", ", heap);
        }

    }
}
