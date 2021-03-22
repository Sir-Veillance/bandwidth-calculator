using System;
using System.Collections.Generic;

namespace bandwidth_calculator {
    class Node {
        private int _nodeId;
        public List<(Node, int, int)> connections {get;}
        public Node(int id) {
            _nodeId = id;
            connections = new List<(Node, int, int)>(); // (node, bandwidth, used)
        }
        public int nodeId {
            get {
                return _nodeId;
            }
        }
        public void addConnection(Node newNode, int bandwidth, int used) {
            connections.Add((newNode, bandwidth, used));
        }

        // Look through the connection list of both nodes and return a list of shared nodes.
        // May need to do this recursively to see if there are shared nodes further back
        public List<Node> getSharedConnections(Node node1, Node node2) {
            return new List<Node>();
        }
        public override string ToString(){
            string outString = new String("nodeId:" + nodeId);
            outString += "\nConnections:\n";
            foreach (var connection in connections) {
                outString += "Node: " + connection.Item1.nodeId + " Bandwidth: " + connection.Item2 + " Used: " + connection.Item3 + "\n";
            }
            return outString;
        }

        // Look at all shared Nodes and pull from the node that can give the maximum value.
        // Update the available_output from that Node.
        public int pullFromShared(List<Node> sharedNodes) {
            return 0;
        }
    }
}