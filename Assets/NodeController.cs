using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public List.SingleLinkedList<NodeController> adjacentNodes;
    void Awake()
    {
        adjacentNodes = new List.SingleLinkedList<NodeController>();
    }
    public void AddAdjacentNode(NodeController node)
    {
        adjacentNodes.InsertAtEnd(node);
    }
    public NodeController SelecRandomAdjacent()
    {
        int index = Random.Range(0, adjacentNodes.Count);
        return adjacentNodes.GetElementAt(index);
    }
    public class Edge
    {
        public NodeController Node { get; private set; }
        public float Weight { get; private set; }

        public Edge(NodeController node, float weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
