using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BB_Zebra : Blackboard
{
    public List<GameObject> grassFields = new List<GameObject>();
    public List<GameObject> waterSpots = new List<GameObject>();
    public ZebraHerd herd;

    public override string GetInfo()
    {
        return $"{base.GetInfo()} " +
            $"";
    }
}
