namespace HashTable.Lib
{
    public class Node<T>
    {
        public readonly string Key;
        public readonly T Value;

        public Node(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}