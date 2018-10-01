/*
using System;
using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool wordEnd = false;

    public TrieNode()
    {

    }
}

public class TrieTree
{
    public TrieNode root;

    public TrieTree()
    {
        root = new TrieNode();
    }

    public void Insert(string key)
    {
        TrieNode node = root;
        int length = key.Length;

        for (int level = 0; level < length; level++)
        {
            if (!node.children.ContainsKey(key[level]))
            {
                TrieNode newNode = new TrieNode();
                node.children.Add(key[level], newNode);
                node = newNode;
            }
            else
            {
                node = node.children[key[level]];
            }
        }
        node.wordEnd = true;
    }

    public bool Search(string key)
    {
        TrieNode node = root;
        int length = key.Length;
        
        for (int level = 0; level < length; level++)
        {
            if (node.children.ContainsKey(key[level]))
            {
                node = node.children[key[level]];
            }
            else
            {
                return false;
            }
        }

        return node.wordEnd;
    }

    public static void Main(string[] args)
    {
        TrieTree tree = new TrieTree();
        tree.Insert("test");
        tree.Insert("testing");
        tree.Insert("algo");
        tree.Insert("a");
        tree.Insert("algorithm");
        tree.Insert("trie");        
        
        Console.WriteLine("Should be True, result: " + tree.Search("test"));
        Console.WriteLine("Should be False, result: " + tree.Search("testi"));
        Console.WriteLine("Should be True, result: " + tree.Search("a"));
        Console.WriteLine("Should be False, result: " + tree.Search("tri"));
        Console.WriteLine("Should be False, result: " + tree.Search("tria"));
        Console.WriteLine("Should be True, result: " + tree.Search("trie"));
        Console.WriteLine("Should be False, result: " + tree.Search("algorithms"));
        Console.WriteLine("Should be True, result: " + tree.Search("testing"));
        
        Console.Read();
    }
}
*/