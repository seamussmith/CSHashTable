using System.Linq;

public class HashTable<TKey, TValue>
    where TKey : notnull
{
    const int TABLE_SIZE = 37;
    LinkedList<HashTableEntry>[] table;
    public HashTable()
    {
        table = new Object[TABLE_SIZE].Select(x => new LinkedList<HashTableEntry>()).ToArray();
    }
    int hashFunc(Object o) => Math.Abs(o.GetHashCode()) % table.Length;
    public TValue this[TKey key]
    {
        get
        {
            var hash = hashFunc(key);
            var x = table[hash].Find(new HashTableEntry(key));

            if (x is null)
                throw new KeyNotFoundException($"{key} not in table");
            else
                return x.Value.Value!;
        }
        set
        {
            var hash = hashFunc(key);
            
            var find = table[hash].Find(new HashTableEntry(key));
            if (find is null)
                table[hash].AddFirst(new HashTableEntry(key, value));
            else
                find.ValueRef = new HashTableEntry(key, value);
        }
    }
    class HashTableEntry
    {
        // Make it immutable cause thats what the kool kids do these days lol
        public TKey Key { get; init; }
        public TValue? Value { get; init; }
        public HashTableEntry(TKey key, TValue value)
            => (Key, Value) = (key, value);
        // If you use this constructor for anything else other than LinkedList.Find() I will kill you
        public HashTableEntry(TKey key)
            => Key = key;
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.GetHashCode() == GetHashCode();
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

    }
}