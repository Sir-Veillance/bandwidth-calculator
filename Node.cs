using System;
using System.Collections.Generic;

namespace bandwidth_calculator {
    class Node {
        private int _nodeId;
        public List<Connection> connections {get;}
        public Node(int id) {
            _nodeId = id;
            connections = new List<Connection>(); // (node, bandwidth, remaining)
        }
        public int nodeId {
            get {
                return _nodeId;
            }
        }
        public void addConnection(Connection connection) {
            connections.Add(connection);
        }
        public override string ToString(){
            string outString = new String("nodeId:" + nodeId);
            outString += "\nConnections:\n";
            foreach (var connection in connections) {
                outString += "FirstNode: " + connection.firstNode.nodeId + " SecondNode: " + connection.secondNode.nodeId + " Bandwidth: " + connection.bandwidth+ " Remaining: " + connection.remaining + "\n";
            }
            return outString;
        }
    }

    class Connection {
        private int _bandwidth;
        private int _remaining;
        private Node _firstNode;
        private Node _secondNode;

        public Connection(Node firstNode, Node secondNode, int bandwidth, int remaining) {
            _firstNode = firstNode;
            _secondNode = secondNode;
            _bandwidth = bandwidth;
            _remaining = remaining;
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
        
        public int remaining {
            get {
                return _remaining;
            }
            set {
                _remaining = value;
            }
        }
        
    }
}
