using System;
using System.Collections.Generic;

namespace bandwidth_calculator {
    class Node {
        private int _nodeId;
        public List<Connection> connections {get;}
        public Node(int id) {
            _nodeId = id;
            connections = new List<Connection>(); // (node, bandwidth, used)
        }
        public int nodeId {
            get {
                return _nodeId;
            }
        }
        public void addConnection(Connection connection) {
            connections.Add(connection);
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
                outString += "FirstNode: " + connection.firstNode.nodeId + " SecondNode: " + connection.secondNode.nodeId + " Bandwidth: " + connection.bandwidth+ " Used: " + connection.used + "\n";
            }
            return outString;
        }

        // Look at all shared Nodes and pull from the node that can give the maximum value.
        // Update the available_output from that Node.
        public int pullFromShared(List<Node> sharedNodes) {
            return 0;
        }
    }

    class Connection {
        private int _bandwidth;
        private int _used;
        private Node _firstNode;
        private Node _secondNode;

        public Connection(Node firstNode, Node secondNode, int bandwidth, int used) {
            _firstNode = firstNode;
            _secondNode = secondNode;
            _bandwidth = bandwidth;
            _used = used;
        }
        public Node firstNode{
            get{
                return _firstNode;
            }
        }
        public Node secondNode{
            get{
                return _secondNode;
            }
        }

        public int bandwidth{
            get {
                return _bandwidth;
            }
        }
        
        public int used{
            get{
                return _used;
            }
        }
    }
}