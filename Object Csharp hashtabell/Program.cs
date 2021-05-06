using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Csharp_hashtabell
{
    class Hashdictionary<TKey, TValue> : IDictionary<TKey, TValue> // Class that implements a dictionary with keys and values
    {

        public LinkedList<KeyValuePair<TKey, TValue>>[] Hashlist; // Creates a linked list of keys and values

        private List<TKey> keys = new List<TKey>();
        private List<TValue> values = new List<TValue>();

        public Hashdictionary(int size) //Creates a Linked list on every node in hashlist
        {
            Hashlist = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            this.size = size;
            Initializer();
        }

        public int size;

        public TValue this[TKey key] { get { TValue v; TryGetValue(key, out v); return v; } //
            set
            {
                if (ContainsKey(key))
                {
                    Remove(key);
                    Add(key, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys => keys;

        public ICollection<TValue> Values => values;

        public int Count { get; }

        public bool IsReadOnly { get { return false; } }

        public void Add(TKey key, TValue value)  // Forward keys and values to next Add Method
        {

                Add(new KeyValuePair<TKey, TValue>(key, value));
            
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException();
            }
            else if (Contains(item))
            {
                throw new ArgumentException();
            }
            else
            {
                var hashkey = Hashfunction(item.Key);

                Hashlist[hashkey].AddLast(item);

                keys.Add(item.Key);
                values.Add(item.Value);
                return;
                
            }
        }

        public void Clear()
        {

            foreach(var array in Hashlist)
            {

                array.Clear();

            }
            keys.Clear();
            values.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)// Forwards to next Contains method
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(TKey key)
        {
            var hashkey = Hashfunction(key);

            if (Hashlist[hashkey] == null)
            {
                return false;
            }
            foreach (var array in Hashlist[hashkey])
            {
                if (array.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) // Copy the entire Hashtable to an array
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0 || arrayIndex> array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            else
            {
                foreach (var item in this)
                {
                    array[arrayIndex] = item;

                    arrayIndex++;
                        /*foreach (var location in HashIndex)
                        {
                            array[arrayIndex] = location;
                            arrayIndex++;
                        }*/
                    
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            return new hashenumerable(Hashlist);

        }

        public bool Remove(TKey key)
        {
            var hashkey = Hashfunction(key);

            if (Hashlist[hashkey] == null)
            {
                return false;
            }
            foreach (var array in Hashlist[hashkey])
            {
                if (array.Key.Equals(key))
                {
                    Hashlist[hashkey].Remove(array);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);   
        }

        public bool TryGetValue(TKey key, out TValue value) // Finds the value that were searching for
        {
            var hashkey = Hashfunction(key);
            if(Hashlist[hashkey]== null)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                foreach(var item in Hashlist[hashkey])
                {
                    if (item.Key.Equals(key))
                    {
                        value = item.Value;
                        return true;
                    }
                      
                }
            }

            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Hashfunction(TKey key)
        {
            var Hashkey = Math.Abs(key.GetHashCode()) % size;


            return Hashkey;
        }
        class hashenumerable : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            public KeyValuePair<TKey, TValue> Current => node.Value;

            object IEnumerator.Current => Current;

            int i = -1;

            LinkedListNode<KeyValuePair<TKey, TValue>> node;
            LinkedList<KeyValuePair<TKey, TValue>>[] keyValuePairs;

            public hashenumerable(LinkedList<KeyValuePair<TKey, TValue>>[] e)
            {
                keyValuePairs = e;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (i < keyValuePairs.Count() - 1) {
                    if (node?.Next != null)
                    {
                        node = node.Next;
                    } else
                    {
                        i++;
                        node = keyValuePairs[i].First;
                    }
                    return true;
                } else
                {
                    return false;
                }

            }

            public void Reset()
            {
                i = -1;
            }
        }
        public void Initializer()
        {

            for (int i=0; i < size; i++)
            {

                if (Hashlist[i] == null)
                {

                    Hashlist[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    
                }

            }
        } // Initialize all idexes to 0
    }  
}
