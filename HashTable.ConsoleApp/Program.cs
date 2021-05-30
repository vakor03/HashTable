using System;
using HashTable.Lib;

namespace HashTable.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>();
            hashTable.AddElement("Hello", "1");
            hashTable.AddElement("Hallo","2");

            Console.WriteLine(hashTable.FindByKey("72"));
        }
    }
}