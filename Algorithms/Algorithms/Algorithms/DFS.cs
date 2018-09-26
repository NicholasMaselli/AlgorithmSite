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

    public void PrintTraversal()
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
        DFS dfs = new DFS(graph, source);
        dfs.PrintTraversal();
        Console.Read();

        //Output: [0, 2, 1, 3, 6, 12, 7, 14, 8, 4, 10, 11, 5, 16, 9, 15, 19, 23, 20, 21, 25, 24, 26, 22, 18, 17, ]
    }
    */
}
