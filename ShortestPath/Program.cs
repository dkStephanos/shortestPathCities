using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {

            /*s [the number of tests <= 10]
            n [the number of cities <= 10000]
            NAME [city name]
            p [the number of neighbours of city NAME]
            nr cost [nr - index of a city connected to NAME (the index of the first city is 1)]
                       [cost - the transportation cost]
            r [the number of paths to find <= 100]
            NAME1 NAME2 [NAME1 - source, NAME2 - destination]
            [empty line separating the tests]*/

            int numTests, numCities, numNeighbors, numPaths;
            string connection, output;

            Console.Write("Enter number of test: ");
            numTests = Int32.Parse(Console.ReadLine());

            Console.Write("Enter number of cities: ");
            numCities = Int32.Parse(Console.ReadLine());
            String[] cities = new String[numCities + 1];
            int[,] connections = new int[numCities + 1,numCities + 1];

            for (int i = 1; i <= numCities; i++)
            {
                Console.Write("Enter name of city: ");
                cities[i] = Console.ReadLine();
                Console.Write("Enter number of neighbors for city: ");
                numNeighbors = Int32.Parse(Console.ReadLine());

                for (int j = 1; j <= numNeighbors; j++)
                {
                    Console.Write("Enter connection (e.g. 1 2): ");
                    connection = Console.ReadLine();
                    connections[i, Int32.Parse(connection[0].ToString())] = Int32.Parse(connection[2].ToString());
                }
            }

            for (int i = 0; i < numTests; i++)
            {
                Console.Write("Enter number of paths: ");
                numPaths = Int32.Parse(Console.ReadLine());
                String[] paths = new string[numPaths];
                for (int j = 0; j < numPaths; j++)
                {
                    Console.Write("Enter connection (e.g. 1 2): ");
                    paths[j] = Console.ReadLine();
                }
            }




            Console.ReadLine();
        }
    }
}
