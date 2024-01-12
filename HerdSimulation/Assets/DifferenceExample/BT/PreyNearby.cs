using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyNearby : ActionNode
{
    BB_Animal animalBlackboard;
    public int radius;

    protected override void OnStart()
    {
        animalBlackboard = blackboard as BB_Animal;
    }

    protected override void OnStop()
    {
    }

    //protected override State OnUpdate()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(animalBlackboard.animal.transform.position, radius);
    //    if (hitColliders.Length > 1) // another collider is close
    //    {
    //        animalBlackboard.target = hitColliders[0].gameObject; // cache the overlapping target
    //        return State.Success;
    //    }
    //
    //    return State.Failure;
    //}
    protected override State OnUpdate()
    {
        if (animalBlackboard.target != null) 
        {
            return State.Success;
        }

        return State.Failure;
    }
}
