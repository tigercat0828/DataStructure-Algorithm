using DSALGO.DataStructure.PriorityQueue;
using Xunit;

namespace DSALGO.Test.PriorityQueue {
    public class IndexPriorityQueueTest {
        [Fact]
        public void Enqueue_And_Dequeue() {
            PriortyQueue<string, int> PQ = new PriortyQueue<string, int>();

            PQ.Enqueue("A", 9);
            PQ.Enqueue("B", 8);
            PQ.Enqueue("C", 7);
            PQ.Enqueue("D", 6);
            PQ.Enqueue("E", 5);


            Assert.Equal(5, PQ.Count);

            Assert.Equal("E", PQ.Dequeue());
            Assert.Equal("D", PQ.Dequeue());
            Assert.Equal("C", PQ.Dequeue());

            PQ.Enqueue("F", 3);

            Assert.Equal(3, PQ.Count);
            Assert.Equal("F", PQ.Peek());

            PQ.Enqueue("G", 2);
            Assert.Equal("G", PQ.Peek());
        }

        [Fact]
        public void Enqueue_And_Dequeue2() {
            IndexedPriorityQueue<char, int> IPQ = new();


            for (int i = 0; i < 26; i++) {
                IPQ.Enqueue((char)('Z' - i), 30 - i);
            }
            for (int i = 0; i < 26; i++) {
                Assert.Equal('A'+i, IPQ.Dequeue());
            }
        }
        [Fact]
        public void EditPriority() {
            IndexedPriorityQueue<string, int> IPQ = new();

            
            IPQ.Enqueue("A", 15);
            IPQ.Enqueue("B", 13);
            IPQ.Enqueue("C", 17);
            IPQ.Enqueue("D", 11);
            IPQ.Enqueue("E", 12);

            
            IPQ.EditPriority("D", 17);
            Assert.Equal("E", IPQ.Peek());

            IPQ.EditPriority("C", 11);
            Assert.Equal("C", IPQ.Peek());
        }
    }
}
