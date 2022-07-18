using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    public class HashTableSeperateChaining<TKey, TValue> : IHashTable<TKey,TValue>{
        const int DEFAULT_SIZE = 10;
        const float LOAD_FACTOR = 0.75f;
        public int Count { get; private set; }
        private int capacity;
        private float threshold => (float)Count / (float)capacity;
        private List<HashEntry<TKey, TValue>>[] bucket;
        public HashTableSeperateChaining() {
            Count = 0;
            capacity = DEFAULT_SIZE;
            bucket = new List<HashEntry<TKey, TValue>>[DEFAULT_SIZE];
        }
        private int NormalizeIndex(int hashCode) {
            return hashCode & 0x7FFFFFFF % capacity;
        }
        public void Add(TKey key, TValue value) {
            if (ContainsKey(key)) 
                throw new ArgumentException($"Already has {key} key in hashtable.");
            
            HashEntry<TKey, TValue> entry = new(key, value);
            int index = NormalizeIndex(entry.hashCode);
            if(bucket[index] == null) {
                bucket[index] = new List<HashEntry<TKey, TValue>>();
            }
            bucket[index].Add(entry);
            Count++;
            if (threshold > LOAD_FACTOR) ResizeTable();
        }
        public TValue this[TKey key] {
            get => Get(key);
            set => Set(key, value);
        }
        public void Set(TKey key, TValue value) {
            if (!HasKey(key, out int index)) throw new ArgumentException($"There is no {key} in the HashTable");
            var row = bucket[index];
            HashEntry<TKey, TValue> target;
            foreach (var item in row) {
                if (item.IsKeyIdentical(key)) {
                    item.value = value;
                    break;
                }
            }
        }
        public TValue Get(TKey key) {

            if (!HasKey(key, out int index)) throw new ArgumentException($"There is no {key} in the HashTable");

            var row = bucket[index];
            foreach (var item in row) {
                if (item.IsKeyIdentical(key)) {
                    return item.value;
                }
            }
            return default(TValue);
        }
        public void Remove(TKey key) {
            throw new NotImplementedException();
        }
        
        public bool ContainsKey(TKey key) {
            return HasKey(key, out int index);
        }
        private bool HasKey(TKey key, out int index) {
            // calculate hashcode of key and output normalized index
            index = NormalizeIndex(key.GetHashCode());
            if (bucket[index] == null) {
                index = -1;
                return false;
            }
            return true;
        }

        public bool ContainsValue(TValue value) {
            throw new NotImplementedException();
        }

        public List<TKey> Keys() {
            throw new NotImplementedException();
        }

        public List<TValue> Values() {
            throw new NotImplementedException();
        }

        public void Clear() {
            Count = 0;
            throw new NotImplementedException();

        }

        public void ResizeTable() {
            throw new NotImplementedException();
        }
        public void Print() { 
            for (int i = 0; i < capacity; i++) {
                Console.Write($"{i} : ");
                if (bucket[i] == null) {
                    Console.WriteLine();
                    continue;
                }
                foreach (var pair in bucket[i]) {
                    Console.Write(pair + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}
