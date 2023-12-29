using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHerdArrived : ActionNode
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
            // if one has arrived, the others should have too
            // otherwise they are not close enough and need to move closer either way
            BB_Zebra bb = zebra.GetComponent<BB_Zebra>();
            totalPosition += zebra.transform.position;

            //float distance = Vector3.Distance(zebra.transform.position, bb.targetPostion);
            //if (distance <= 1.0f)
            //{
            //    return State.Success;
            //}
        }

        totalPosition /= zebraBlackboard.herd._zebraList.Count;
        totalPosition.y = 0.0f;

        if (Vector3.Distance(totalPosition, zebraBlackboard.targetPostion) <= 0.05f)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
