using System;
using System.Collections;
using System.Collections.Generic;

//The GraphMatrix class uses a 2 dimensional array named _matrix. The value _matrix[i,j] is the value of the edge from vertex i to vertex j
public class Graph
{
    //Matrix representation of the graph
    private int[,] _matrix;

    //Number of nodes in the graph
    private int _size;

    public Graph(int size)
    {
        _size = size;
        _matrix = new int[size, size];
    }

    public int getSize()
    {
        return _size;
    }

    public void addVertex(int number)
    {
        int newSize = _size + number;
        int[,] newMatrix = new int[newSize, newSize];
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                newMatrix[i, j] = _matrix[i, j];
            }
        }
        _size = newSize;
        _matrix = newMatrix;
    }

    public void setEdge(int src, int dest, int value = 1)
    {
        _matrix[src, dest] = value;
    }

    public int getEdge(int src, int dest)
    {
        return _matrix[src, dest];
    }

    public bool hasEdge(int src, int dest)
    {
        if (_matrix[src, dest] != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int[] getAdjVertices(int src)
    {
        int[] adj = new int[_size];
        for (int i = 0; i < _size; i++)
        {
            adj[i] = _matrix[src, i];
        }
        return adj;
    }

    public void printGraph()
    {
        Console.WriteLine("[");
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Console.Write(_matrix[i, j] + ", ");
            }
            Console.WriteLine("");

        }
        Console.Write("]");
    }

    public void printVertices(int fromVertex)
    {
        Console.Write("[");
        int[] vertices = getAdjVertices(fromVertex);
        for (int i = 0; i < vertices.Length; i++)
        {
            Console.Write(vertices[i] + ", ");
        }
        Console.Write("]");
    }
}

public class BFS
{
    Graph _graph;
    int _source;

    public bool[] _visited;
    public List<int> _traversalOrder = new List<int>();

    public BFS(Graph graph, int src)
    {
        _graph = graph;
        _source = src;
        _visited = new bool[graph.getSize()];

        //Breadth First Search uses a Queue from System.Collections to do level order traversal
        //Can also use a List<int> class from System.Collections.Generic which requires a few more lines of code to Dequeue
        Queue queue = new Queue();

        queue.Enqueue(_source);
        _visited[_source] = true;
        _traversalOrder.Add(_source);

        while (queue.Count != 0)
        {
            int vertex = (int)queue.Dequeue();

            //Add all adjacent vertices to queue
            int[] adj = _graph.getAdjVertices(vertex);
            for (int i = 0; i < adj.Length; i++)
            {
                if (_visited[adj[i]] == false)
                {
                    queue.Enqueue(adj[i]);
                    _visited[adj[i]] = true;
                    _traversalOrder.Add(adj[i]);
                }                
            }
        }
    }

    public void printTraversal()
    {
        Console.Write("[");
        for (int i = 0; i < _traversalOrder.Count; i++)
        {
            Console.Write(_traversalOrder[i] + ", ");
        }
        Console.Write("]");        
    }

    public void Main(string[] args)
    {
        
    }
}