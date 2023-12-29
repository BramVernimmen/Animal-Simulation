using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToClosestWater : ActionNode
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
        Vector3 herdPos = zebraBlackboard.herd.GetHerdCenter();

        Vector3 currentClosestPos = Vector3.zero;
        float currentDistance = float.MaxValue;

        foreach (GameObject water in zebraBlackboard.waterSpots)
        {
            float distance = Vector3.Distance(herdPos, water.transform.position);
            if (distance < currentDistance)
            {
                currentDistance = distance;
                currentClosestPos = water.transform.position;
            }
        }

        zebraBlackboard.targetPostion = currentClosestPos;

        return State.Success;
    }
}
