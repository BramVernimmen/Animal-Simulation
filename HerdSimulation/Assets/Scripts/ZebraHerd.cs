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
            newZebra.transform.position = transform.position;
            _zebraList.Add(newZebra);
        }
    }

    void Update()
    {
        
    }
}
