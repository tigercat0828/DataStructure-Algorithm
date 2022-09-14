namespace DSALGO.DataStructure.HashTable {
    public abstract class HashTableOpenAddressingBase<TKey, TValue> : IHashTable<TKey, TValue> {
        public int Count => throw new NotImplementedException();
        public void Add(TKey key, TValue value) {
            throw new NotImplementedException();
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key) {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value) {
            throw new NotImplementedException();
        }

        public TValue Get(TKey key) {
            throw new NotImplementedException();
        }

        public List<TKey> Keys() {
            throw new NotImplementedException();
        }

        public void Remove(TKey key) {
            throw new NotImplementedException();
        }

        public List<TValue> Values() {
            throw new NotImplementedException();
        }
    }
}
