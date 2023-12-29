using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCloseToHerdCenter : ActionNode
{
    BB_Zebra zebraBlackboard;
    protected override void OnStart()
    {
        zebraBlackboard = (blackboard as BB_Zebra);
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Vector3 totalPosition = new Vector3();

        foreach (GameObject zebra in zebraBlackboard.herd._zebraList)
        {
            BB_Zebra bb = zebra.GetComponent<BB_Zebra>();
            totalPosition += zebra.transform.position;
        }

        totalPosition /= zebraBlackboard.herd._zebraList.Count;
        totalPosition.y = 0.0f;

        zebraBlackboard.herd._herdCenter = totalPosition;

        if (Vector3.Distance(zebraBlackboard.animal.transform.position, totalPosition) <= 2.0f)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
