using System;
using System.Collections.Generic;
using Priority_Queue;

public class Djikstra
{
    Graph _graph;
    int _source;

    int _size;
    bool[] _visited;
    int[] _shortestDistance;
    int[] _shortestPaths;
    SimplePriorityQueue<int, int> _queue;

    public Djikstra(Graph graph, int source)
    {
        _graph = graph;
        _source = source;

        _size = graph.getSize();
        _visited = new bool[_size];
        _shortestDistance = new int[_size];
        _shortestPaths = new int[_size];

        for (int i = 0; i < _size; i++)
        {
            _shortestDistance[i] = int.MaxValue;
            _shortestPaths[i] = -1;
        }

        _queue = new SimplePriorityQueue<int, int>();
        _queue.Enqueue(_source, 0);
        _shortestDistance[_source] = 0;
        _shortestPaths[_source] = -1;

        //Use a Priority Queue for logerithmic O(Log(v)) insert and constant time get
        //Can also use a normal Queue, but MinDistance() function will be O(v) 
        while(_queue.Count != 0)
        {
            int vertex = MinDistanceVertex();
            _visited[vertex] = true;

            List<int> adj = _graph.getAdjVertices(vertex);
            for (int i = 0; i < adj.Count; i++)
            {

                //If this node has not been visited and the current _shortestDistance entry is less than or equal to the current _shortestDistance entry
                if (_visited[adj[i]] != true && _shortestDistance[adj[i]] > _shortestDistance[vertex] + graph.getEdge(vertex, adj[i]))
                {
                    _shortestDistance[adj[i]] = _shortestDistance[vertex] + graph.getEdge(vertex, adj[i]);
                    _shortestPaths[adj[i]] = vertex;
                    _queue.Enqueue(adj[i], _shortestDistance[adj[i]]);
                }
            }

        }
    }

    //MinDistance() function using the priority queue (Fibonacci Heap)
    public int MinDistanceVertex()
    {
        return _queue.Dequeue();
    }

    //Print the shortest path from the source to the input destination;
    public void PrintShortestPath(int destination)
    {
        List<int> shortestPath = new List<int>();
        shortestPath.Add(destination);

        //Get the parent vertex of the destination vertex
        int nextVertex = _shortestPaths[destination];
        while (nextVertex != -1)
        {
            shortestPath.Add(nextVertex);
            nextVertex = _shortestPaths[nextVertex];
        }

        Console.Write("[");
        for (int i = shortestPath.Count - 1; i > -1 ; i--)
        {
            Console.Write(shortestPath[i]);
            Console.Write("->");
        }
        Console.WriteLine("]");
        Console.Write("Shortest Distance = " + _shortestDistance[destination]);
    }

    //MinDistance() function can also loop through all vertices in no Priority_Queue available. This is O(V^2) however.
    /*
    public int MinDistanceVertex()
    {
        int minIndex = -1;
        int minDistance = int.MaxValue;

        for (int i = 0; i < _size; i++)
        {
            if (_visited[i] == false && _shortestDistance[i] <= minDistance)
            {
                minDistance = _shortestDistance[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
    */

    /*
    public static void Main(string[] args)
    {
        //Graph From Image
        int size = 27;
        Graph graph = new Graph(size);

        //Add All Edges
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
        int destination = 26;
        Djikstra djikstra = new Djikstra(graph, source);
        djikstra.PrintShortestPath(destination);
        Console.Read();

        //Output: 
        //[0->2->6->12->7->14->19->23->26->]
        //Shortest Distance = 90
    }
    */
}
