using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    public class HashTableSeperateChaining<TKey, TValue> : IHashTable<TKey,TValue> , IEnumerable{
        const int DEFAULT_SIZE = 10;
        const float LOAD_FACTOR = 0.75f;
        public int Count { get; private set; }
        private int capacity;
        private float threshold => (float)Count / (float)capacity;
        private List<HashEntry<TKey, TValue>>[] _Bucket;
        public HashTableSeperateChaining() {
            Count = 0;
            capacity = DEFAULT_SIZE;
            _Bucket = new List<HashEntry<TKey, TValue>>[DEFAULT_SIZE];
        }
        private int NormalizeIndex(int hashCode) {
            return (hashCode & 0x7FFFFFFF) % capacity;
        }
        public void Add(TKey key, TValue value) {
            if (HasKey(key, out int index)) 
                throw new ArgumentException($"Already has {key} key in hashtable.");
            
            HashEntry<TKey, TValue> entry = new(key, value);
            
            if(_Bucket[index] == null) {
                _Bucket[index] = new List<HashEntry<TKey, TValue>>();
            }
            _Bucket[index].Add(entry);
            Count++;
            if (threshold > LOAD_FACTOR) ResizeTable();
        }
        public TValue this[TKey key] {
            get => Get(key);
            set => Set(key, value);
        }
        public void Set(TKey key, TValue value) {
            if (!HasKey(key, out int index)) throw new ArgumentException($"There is no {key} in the HashTable");
            var row = _Bucket[index];
            HashEntry<TKey, TValue> target;
            foreach (var item in row) {
                if (item.IsKeyIdentical(key)) {
                    item.value = value;
                    break;
                }
            }
        }
        public TValue Get(TKey key) {

            if (!HasKey(key, out int index)) throw new ArgumentException($"There is no Key: {key} in hashtable");

            var row = _Bucket[index];
            foreach (var item in row) {
                if (item.IsKeyIdentical(key)) {
                    return item.value;
                }
            }
            return default;
        }
        public void Remove(TKey key) {
            if (!HasKey(key, out int index)) throw new ArgumentException($"There is no Key: {key} in hashtable");
           
            Console.WriteLine(index);
            if (_Bucket[index] != null) {
                var bucket =  _Bucket[index];
                foreach (var entry in bucket) {
                    if (entry.IsKeyIdentical(key)) {
                        bucket.Remove(entry);
                        return;
                    }
                }
            }
        }
        public bool ContainsKey(TKey key) {
            return HasKey(key, out _);
        }
        private bool HasKey(TKey key, out int index) {
            // calculate hashcode of key and output normalized index
            index = NormalizeIndex(key.GetHashCode());
            if (_Bucket[index] == null) {
                return false;
            }
            return true;
        }
        public bool ContainsValue(TValue value) {
            throw new NotImplementedException();
        }
        public List<TKey> Keys() {
            List<TKey> keys = new();
            for (int i = 0; i < _Bucket.Length; i++) {
                var bucket = _Bucket[i];
                if (bucket != null) {
                    foreach (var entry in bucket) keys.Add(entry.key);
                }
            }
            return keys;
        }
        public List<TValue> Values() {
            List<TValue> vals = new();
            for (int i = 0; i < _Bucket.Length; i++) {
                var bucket = _Bucket[i];
                if (bucket != null) {
                    foreach (var entry in bucket) vals.Add(entry.value);
                }
            }
            return vals;
        }
        public void Clear() {
            Count = 0;
            for (int i = 0; i < _Bucket.Length; i++) {
                var bucket = _Bucket[i];
                if (bucket != null) bucket.Clear();
            }
            _Bucket = new List<HashEntry<TKey, TValue>>[DEFAULT_SIZE];
        }
        private void ResizeTable() {
            capacity *= 2;
            var newBucket = new List<HashEntry<TKey, TValue>>[capacity];
            for (int i = 0; i < _Bucket.Length; i++) {
                var bucket = _Bucket[i];
                if (bucket != null) {
                    foreach (var entry in bucket) {
                        int index = NormalizeIndex(entry.hashCode);
                        if (newBucket[index] == null) {
                            newBucket[index] = new List<HashEntry<TKey, TValue>>();
                        }
                        newBucket[index].Add(entry);
                    }
                }
            }
        }
        public void Print() { 
            for (int i = 0; i < capacity; i++) {
                Console.Write($"{i} : ");
                if (_Bucket[i] == null) {
                    Console.WriteLine();
                    continue;
                }
                foreach (var pair in _Bucket[i]) {
                    Console.Write(pair + ", ");
                }
                Console.WriteLine();
            }
        }
        public IEnumerator GetEnumerator() {
            for (int i = 0; i < _Bucket.Length; i++) {
                var bucket = _Bucket[i];
                if(bucket != null) {
                    foreach (var entry in bucket) {
                        yield return entry;
                    }
                }
            }
        }
    }
}
