namespace DSALGO.DataStructure.HashTable {
    interface IHashTable<TKey, TValue> {
        int Count { get; }
        void Add(TKey key, TValue value);
        TValue Get(TKey key);
        void Remove(TKey key);
        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
        List<TKey> Keys();
        List<TValue> Values();
        void Clear();
    }
}
/*
 - Chaining
- Open Addressing
	- Linear Probing 
		- Probing Function P(x)=ax
		- Capacity N
		- GCD(a,N) =1 => avoiding infinite loop
	- Quadratic Probing
		- Popular Probing Function
			- P(x) = x^2, N = prime num, threshold <0.5
			- P(x) = (x^2+x)/2, N = power of 2
			- P(x) = (-1)^x * x^2, N = 3 mod 4 
	- Double Hashing
		- P(x)=x*H(k)
			1110019294
			
			
			
			1 4
			2637
 
 */