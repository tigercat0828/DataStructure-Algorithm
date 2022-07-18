using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    public class HashEntry<TKey, Tvalue> {
        TKey key;
        Tvalue value;
        public int hashCode { get; private set; }
        public HashEntry(TKey key, Tvalue value) {
            this.key = key;
            this.value = value;
            this.hashCode = key.GetHashCode();
        }
        public bool Equals(HashEntry<TKey, Tvalue> other) {
            if(this.hashCode != other.hashCode) return false;
            return other.key.Equals(this.key);
        }
        public override string ToString() {
            return $"({key}, {value})";
        }
    }
}
