using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    public class HashTableSeperateChaining<TKey, TValue> : IHashTable<TKey,TValue>{
        const int DEFAULT_SIZE = 32;
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
            get => 
        }
        public void Remove(TKey key) {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key) {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ResizeTable() {
            throw new NotImplementedException();
        }
    }
}
