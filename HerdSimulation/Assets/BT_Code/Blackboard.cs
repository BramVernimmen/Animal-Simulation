using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Blackboard : MonoBehaviour
{
    public Vector3 moveToPos;
    public GameObject moveToObject;

    public virtual string GetInfo()
    {
        return $"Move to pos: x: {moveToPos.x}, y: {moveToPos.y}, z: {moveToPos.z}";
    }
}
