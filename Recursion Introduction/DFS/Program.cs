using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        
    }
    static int[][] graph =
    {
        new[] {1, 6, 7},
        new[] {0, 2, 5},
        new[] {1, 3, 4},
        new[] {2},
        new[] {2},
        new[] {1},
        new[] {0},
        new[] {0, 8, 11},
        new[] {7, 9, 10},
        new[] {8},
        new[] {8},
        new[] {7},
    };

    static bool[] visited = new bool[graph.Length];

    static void DfsRecursive(int node)
    {
        visited[node] = true;

        Console.WriteLine(node);

        foreach (int neighbor in graph[node])
        {
            if (visited[neighbor])
            {
                continue;
            }

            DfsRecursive(neighbor);
        }
    }

    static void DfsIterative(int node)
    {
        var stack = new Stack<int>();

        stack.Push(node);

        while (stack.Count != 0)
        {
            int currentNode = stack.Pop();
            visited[currentNode] = true;

            Console.WriteLine(currentNode);

            foreach (int neighbor in graph[currentNode].Reverse())
            {
                if (visited[neighbor])
                {
                    continue;
                }

                stack.Push(neighbor);
            }
        }
    }
}