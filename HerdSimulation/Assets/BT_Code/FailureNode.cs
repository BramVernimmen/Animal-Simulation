using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureNode : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        blackboard.moveToPos.x += 1;
        return State.Failure;
    }
}
