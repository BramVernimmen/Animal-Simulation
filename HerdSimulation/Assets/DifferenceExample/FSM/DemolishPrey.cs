using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMC.Runtime;
using System;

[Serializable]
public class DemolishPrey : FSMC_Behaviour
{
    BB_Animal animalBlackboard;

    public override void StateInit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        animalBlackboard = executer.gameObject.GetComponent<BB_Animal>();
    }

    public override void OnStateEnter(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }

    public override void OnStateUpdate(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
        if (animalBlackboard.target == null) { return; }
        
        animalBlackboard.animal.transform.position = animalBlackboard.target.transform.position;
        UnityEngine.Object.Destroy(animalBlackboard.target.transform.parent.gameObject);
        animalBlackboard.target = null;
    }

    public override void OnStateExit(FSMC_Controller stateMachine, FSMC_Executer executer)
    {
    
    }
}