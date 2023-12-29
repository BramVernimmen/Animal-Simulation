using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenterOfHerd : ActionNode
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
        Vector3 currentPosition = zebraBlackboard.animal.transform.position;
        if (Vector3.Distance(currentPosition, zebraBlackboard.herd._herdCenter) < float.Epsilon)
        {
            return State.Success;
        }

        var step = zebraBlackboard.stats._currentSpeed * Time.deltaTime;
        zebraBlackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, zebraBlackboard.herd._herdCenter, step);


        return State.Running;
    }
}
