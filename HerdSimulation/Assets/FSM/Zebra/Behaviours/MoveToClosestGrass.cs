using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMC.Runtime;
using System;

[Serializable]
public class MoveToClosestGrass : FSMC_Behaviour
{
    BB_Zebra zebraBlackboard;
    private Vector3 closestPos;

    public override void StateInit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        zebraBlackboard = executer.gameObject.GetComponent<BB_Zebra>();
    }

    public override void OnStateEnter(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        Vector3 herdCenter = zebraBlackboard.herd.GetHerdCenter();
        if (Vector3.Distance(zebraBlackboard.animal.transform.position, herdCenter) > zebraBlackboard.herd._zebraList.Count / 2)
        {
            Vector3 currentPosition = zebraBlackboard.animal.transform.position;

            var step = zebraBlackboard.stats._currentSpeed * Time.deltaTime;
            zebraBlackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, herdCenter, step);
            zebraBlackboard.animal.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            Vector3 herdPos = zebraBlackboard.herd.GetHerdCenter();

            Vector3 currentClosestPos = Vector3.zero;
            float currentDistance = float.MaxValue;

            foreach (GameObject grass in zebraBlackboard.grassFields)
            {
                float distance = Vector3.Distance(herdPos, grass.transform.position);
                if (distance < currentDistance)
                {
                    currentDistance = distance;
                    currentClosestPos = grass.transform.position;
                }
            }

            closestPos = currentClosestPos;
        }
    }

    public override void OnStateUpdate(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        Vector3 currentPosition = zebraBlackboard.animal.transform.position;

        var step = zebraBlackboard.stats._currentSpeed * Time.deltaTime;
        zebraBlackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, closestPos, step);
        zebraBlackboard.animal.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public override void OnStateExit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }
}