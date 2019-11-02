using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ---------------------------------------------------------------------------
// File name: Dijkstra.cs
// Project name: ShortestPathCities
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
namespace ShortestPath
{
    class Dijkstra
    {
            int numVertices;                //Holds the number of vertices in the graph
            

            //Finds the minimum path 
            int minDistance(int[] distances, bool[] shortestPath)
            {
                int min = int.MaxValue,             //Minimum path so far, set to infinity to start
                        minIndex = -1;              //Index of minimum path node, set to -1 to start

                //Step through all vertices, and if the path is shorter than
                //what we have so far, store it as the new min
                for (int i = 0; i < numVertices; i++)
                {
                    if (shortestPath[i] == false && distances[i] <= min)
                    {
                        min = distances[i];
                        minIndex = i;
                    }
                }

                //Return the index of the node on the minimum path
                return minIndex;
            }

            public int[] dijkstra(int[,] graph, int sourceNode)
            {
                //Get number of vertices and create arrays to track distances 
                //and shortestPath for each vertex
                numVertices = graph.GetLength(0);
                int[] distances = new int[numVertices]; 
                bool[] shortestPath = new bool[numVertices];

                //Set all distances to infinity and shortestPath to false to start
                for (int i = 0; i < numVertices; i++)
                {
                    distances[i] = int.MaxValue;
                    shortestPath[i] = false;
                }

                //Set the distance from our sourceNode to our sourceNode to zero
                distances[sourceNode] = 0;

                // Find shortest path for every vertex 
                for (int count = 0; count < numVertices - 1; count++)
                {
                    //Find cl
                    int closest = minDistance(distances, shortestPath);

                    shortestPath[closest] = true;

                    //Check if this path is the shortest for each vertes, if it is, update the distances array
                    for (int j = 0; j < numVertices; j++)
                    {
                        if (!shortestPath[j] && graph[closest, j] != 0 && distances[closest] != int.MaxValue && distances[closest] + graph[closest, j] < distances[j])
                        {
                            distances[j] = distances[closest] + graph[closest, j];
                        }
                    }
                }

                //Return the array containing the calculated shortestPaths distances 
                return distances;
            }
    }
}
