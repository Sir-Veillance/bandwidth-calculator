using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using bandwidth_calculator.Node;

/*
-Find every path from source to destination without cycles (not the same node twice in the path) A path is a list of connections
-Sort paths by length (same length paths are arbitrarily sorted)
-Send the maximum "bandwidth" from source to destination, and track leftover bandwidth at each connection
-Go through the paths in sorted order doing this, if a path does not have any leftover bandwidth at any of its connections, it is eliminated
-The maximum passed along a path is whatever the least bandwidth connection in the path is, this value is subtracted from the amount left in each connection
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
                var nodeList = new List<Node>();
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
                    var connection = new Connection(firstNode, secondNode, connectionBandwidth, connectionBandwidth);
                    firstNode.addConnection(connection);
                    secondNode.addConnection(connection);
                }

                // creating the paths
                List<List<Connection>> allPaths = generateAllPaths(nodeList[0], 4);
                // calculate bandwidth
                IOrderedEnumerable<List<Connection>> orderedPaths = allPaths.OrderBy(path => path.Count);
                int bandwidth = 0;
                foreach (var path in orderedPaths) {
                    // find bottleneck connection
                    int maxSend = 2000000000;
                    foreach (var connection in path) {
                        if (connection.remaining < maxSend) {
                            maxSend = connection.remaining;
                        }
                    }
                    bandwidth = bandwidth + maxSend;
                    foreach (var connection in path) {
                        connection.remaining = connection.remaining - maxSend;
                    }
                }
                Console.WriteLine(bandwidth);
            } else {
                Console.WriteLine("Invalid filename...");
            }

            // path generation
            
        }

        public static void createPaths(List<List<Connection>> connectionList) {
            // check to see if the connection is already in path
            // check to see if the connection leads to the destination (then you are finished)
            
        }

        public static List<List<Connection>> generateAllPaths (Node sourceNode, int destinationId) {
            var allConnections = new List<List<Connection>>();
            var nodesInPath = new List<int>();
            // foreach (var connection in sourceNode.connections) {
            //     var workingPath = new List<Connection>();
            //     workingPath.Add(connection);
            //     generateAllPathsInner(sourceNode, destinationId, nodesInPath, workingPath, allConnections);
            // }
            var workingPath = new List<Connection>();
            generateAllPathsInner(sourceNode, destinationId, nodesInPath, workingPath, allConnections);
            return allConnections;
        }

        public static void generateAllPathsInner (Node currentNode, int destinationId, List<int> nodesInPath, List<Connection> workingPath, List<List<Connection>> allConnections) {
            if (currentNode.nodeId == destinationId) {
                var appendList = new List<Connection>();
                foreach (var connection in workingPath) {
                    appendList.Add(connection);
                }
                allConnections.Add(appendList);
                return;
            }

            nodesInPath.Add(currentNode.nodeId);
            foreach (var connection in currentNode.connections) {
                // checking to see if our current node is first or second in the connection
                if (currentNode.nodeId == connection.firstNode.nodeId) {
                    // checking to see if the connection leads to an already visited node
                    if (nodesInPath.IndexOf(connection.secondNode.nodeId) == -1) {
                        workingPath.Add(connection);
                        generateAllPathsInner(connection.secondNode, destinationId, nodesInPath, workingPath, allConnections);
                        workingPath.Remove(connection);
                    }
                } else {
                    // checking to see if the connection leads to an already visited node
                    if (nodesInPath.IndexOf(connection.firstNode.nodeId) == -1) {
                        workingPath.Add(connection);
                        generateAllPathsInner(connection.firstNode, destinationId, nodesInPath, workingPath, allConnections);
                        workingPath.Remove(connection);
                    }
                }
            }
            nodesInPath.Remove(currentNode.nodeId);
        }

        /*
            function(currentNode, connectionList, allPaths) {
                for each connection in connectionList{
                    if (currentNode == destination){
                        allPaths.Add(connectionList)
                        // return connectionList
                    }
                    if we haven't been to connection AND the connection lead to the source{
                        add connection to connectionList
                        function(go to node where connection points, connectionList, allPaths)
                    }
                }
            }
            
            generatePaths (int sourceNode, int destinationNode, List<Connection> workingPath) {
                source = get from nodeList where nodeId == sourceNode;

                foreach (connection in source.connections) {
                    if (connection.firstNode.nodeID == source.nodeID) {
                        if (connection.secondNode.nodeID == destinationNode) {
                            workingPath = workingPath.Add(connection);
                            return workingPath;
                        } else {
                            workingPath = workingPath.Add(connection);
                            generatePaths(secondNode.nodeID, destinationNode, workingPath);
                        }
                    else {
                        if (connection.firstNode.nodeID == destinationNode) {
                            workingPath = workingPath.Add(connection);
                            return workingPath;
                        } else {
                            workingPath = workingPath.Add(connection);
                            generatePaths(firstNode.nodeID, destinationNode, workingPath);
                        }
                    }
                    
                    }
                }
            }
        */

    }
}
