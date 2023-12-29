using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
        blackboard.animal.GetComponent<Rigidbody>().velocity = Vector3.zero;

        return State.Running;
    }
}
