using FSMC.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PreyChecker : MonoBehaviour
{
    public FSMC_Executer _executer;
    public BB_Animal animalBlackboard;
    public int radius;

    void Update()
    {
        //Collider[] hitColliders = Physics.OverlapSphere(animalBlackboard.animal.transform.position, radius);
        //if (hitColliders.Length > 1) // another collider is close
        //{
        //    animalBlackboard.target = hitColliders[0].gameObject; // cache the overlapping target
        //    _executer.SetTrigger("PreyNearby");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        animalBlackboard.target = other.gameObject;
        _executer.SetBool("IsPreyNearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animalBlackboard.target = null;
        _executer.SetBool("IsPreyNearby", false);
    }
}
