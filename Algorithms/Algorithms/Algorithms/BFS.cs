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

    public List<int> getAdjVertices(int src)
    {
        List<int> adj = new List<int>();
        for (int i = 0; i < _size; i++)
        {
            if (_matrix[src, i] != 0)
            {
                adj.Add(i);
            }
            
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
        List<int> vertices = getAdjVertices(fromVertex);
        for (int i = 0; i < vertices.Count; i++)
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
            List<int> adj = _graph.getAdjVertices(vertex);
            for (int i = 0; i < adj.Count; i++)
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

    /*
    public static void Main(string[] args)
    {
        //Graph From Image
        int size = 27;
        Graph graph = new Graph(size);

        //Add All Edges...
        graph.setEdge(0, 2, 10);
        graph.setEdge(2, 0, 10);
        graph.setEdge(0, 3, 10);
        graph.setEdge(3, 0, 10);
        graph.setEdge(0, 4, 15);
        graph.setEdge(4, 0, 15);
        graph.setEdge(1, 2, 5);
        graph.setEdge(2, 1, 5);
        graph.setEdge(2, 3, 20);
        graph.setEdge(3, 2, 20);
        graph.setEdge(2, 6, 10);
        graph.setEdge(6, 2, 10);
        graph.setEdge(2, 8, 35);
        graph.setEdge(8, 2, 35);
        graph.setEdge(4, 8, 45);
        graph.setEdge(8, 4, 45);
        graph.setEdge(4, 10, 40);
        graph.setEdge(10, 4, 40);
        graph.setEdge(6, 12, 15);
        graph.setEdge(12, 6, 15);
        graph.setEdge(7, 12, 10);
        graph.setEdge(12, 7, 10);
        graph.setEdge(10, 11, 10);
        graph.setEdge(11, 10, 10);
        graph.setEdge(5, 11, 5);
        graph.setEdge(11, 5, 5);
        graph.setEdge(10, 16, 20);
        graph.setEdge(16, 10, 20);

        graph.setEdge(8, 14, 30);
        graph.setEdge(14, 8, 30);
        graph.setEdge(7, 14, 5);
        graph.setEdge(14, 7, 5);
        graph.setEdge(7, 17, 25);
        graph.setEdge(17, 7, 25);
        graph.setEdge(17, 18, 5);
        graph.setEdge(18, 17, 5);
        graph.setEdge(14, 19, 5);
        graph.setEdge(19, 14, 5);
        graph.setEdge(16, 9, 25);
        graph.setEdge(9, 16, 25);
        graph.setEdge(15, 16, 15);
        graph.setEdge(16, 15, 15);
        graph.setEdge(16, 21, 20);
        graph.setEdge(21, 16, 20);
        graph.setEdge(15, 19, 10);
        graph.setEdge(19, 15, 10);

        graph.setEdge(18, 22, 5);
        graph.setEdge(22, 18, 5);
        graph.setEdge(19, 23, 10);
        graph.setEdge(23, 19, 10);
        graph.setEdge(20, 21, 15);
        graph.setEdge(21, 20, 15);
        graph.setEdge(20, 23, 20);
        graph.setEdge(23, 20, 20);
        graph.setEdge(21, 25, 25);
        graph.setEdge(25, 21, 25);
        graph.setEdge(25, 24, 20);
        graph.setEdge(24, 25, 20);
        graph.setEdge(22, 26, 35);
        graph.setEdge(26, 22, 35);
        graph.setEdge(23, 26, 25);
        graph.setEdge(26, 23, 25);
        graph.setEdge(24, 26, 20);
        graph.setEdge(26, 24, 20);

        int source = 0;
        BFS bfs = new BFS(graph, source);
        bfs.printTraversal();
        Console.Read();

        //Output: [0, 2, 3, 4, 1, 6, 8, 10, 12, 14, 11, 16, 7, 19, 5, 9, 15, 21, 17, 23, 20, 25, 18, 26, 24, 22, ]
    }
    */
}

using System;
using System.Collections.Generic;

public class DFS
{
    Graph _graph;
    int _source;

    bool[] _visited;
    public List<int> _traversalOrder = new List<int>();

    public DFS(Graph graph, int source)
    {
        _graph = graph;
        _source = source;
        _visited = new bool[graph.getSize()];

        _visited[source] = true;
        _traversalOrder.Add(source);

        List<int> adj = graph.getAdjVertices(source);
        for (int i = 0; i < adj.Count; i++)
        {
            search(adj[i]);
        }
    }

    private void search(int vertex)
    {
        if (_visited[vertex] == false)
        {
            _visited[vertex] = true;
            _traversalOrder.Add(vertex);

            List<int> adj = _graph.getAdjVertices(vertex);
            for (int i = 0; i < adj.Count; i++)
            {
                search(adj[i]);
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

    public static void Main(string[] args)
    {
        //Graph From Image
        int size = 27;
        Graph graph = new Graph(size);

        int source = 0;
        DFS dfs = new DFS(graph, source);
        dfs.printTraversal();
        Console.Read();

        //Output: [0, 2, 1, 3, 6, 12, 7, 14, 8, 4, 10, 11, 5, 16, 9, 15, 19, 23, 20, 21, 25, 24, 26, 22, 18, 17, ]
    }
}

        