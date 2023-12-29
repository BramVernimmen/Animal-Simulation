using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfHerdAsTarget : ActionNode
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
        Vector3 herdCenter = zebraBlackboard.herd.GetHerdCenter();

        zebraBlackboard.targetPostion = herdCenter;

        return State.Success;
    }
}
