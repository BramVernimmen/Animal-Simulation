using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bbtest : Blackboard
{
    public string testString = new string("Test");

    public override string GetInfo()
    {
        return $"{base.GetInfo()} \n{testString}";
    }
}
