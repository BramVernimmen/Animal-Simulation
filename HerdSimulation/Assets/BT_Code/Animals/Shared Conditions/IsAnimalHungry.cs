using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAnimalHungry : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (blackboard.stats._isHungry)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
