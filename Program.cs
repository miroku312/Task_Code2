using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] graph;  
    static bool[] visited;     
    static int removableEdges = 0; 

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n % 2 == 1)
        {
            Console.WriteLine(-1);
            return;
        }
        graph = new List<int>[n + 1]; 
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);

            graph[u].Add(v);
            graph[v].Add(u);
        }

        visited = new bool[n + 1];
        DFS(1);
        Console.WriteLine(removableEdges);
    }

    static int DFS(int node)
    {
        visited[node] = true;
        int subtreeSize = 1; 

        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                int childSize = DFS(neighbor);
                if (childSize % 2 == 0)
                {
                    removableEdges++;
                }
                else
                {
                    subtreeSize += childSize;
                }
            }
        }

        return subtreeSize;
    }
}