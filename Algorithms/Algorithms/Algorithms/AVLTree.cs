/*
using System;
using System.Collections;
using System.Collections.Generic;


public class Node
{
    public int data;
    public int height;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        height = 1;
    }
}

public class AVLTree
{

    public Node root;

    public AVLTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return;
        }

        root = Insert(root, data);
    }

    private Node Insert(Node node, int data)
    {
        //Perform standard BST Insert
        if (node == null)
        {
            return new Node(data);
        }

        if (data < node.data)
        {
            node.left = Insert(node.left, data);
        }
        else if (data > node.data)
        {
            node.right = Insert(node.right, data);
        }
        else
        {
            //Cannot insert a duplicate key
            return node;
        }

        //Set this node's height to be the height of the larger subtree + 1
        node.height = Math.Max(Height(node.left), Height(node.right)) + 1;

        //Find the first unbalanced node
        int balance = Balance(node);

        //Need to rebalance the tree        
        if (balance > 1 && node.left != null && data < node.left.data)
        {
            //left left insert
            return rightRotate(node);
        }
        else if (balance > 1 && node.left != null && data > node.left.data)
        {
            //left right insert
            node.left = leftRotate(node.left);
            return rightRotate(node);
        }
        else if (balance < -1 && node.right != null && data > node.right.data)
        {
            //right right insert
            return leftRotate(node);
        }
        else if (balance < -1 && node.right != null && data < node.right.data)
        {
            //right left insert
            node.right = rightRotate(node.right);
            return leftRotate(node);
        }

        return node;
    }

    //Rotate Node down a level to the node to its left
    public Node rightRotate(Node node)
    {
        Node pivot = node.left;
        Node rightNode = pivot.right;

        //Rotate
        pivot.right = node;
        node.left = rightNode;

        //Set height values
        node.height = Math.Max(Height(node.left), Height(node.right)) + 1;
        pivot.height = Math.Max(Height(pivot.left), Height(pivot.right)) + 1;

        return pivot;
    }

    //Rotate Node down a level to the node to its rigth
    public Node leftRotate(Node node)
    {
        Node pivot = node.right;
        Node leftNode = pivot.left;

        //Rotate
        pivot.left = node;
        node.right = leftNode;

        //Set height values
        node.height = Math.Max(Height(node.left), Height(node.right)) + 1;
        pivot.height = Math.Max(Height(pivot.left), Height(pivot.right)) + 1;

        return pivot;
    }

    public int Height(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            return node.height;
        }
    }

    //Returns how unbalanced the node's branches are
    public int Balance(Node node)
    {
        return Height(node.left) - Height(node.right);
    }

    public void PrintTree()
    {
        //Use Breadth First Search to Print Tree        
        Queue queue = new Queue();
        queue.Enqueue(root);

        //Second queue used to print level
        Queue levelQueue = new Queue();
        queue.Enqueue(0);

        int previousLevel = 0;
        while (queue.Count != 0)
        {
            Node node = (Node)queue.Dequeue();
            int level = (int)queue.Dequeue();

            if (level == previousLevel)
            {
                Console.Write(node.data + ", ");
            }
            else
            {
                previousLevel += 1;
                Console.WriteLine("");
                Console.Write(node.data + ", ");
            }

            if (node.left != null)
            {
                queue.Enqueue(node.left);
                queue.Enqueue(level + 1);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
                queue.Enqueue(level + 1);
            }
        }        
    }

    public static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();
        tree.Insert(19);
        tree.Insert(24);
        tree.Insert(12);
        tree.Insert(11);
        tree.Insert(17);
        tree.Insert(-4);
        tree.Insert(0);
        tree.Insert(-21);
        tree.Insert(18);
        tree.Insert(14);
        tree.Insert(7);
        tree.Insert(-6);
        tree.Insert(1);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(9);
        tree.Insert(10);
        tree.Insert(6);
        tree.Insert(-9);
        tree.Insert(-1);
        tree.Insert(2);
        tree.Insert(20);
        tree.Insert(-19);
        tree.Insert(4);
        tree.Insert(-3);

        tree.PrintTree();
        Console.Read();
    }
}
*/