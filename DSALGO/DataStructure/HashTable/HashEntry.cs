using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    public class HashEntry<TKey, Tvalue> {
        TKey key;
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
