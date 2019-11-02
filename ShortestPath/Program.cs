using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ---------------------------------------------------------------------------
// File name: Program.cs
// Project name: ShortestPathCities
// ---------------------------------------------------------------------------
// Creator’s name and email: Koi Stephanos, stephanos@etsu.edu
// Course-Section://Creation Date:  Algorithms, 11/2/2019
// ---------------------------------------------------------------------------
namespace ShortestPath
{   
    class Program
    {
        static Dijkstra dijkstra = new Dijkstra();                         //Instance of class to handle algorithm performance
        static int numTests, numCities, numNeighbors, numPaths;            //Variables to hold counts from user entry  
        static int[][] distanceGraphs;                                     //Actual graphs of distance between cities
        static string[] startCities, endCities;                            //Arrays for cities in our graph for calculation
        static string connection;                                          //Input string

        static void Main(string[] args)
        {

            //Format for data entry
            /*s [the number of tests <= 10]
            n [the number of cities <= 10000]
            NAME [city name]
            p [the number of neighbours of city NAME]
            nr cost [nr - index of a city connected to NAME (the index of the first city is 1)]
                       [cost - the transportation cost]
            r [the number of paths to find <= 100]
            NAME1 NAME2 [NAME1 - source, NAME2 - destination]
            [empty line separating the tests]*/

          
            //Get number of tests from user
            Console.Write("Enter number of test: ");
            numTests = Int32.Parse(Console.ReadLine());

            //Get number of cities
            Console.Write("Enter number of cities: ");
            numCities = Int32.Parse(Console.ReadLine());
            String[] cities = new String[numCities];
            int[,] connections = new int[numCities,numCities];

            //Loop through and collect city name and neighbors
            for (int i = 0; i < numCities; i++)
            {
                Console.Write("Enter name of city: ");
                cities[i] = Console.ReadLine();
                Console.Write("Enter number of neighbors for city: ");
                numNeighbors = Int32.Parse(Console.ReadLine());

                for (int j = 0; j < numNeighbors; j++)
                {
                    Console.Write("Enter connection (e.g. 1 2): ");
                    connection = Console.ReadLine();
                    connections[i, Int32.Parse(connection[0].ToString()) - 1] = Int32.Parse(connection[2].ToString());
                }
            }

            //Collect path data for cities
            for (int i = 0; i < numTests; i++)
            {
                Console.Write("Enter number of paths: ");
                numPaths = Int32.Parse(Console.ReadLine());
                String[] paths = new String[numPaths];
                distanceGraphs = new int[numPaths][];
                startCities = new String[numPaths];
                endCities = new String[numPaths];

                for (int j = 0; j < numPaths; j++)
                {   
                    //Gets connection data and splits it into corresponding arrays
                    Console.Write("Enter connection (e.g. city1 city2): ");
                    paths[j] = Console.ReadLine();
                    startCities[j] = paths[j].Split(' ')[0];
                    endCities[j] = paths[j].Split(' ')[1];

                    //Run Dijkstra's algorithm for each vertex, starting with the start city
                    distanceGraphs[j] = dijkstra.dijkstra(connections, Array.IndexOf(cities, startCities[j]));
                }
            }

            //Print results
            Console.WriteLine("Output:\n");
            for (int i = 0; i < numPaths; i++)
            {
                Console.WriteLine(distanceGraphs[i][Array.IndexOf(cities, endCities[i])]);

            }

            //Pause execution to view results
            Console.ReadLine();
        }
    }
}
