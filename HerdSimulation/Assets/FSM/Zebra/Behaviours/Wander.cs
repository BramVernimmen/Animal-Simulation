using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMC.Runtime;
using System;

[Serializable]
public class Wander : FSMC_Behaviour
{
    BB_Zebra zebraBlackboard;

    public override void StateInit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        zebraBlackboard = executer.gameObject.GetComponent<BB_Zebra>();
    }

    public override void OnStateEnter(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }

    public override void OnStateUpdate(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        // if too far from herd center -> get closer
        // else move towards the random herd target
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
            Vector3 currentPosition = zebraBlackboard.animal.transform.position;

            var step = zebraBlackboard.stats._currentSpeed * Time.deltaTime;
            zebraBlackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, zebraBlackboard.herd._herdTarget, step);
            zebraBlackboard.animal.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }

    public override void OnStateExit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }
}