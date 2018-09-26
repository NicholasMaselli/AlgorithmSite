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

//This class used Vertex objects to represent the vertices in the graph. Additional parameters could be added to the Vertex class such as a key or values
public class GraphObject
{
    public class Vertex
    {
        private Dictionary<Vertex, int> _neighbors;

        public Vertex()
        {
            _neighbors = new Dictionary<Vertex, int>();
        }

        public void addNeighbor(Vertex vertex, int weight = 1)
        {
            _neighbors.Add(vertex, weight);
        }

        public void removeNeighbor(Vertex vertex)
        {
            _neighbors.Remove(vertex);
        }

        public int getEdge(Vertex dest)
        {
            return _neighbors[dest];
        }

        public Dictionary<Vertex, int> getNeighbors()
        {
            return _neighbors;
        }
    }

    private int _size;
    private Dictionary<Vertex, Vertex> _graph = new Dictionary<Vertex, Vertex>();

    public GraphObject()
    {
    }

    public void addVertex(Vertex vertex)
    {
        _graph.Add(vertex, vertex);
        _size++;
    }

    public void setEdge(Vertex src, Vertex dest, int weight)
    {
        _graph[src].addNeighbor(dest, weight);
    }

    public int getEdge(Vertex src, Vertex dest)
    {
        return _graph[src].getEdge(dest);
    }

    public bool hasEdge(Vertex src, Vertex dest)
    {
        return _graph[src].getNeighbors().ContainsKey(dest);
    }

    public Dictionary<Vertex, int> getAdjVertices(Vertex src)
    {
        return _graph[src].getNeighbors();
    }
}

//The GraphMatrix class uses a 2 dimensional array named _matrix. The value _matrix[i,j] is the value of the edge from vertex i to vertex j
public class GraphMatrix
{
    //Matrix representation of the graph
    private int[,] _matrix;

    //Number of nodes in the graph
    private int _size;

    public GraphMatrix(int size)
    {
        _size = size;
        _matrix = new int[size, size];
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

//For the GraphList class, the ith vertex in array is a list of vertices adjacent to the ith vertex. This can represent weighted graphs if the List is changed to be a List of integer pairs
//This implementation is unweighted
public class GraphList
{
    private int _size;
    private List<int>[] _graph;

    public GraphList(int size)
    {
        _size = size;
        _graph = new List<int>[_size];
    }

    public void addVertices(int number)
    {
        int newSize = _size + number;

        List<int>[] newGraph = new List<int>[newSize];
        for (int i = 0; i < _size; i++)
        {
            newGraph[i] = _graph[i];
        }
        _size = newSize;
        _graph = newGraph;
    }

    public void setEdge(int src, int dest)
    {
        if (_graph[src] == null)
        {
            _graph[src] = new List<int>();
        }

        if (_graph[dest] == null)
        {
            _graph[dest] = new List<int>();
        }

        _graph[src].Add(dest);
        _graph[dest].Add(src);
    }

    public bool hasEdge(int src, int dest)
    {
        for (int i = 0; i < _graph[src].Count; i++)
        {
            if (_graph[src][i] == dest)
            {
                return true;
            }
        }
        return false;
    }

    public List<int> getAdjVertices(int src)
    {
        return _graph[src];
    }
}

/*
class GraphTest
{
    public static void Main(string[] args)
    {
        int size = 10;
        //GraphMatrix graph = new GraphMatrix(size);
        //GraphList graph = new GraphList(10);
        GraphObject graph = new GraphObject();

        GraphObject.Vertex vertex0 = new GraphObject.Vertex();
        GraphObject.Vertex vertex1 = new GraphObject.Vertex();
        GraphObject.Vertex vertex2 = new GraphObject.Vertex();
        GraphObject.Vertex vertex3 = new GraphObject.Vertex();
        GraphObject.Vertex vertex4 = new GraphObject.Vertex();
        GraphObject.Vertex vertex5 = new GraphObject.Vertex();

        graph.addVertex(vertex0);
        graph.addVertex(vertex1);
        graph.addVertex(vertex2);
        graph.addVertex(vertex3);
        graph.addVertex(vertex4);
        graph.addVertex(vertex5);

        graph.setEdge(vertex0, vertex2, 10);
        graph.setEdge(vertex0, vertex3, 20);
        graph.setEdge(vertex2, vertex4, 40);
        graph.setEdge(vertex3, vertex2, 30);
        graph.setEdge(vertex4, vertex3, 50);
        graph.setEdge(vertex5, vertex4, 60);
        //graph.printGraph();

        Console.WriteLine("");
        Console.WriteLine(graph.hasEdge(vertex4, vertex3));
        Console.WriteLine(graph.getEdge(vertex4, vertex3));
        Console.WriteLine(graph.hasEdge(vertex3, vertex4));
        Console.WriteLine(graph.hasEdge(vertex5, vertex3));

        //graph.printVertices(0);
        Console.Read();
    }
}
*/