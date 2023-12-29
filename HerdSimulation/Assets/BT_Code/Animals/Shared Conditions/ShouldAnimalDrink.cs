using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldAnimalDrink : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (blackboard.stats._hunger <= 10.0f || !blackboard.stats._isHungry)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
