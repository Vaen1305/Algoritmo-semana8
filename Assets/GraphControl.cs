using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public GameObject nodePrefab;
    public TextAsset nodePositionTxt;
    public string[] arrayNodePosition;
    public string[] currentNodePostion;
    public List.SingleLinkedList<GameObject> allNodes;

    public TextAsset nodeConectionsTxt;
    public string[] arrayNodeConection;
    public string[] currentNodeConection;

    public PlayerMovement player;

    void Start()
    {
        CreateNodes();
        CreateConnections();
        SelectInitialNode();
    }

    void CreateNodes()
    {
        allNodes = new List.SingleLinkedList<GameObject>();
        if (nodePositionTxt != null)
        {
            arrayNodePosition = nodePositionTxt.text.Split('\n');
            for (int i = 0; i < arrayNodePosition.Length; ++i)
            {
                currentNodePostion = arrayNodePosition[i].Split(',');
                Vector2 position = new Vector2(float.Parse(currentNodePostion[0]), float.Parse(currentNodePostion[1]));
                GameObject tmp = Instantiate(nodePrefab, position, transform.rotation);
                allNodes.InsertAtEnd(tmp);
            }
        }
        allNodes.PrintAllNodes();
    }

    void CreateConnections()
    {
        if (nodeConectionsTxt != null)
        {
            arrayNodeConection = nodeConectionsTxt.text.Split('\n');
            for (int i = 0; i < arrayNodeConection.Length; ++i)
            {
                currentNodeConection = arrayNodeConection[i].Split(',');
                for (int j = 0; j < currentNodeConection.Length; j += 2)
                {
                    int adjacentIndex = int.Parse(currentNodeConection[j]);
                    float weight = float.Parse(currentNodeConection[j + 1]);
                    allNodes.GetElementAt(i).GetComponent<NodeController>().AddAdjacentNode(allNodes.GetElementAt(adjacentIndex).GetComponent<NodeController>(), weight);
                }
            }
        }
    }

    void SelectInitialNode()
    {
        int index = Random.Range(0, allNodes.Count);
        player.objetivo = allNodes.GetElementAt(index);
    }
}
