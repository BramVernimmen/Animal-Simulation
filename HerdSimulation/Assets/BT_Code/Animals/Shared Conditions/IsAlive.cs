using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlive : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (blackboard.stats._currentHealth <= 0)
            return State.Failure; 

        return State.Success;
    }
}
