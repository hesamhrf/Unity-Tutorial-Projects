using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PahFinder : MonoBehaviour
{

    [SerializeField] wave Wave;
    List<Transform> NodeList;
    int currentNodeIndex = 0;
    void Start()
    {
        NodeList = Wave.GetWaveNodes();
        transform.position = Wave.GetFirstNode().position;
    }


    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (currentNodeIndex < NodeList.Count)
        {
            Vector3 targetPosition = NodeList[currentNodeIndex].position;
            float delta = Wave.GetSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            Debug.Log(transform.position);
            Debug.Log(targetPosition);
            if (transform.position == targetPosition)
            {
                currentNodeIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
