using System;
using System.Collections.Generic;

namespace bandwidth_calculator {
    class Node {
        public Node(string id, int output) {
            string nodeId = id;
            List<Node> connections = new List<Node>();
            int maxOutput = output;
            int availableOutput = maxOutput; // something we determine from recursing backward
        }
        public string nodeId {get;}
        public List<Node> connections {get;}
        public int maxOuput {get;set;}
        public int availableOutput {get;set;}
        
        public void addConnection(Node newNode) {
            connections.Add(newNode);
        }

        // Look through the connection list of both nodes and return a list of shared nodes.
        // May need to do this recursively to see if there are shared nodes further back
        public List<Node> getSharedConnections(Node node1, Node node2) {
            return new List<Node>();
        }

        // Look at all shared Nodes and pull from the node that can give the maximum value.
        // Update the available_output from that Node.
        public int pullFromShared(List<Node> sharedNodes) {
            return 0;
        }
    }
}