using System.Collections;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public ArrayList adjacentNodes;

    void Awake()
    {
        adjacentNodes = new ArrayList();
    }

    public void AddAdjacentNode(NodeController node, float weight)
    {
        adjacentNodes.Add(new Edge(node, weight));
    }

    public NodeController SelectRandomAdjacent()
    {
        int index = Random.Range(0, adjacentNodes.Count);
        return ((Edge)adjacentNodes[index]).Node;
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
