using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZebraHerd : MonoBehaviour
{
    public GameObject zebraPrefab;
    public int _amountToSpawn;
    public List<GameObject> _zebraList = new List<GameObject>();
    private List<GameObject> _grassFields = new List<GameObject>();
    private List<GameObject> _waterSpots = new List<GameObject>();

    void Start()
    {
        _grassFields =GameObject.FindGameObjectsWithTag("Grass").ToList();
        _waterSpots =GameObject.FindGameObjectsWithTag("Water").ToList();

        var bb = zebraPrefab.GetComponent<BB_Zebra>();
        bb.grassFields = _grassFields;
        bb.waterSpots = _waterSpots;
        bb.herd = this;
        bb.targetPostion = transform.position;

        for(int i = 0;  i < _amountToSpawn; i++) 
        {
            GameObject newZebra = Instantiate(zebraPrefab);
            Vector3 basePosition = transform.position;
            
            float angle = i * 2 * Mathf.PI / _amountToSpawn;

            float xOffset = Mathf.Cos(angle) * 3.0f;
            float zOffset = Mathf.Sin(angle) * 3.0f;

            basePosition.x += xOffset;
            basePosition.z += zOffset;

            newZebra.transform.position = basePosition;
            _zebraList.Add(newZebra);
        }
    }

    void Update()
    {
        // very dirty for now
        foreach (GameObject zebra in  _zebraList) 
        { 
            if (zebra.GetComponent<BaseAnimalStats>()._currentHealth <= 0)
            {
                _zebraList.Remove(zebra);
                return;
            }
        }
    }

    public Vector3 GetHerdCenter()
    {
        Vector3 center = Vector3.zero;

        foreach (GameObject zebra in _zebraList)
        {
            BB_Zebra bb = zebra.GetComponent<BB_Zebra>();
            center += zebra.transform.position;
        }

        center /= _zebraList.Count;
        center.y = 0.0f;

        return center;
    }
}
