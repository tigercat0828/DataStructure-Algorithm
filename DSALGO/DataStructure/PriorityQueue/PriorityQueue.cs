

namespace DSALGO.DataStructures.PriorityQueue {
    public class PriorityQueue<T> : IQueue<T> where T : IComparable {

        private List<T> heap = new List<T>();   // min heap, binary tree, 0-based
        private int lastIndex => heap.Count - 1;
        public int Size => heap.Count;
        public T Peek() => heap[0];
        public PriorityQueue() {

        }
        public PriorityQueue(IEnumerable<T> list) {
            foreach (var item in list) {
                Enqueue(item);
            }
        }

        public void Enqueue(T item) {
            heap.Add(item);
            SwimUp();
        }
        public T Dequeue() {
            T pop = heap[0];
            heap[0] = heap[lastIndex];
            heap.RemoveAt(Size - 1);
            SinkDown();
            return pop;
        }

        private void SwapByIndex(int index1, int index2) {
            //T item1 = heap[index1];
            //T item2 = heap[index2];
            //T temp = item1;
            //heap[index1] = item2;
            //heap[index2] = temp;
            (heap[index1], heap[index2]) = (heap[index2], heap[index1]);
        }
        private void SwimUp() {
            int i = lastIndex;
            while (i != 0) {
                int parent = (i - 1) / 2;
                if (heap[i].CompareTo(heap[parent]) >= 0) break;
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
                if (left < Size && heap[i].CompareTo(heap[left]) > 0) {
                    smallest = left;
                }
                // right < current
                if (right < Size && heap[i].CompareTo(heap[right]) > 0) {
                    if (heap[right].CompareTo(heap[left]) < 0)
                        smallest = right;
                }

                if (smallest == -1) break;

                SwapByIndex(i, smallest);
                i = smallest;
            }
        }

        public bool Contains(T item) {
            return heap.Contains(item);
        }
        public override string ToString() {
            return string.Join(", ", heap);
        }
    }
}
