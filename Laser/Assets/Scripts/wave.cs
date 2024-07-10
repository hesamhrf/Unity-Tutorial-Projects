using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class wave : ScriptableObject
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform pathPrefab;

    public float GetSpeed()
    {
        return speed;
    }

    public Transform GetFirstNode()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaveNodes()
    {
        List<Transform> nodesList = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            nodesList.Add(child);
        }
        return nodesList;
    }
}
