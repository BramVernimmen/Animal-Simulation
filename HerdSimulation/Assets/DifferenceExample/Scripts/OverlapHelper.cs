using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapHelper : MonoBehaviour
{
    public BB_Animal blackboard;

    private void OnTriggerEnter(Collider other)
    {
        blackboard.target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        blackboard.target = null;
    }

}
