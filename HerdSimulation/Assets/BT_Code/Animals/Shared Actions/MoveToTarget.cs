using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Vector3 currentPosition = blackboard.animal.transform.position;
        if (Vector3.Distance(currentPosition, blackboard.targetPostion) < float.Epsilon) 
        {
            return State.Success;   
        }

        var step = blackboard.stats._currentSpeed * Time.deltaTime;
        blackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, blackboard.targetPostion, step);


        return State.Running;
    }
}
