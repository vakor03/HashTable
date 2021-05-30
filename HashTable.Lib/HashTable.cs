using System;

namespace HashTable.Lib
{
    public class HashTable<T>
    {
        private UInt32 _arrayLength;
        private UInt32 _elCount;
        private Node<T>[] _array;

        public HashTable()
        {
            _array = new Node<T>[10];
            _arrayLength = 10;
            _elCount = 0;
        }

        public void AddElement(string key, T value)
        {
            _elCount++;
            UInt32 Id = HashFunction(key);
            while (_array[Id] != null)
            {
                Id = (Id + 1) % _arrayLength;
            }

            _array[Id] = new Node<T>(key, value);
            if ((double) _elCount / _arrayLength >= 0.8)
            {
                Resize();
            }
        }

        public T FindByKey(string key)
        {
            UInt32 id = HashFunction(key);
            while (_array[id] != null && _array[id].Key != key)
            {
                id++;
            }

            if (_array[id] == null)
            {
                return default;
            }

            return _array[id].Value;
        }

        private void Resize()
        {
            Node<T>[] oldArray = _array;
            _array = new Node<T>[_arrayLength * 2];
            _arrayLength *= 2;
            _elCount = 0;
            foreach (Node<T> node in oldArray)
            {
                if (node != null)
                {
                    AddElement(node.Key, node.Value);
                }
            }
        }

        private UInt32 HashFunction(string key)
        {
            UInt32 hash = 0;

            foreach (char c in key)
            {
                hash = (hash << 4) + (byte)c;
                UInt32 test;
                if ((test = hash & 0xf0000000) != 0)
                {
                    hash = (hash ^ (test >> 24)) & 0xfffffff;
                }
            }

            return hash % _arrayLength;
        }
    }
}