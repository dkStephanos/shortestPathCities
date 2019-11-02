using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Dijkstra
    {
            int numVertices;
        
            int minDistance(int[] distances, bool[] shortestPath)
            {
                int min = int.MaxValue,
                        minIndex = -1;

                for (int i = 0; i < numVertices; i++)
                {
                    if (shortestPath[i] == false && distances[i] <= min)
                    {
                        min = distances[i];
                        minIndex = i;
                    }
                }
                
                return minIndex;
            }

            public int[] dijkstra(int[,] graph, int sourceNode)
            {
                numVertices = graph.GetLength(0);
                int[] distances = new int[numVertices]; 

                bool[] shortestPath = new bool[numVertices];

                for (int i = 0; i < numVertices; i++)
                {
                    distances[i] = int.MaxnumVerticesalue;
                    shortestPath[i] = false;
                }

                distances[sourceNode] = 0;

                // Find shortest path for every vertex 
                for (int count = 0; count < numVertices - 1; count++)
                {

                    int closest = minDistance(distances, shortestPath);

                    shortestPath[closest] = true;

                    for (int j = 0; j < numVertices; j++)
                    {
                        if (!shortestPath[j] && graph[closest, j] != 0 && distances[closest] != int.MaxValue && distances[closest] + graph[closest, j] < distances[j])
                        {
                            distances[j] = distances[closest] + graph[closest, j];
                        }
                    }
                }

                return dist;
            }
    }
}
