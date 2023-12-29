using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float _nutritionValue;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<BB_Zebra>()) // we have a zebra
        {
            BaseAnimalStats stats = other.gameObject.GetComponentInParent<BaseAnimalStats>();
            stats._isDrinking = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<BB_Zebra>()) // we have a zebra
        {
            BaseAnimalStats stats = other.gameObject.GetComponentInParent<BaseAnimalStats>();
            stats._thirst -= Time.deltaTime * _nutritionValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<BB_Zebra>()) // we have a zebra
        {
            BaseAnimalStats stats = other.gameObject.GetComponentInParent<BaseAnimalStats>();
            stats._isDrinking = false ;
        }
    }
}
