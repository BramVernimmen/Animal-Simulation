using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrey : ActionNode
{
    BB_Animal animalBlackboard;

    protected override void OnStart()
    {
        animalBlackboard = blackboard as BB_Animal;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (animalBlackboard.target == null) { return State.Success; }

        animalBlackboard.animal.transform.position = animalBlackboard.target.transform.position;
        Destroy(animalBlackboard.target.transform.parent.gameObject);
        animalBlackboard.target = null;

        return State.Success;
    }
}
