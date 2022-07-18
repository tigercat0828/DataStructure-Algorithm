using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.HashTable {
    interface IHashTable <TKey, TValue> {
        int Count { get; }
        void Add(TKey key, TValue value);
        TValue Get(TKey key);
        void Remove(TKey key);
        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);

        List<TKey> Keys();
        List<TValue> Values();
        void Clear();
        void ResizeTable();
        
    }
}
