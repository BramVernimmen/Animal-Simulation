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
        if (Vector3.Distance(zebraBlackboard.animal.transform.position, zebraBlackboard.herd.GetHerdCenter()) <= zebraBlackboard.herd._zebraList.Count / 2)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
