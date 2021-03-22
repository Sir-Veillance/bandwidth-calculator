using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using bandwidth_calculator.Node;

/*
-Find every path from source to destination without cycles (not the same node twice in the path)
-Sort paths by length (same length paths are arbitrarily sorted)
-Send the maximum "bandwidth" from source to destination, and track leftover bandwidth at each node
-Go through the paths in sorted order doing this, if a path does not have any leftover bandwidth from source or from any node along the path, it is eliminated
-Solution should be total amount of bandwidth that reached destination after going through every path/eliminating every path
*/

namespace bandwidth_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // file parsing
            Console.WriteLine("Please enter a filename with extension: ");
            string filename = Console.ReadLine();
            if (File.Exists(filename)) {
                string[] input = File.ReadAllLines(filename);
                int nodeCount = int.Parse(input[0]);
                List<Node> nodeList = new List<Node>();
                for (int i = 1; i < nodeCount + 1; i++) {
                    nodeList.Add(new Node(i));
                }
                string[] sourceAndDestination = input[1].Split(' ');
                int sourceID = int.Parse(sourceAndDestination[0]);
                int destinationID = int.Parse(sourceAndDestination[1]);
                for (int i = 2; i < input.Length - 1; i++) {
                    string[] parsedLine = input[i].Split(' ');
                    Node firstNode = nodeList.Find(node => node.nodeId == int.Parse(parsedLine[0]));
                    Node secondNode = nodeList.Find(node => node.nodeId == int.Parse(parsedLine[1]));
                    int connectionBandwidth = int.Parse(parsedLine[2]);
                    Connection connection = new Connection(firstNode, secondNode, connectionBandwidth, 0);
                    firstNode.addConnection(connection);
                    secondNode.addConnection(connection);
                }
                foreach (var node in nodeList){
                    Console.WriteLine(node);
                }

            } else {
                Console.WriteLine("Invalid filename...");
            }

            // path generation
            
        }
    }
}
