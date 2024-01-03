using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHerdTargetAsTarget : ActionNode
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
        zebraBlackboard.targetPostion = zebraBlackboard.herd._herdTarget;

        return State.Success;
    }
}
