using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] graph;
    static int[] subtreeSize;
    static int removableEdges = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); 
        if (n % 2 == 1)
        {
            Console.WriteLine(0); 
            return;
        }

        graph = new List<int>[n + 1];
        subtreeSize = new int[n + 1];

        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < n - 1; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }
        DFS(1, -1);

        Console.WriteLine(removableEdges);
    }

    static int DFS(int node, int parent)
    {
        subtreeSize[node] = 1;
        foreach (int neighbor in graph[node])
        {
            if (neighbor == parent) continue;

            subtreeSize[node] += DFS(neighbor, node);
        }
        if (subtreeSize[node] % 2 == 0 && parent != -1)
        {
            removableEdges++;
        }

        return subtreeSize[node];
    }
}