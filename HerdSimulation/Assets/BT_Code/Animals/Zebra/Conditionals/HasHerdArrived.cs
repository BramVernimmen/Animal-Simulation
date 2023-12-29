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
        if (Vector3.Distance(zebraBlackboard.herd.GetHerdCenter(), zebraBlackboard.targetPostion) <= 2.0f)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
