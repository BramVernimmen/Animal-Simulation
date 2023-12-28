using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BB_Zebra : Blackboard
{
    

    public override string GetInfo()
    {
        return $"{base.GetInfo()} " +
            $"";
    }
}
