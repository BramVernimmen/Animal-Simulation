using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
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
            stats._isEating = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<BB_Zebra>()) // we have a zebra
        {
            BaseAnimalStats stats = other.gameObject.GetComponentInParent<BaseAnimalStats>();
            stats._hunger -= Time.deltaTime * _nutritionValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<BB_Zebra>()) // we have a zebra
        {
            BaseAnimalStats stats = other.gameObject.GetComponentInParent<BaseAnimalStats>();
            stats._isEating = false;
        }
    }
}
