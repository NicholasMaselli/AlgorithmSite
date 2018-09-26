/*
using System;
using System.Collections.Generic;

public class Node<T>
{
    public T data;
    public Node<T> left;
    public Node<T> right;

    public Node(T data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

public class BinaryTree<T>
{
    public Node<T> root;

    public BinaryTree()
    {
        root = null;
    }

    public BinaryTree(T data)
    {
        root = new Node<T>(data);
    }
}

public class BinaryTreeTest
{
    public static void Main(string[] args)
    {
        int data = 10;
        BinaryTree<int> tree = new BinaryTree<int>(data);
        tree.root.left = new Node<int>(1);
        tree.root.right = new Node<int>(2);
        tree.root.left.left = new Node<int>(5);
        tree.root.left.right = new Node<int>(3);
        tree.root.right = new Node<int>(4);
    }
}
*/