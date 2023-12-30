using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMC.Runtime;
using System;
using UnityEditor.Experimental.GraphView;

[Serializable]
public class MoveToCenter : FSMC_Behaviour
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
        Vector3 currentPosition = zebraBlackboard.animal.transform.position;

        var step = zebraBlackboard.stats._currentSpeed * Time.deltaTime;
        zebraBlackboard.animal.transform.position = Vector3.MoveTowards(currentPosition, zebraBlackboard.herd.GetHerdCenter(), step);
        zebraBlackboard.animal.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public override void OnStateExit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }
}