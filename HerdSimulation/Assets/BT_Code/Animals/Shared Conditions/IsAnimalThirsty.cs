using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAnimalThirsty : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (blackboard.stats._isThirsty)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
