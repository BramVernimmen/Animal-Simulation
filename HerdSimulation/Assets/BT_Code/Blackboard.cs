using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Blackboard : MonoBehaviour
{
    public GameObject animal;
    public BaseAnimalStats stats;
    public Vector3 targetPostion;

    public virtual string GetInfo()
    {
        return $"targetPosition: {targetPostion} \n";
    }
}
