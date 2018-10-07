using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleGraph
{
    public int[,] graph;

    public void Graph(int nodes, int edges)
    {
        graph = new int[nodes, nodes];
        for (int i = 0; i < nodes; i++)
        {
            for (int j = 0; j < nodes; j++)
            {
                graph[i, j] = 0;
            }
        }

        for (int i = 0; i < edges; i++)
        {
            int u;
            int v;
            graph[u, v] = 1;
            graph[v, u] = 1;
        }

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.Read();
    }
}