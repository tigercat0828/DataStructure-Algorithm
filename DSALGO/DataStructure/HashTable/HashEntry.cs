namespace DSALGO.DataStructure.HashTable {
    public class HashEntry<TKey, Tvalue> {
        public TKey key { get; private set; }
        public Tvalue value { get; set; }
        public int hashCode { get; private set; }
        public HashEntry(TKey key, Tvalue value) {
            this.key = key;
            this.value = value;
            this.hashCode = key.GetHashCode();
        }
        public bool IsKeyIdentical(TKey key) {
            return this.key.Equals(key);
        }
        public override string ToString() {
            return $"({key}, {value})";
        }
    }
}
