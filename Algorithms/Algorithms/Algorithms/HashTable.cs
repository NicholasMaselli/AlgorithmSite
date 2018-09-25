using System;
    
//Where clause ensure the generic values are classes and enables the == operator
public class HashTable<TKey, TValue>
{

    //Potential improvements: Use prime array to allow uniform distribution of keys even after Grow() Shrink() function, 
    //this will also potentially eliminate the problem where you only get 1.6 Billion array slots until overflow
    private int _initialSize = 101;
    private int _scaleFactor = 2;

    //Size Values
    private int _size = 101;
    private int _keyCount = 0;
        
    //Data Arrays
    private TKey[] _keyArray;
    private TValue[] _valueArray;
    private bool[] _occupiedArray;

    public HashTable()
    {
        _keyArray = new TKey[_size];
        _valueArray = new TValue[_size];

        //Use occupied array instead of a null check to handle non-nullable types
        _occupiedArray = new bool[_size];
    }

    public void Add(TKey key, TValue value)
    {

        //Grow HashTable if the array is full
        if (_size == _keyCount) 
        {
            if (_size < (int.MaxValue / 2) + 1)
            {
                Grow();
            }
            else
            {
                throw new Exception("Cannot add key to HashTable. HashTable is full");
            }
        }

        AddPair(key, value);
    }

    //Private helper function to add key, value pairs
    private void AddPair(TKey key, TValue value)
    {
        int hash = Math.Abs(key.GetHashCode()) % _size;
        for (int i = 0; i < _size; i++)
        {
            if (_occupiedArray[hash] == false)
            {
                _keyArray[hash] = key;
                _valueArray[hash] = value;
                _occupiedArray[hash] = true;
                _keyCount++;
                return;
            }
            else if (_occupiedArray[hash] && _keyArray[hash].Equals(key))
            {
                throw new Exception("An Item with the same key has already been added to the HashTable.");
            }

            //Increment the hash value
            hash = (hash + 1) % _size;
        }

        throw new Exception("Error Adding Key, Value to HashTable");
    }
        
    public bool Remove(TKey key)
    {

        //Shrink HashTable if the array is 1/4 full and not below initialSize
        if (_keyCount <= (int)_size / 4 && _size > _initialSize)
        {
            Shrink();
        }

        bool removed = false;
        int hash = Math.Abs(key.GetHashCode()) % _size;
        for (int i = 0; i < _size; i++)
        {
            if (_occupiedArray[hash] && _keyArray[hash].Equals(key))
            {
                _keyArray[hash] = default(TKey);
                _valueArray[hash] = default(TValue);
                _occupiedArray[hash] = false;
                _keyCount--;

                removed = true;
                break;
            }

            //Increment the hash value
            hash = (hash + 1) % _size;
        }

        if (removed)
        {                
            int previousHash;

            //Loop through cluster and fill in the null holes
            for (int i = 0; i < _size; i++)
            {
                //Increment the hash value
                previousHash = hash;
                hash = (hash + 1) % _size;

                /*If the array at this hash value is occupied, determined whether the key is occupying the index because 
                  it's hash code matches the index or if the hash had traversed due to linear probing traversal. 
                  If the code does not match, swap with the new empty hash index*/
                if (_occupiedArray[hash] && hash != Math.Abs(_keyArray[hash].GetHashCode()) % _size) //Must ensure you use absolute value or there will be bugs!
                {
                    _keyArray[previousHash] = _keyArray[hash];
                    _valueArray[previousHash] = _valueArray[hash];
                    _occupiedArray[previousHash] = true;

                    _keyArray[hash] = default(TKey);
                    _valueArray[hash] = default(TValue);
                    _occupiedArray[hash] = false;
                }
                else
                {
                    return removed;
                }
            }
        }

        return removed;
    }  

    public TValue Get(TKey key)
    {
        int hash = Math.Abs(key.GetHashCode()) % _size;
        for (int i = 0; i < _size; i++)
        {
            if (_occupiedArray[hash] && _keyArray[hash].Equals(key))
            {
                return _valueArray[hash];
            }
            else if (_occupiedArray[hash] == false)
            {
                throw new Exception("The given key is not present in the HashTable.");
            }
        }
        throw new Exception("The given key is not present in the HashTable.");
    }

    //Increase the size of the HashTable
    private void Grow()
    {
        int previousSize = _size;
        _size *= _scaleFactor;

        ReHashKeys();
    }
        
    //Decrease the size of the HashTable        
    private void Shrink()
    {
        int previousSize = _size;
        _size = (int)_size / 2;

        ReHashKeys();
    }

    private void ReHashKeys()
    {
        TKey[] oldKeyArray = _keyArray;
        TValue[] oldValueArray = _valueArray;
        bool[] oldOccupiedArray = _occupiedArray;

        //Replace previous data arrays with new arrays of increased size
        _keyArray = new TKey[_size];
        _valueArray = new TValue[_size];
        _occupiedArray = new bool[_size];
        _keyCount = 0;

        //For each element in the old arrays, add the keys, values, and booleans to the new arrays
        for (int i = 0; i < oldKeyArray.Length; i++)
        {
            if (oldOccupiedArray[i])
            {
                AddPair(oldKeyArray[i], oldValueArray[i]);
            }
        }
    }

    public void printHashTable()
    {
        Console.Write("[");
        for (int i = 0; i < _valueArray.Length - 1; i++)
        {
            Console.Write(_valueArray[i] + ", ");
        }
        Console.Write(_valueArray[_valueArray.Length - 1]);
        Console.Write("]");
    }
}

//Testing Class since Main cannot be within a generic class
class HashTableTest
{
    /*
    public static void Main(string[] args)
    {
        HashTable<string, string> hash = new HashTable<string, string>();

        string characters = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                string insert = characters[i].ToString() + characters[j].ToString();
                hash.Add(insert, insert);//(10 * i + j).ToString());
            }
        }

        Console.WriteLine("Get: " + hash.Get("bd"));
        Console.WriteLine("");
        hash.printHashTable();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                string remove = characters[i].ToString() + characters[j].ToString();
                if (hash.Remove(remove) == false)
                {
                    Console.WriteLine("Failed!");
                }
            }
        }

        Console.WriteLine("");
        Console.WriteLine("");
        hash.printHashTable();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Get: " + hash.Get("jc"));

        Console.Read();
    }
    */
}
