using FSMC.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZebraHerd : MonoBehaviour
{
    public GameObject zebraPrefab;
    public int _amountToSpawn;
    public bool _useFSM;
    public List<GameObject> _zebraList = new List<GameObject>();
    private List<GameObject> _grassFields = new List<GameObject>();
    private List<GameObject> _waterSpots = new List<GameObject>();
    private Vector3 _herdCenter;
    public Vector3 _herdTarget;
    public Vector2 _herdTargetRangeX;
    public Vector2 _herdTargetRangeZ;

    void Start()
    {
        _grassFields =GameObject.FindGameObjectsWithTag("Grass").ToList();
        _waterSpots =GameObject.FindGameObjectsWithTag("Water").ToList();

        var bb = zebraPrefab.GetComponent<BB_Zebra>();
        bb.grassFields = _grassFields;
        bb.waterSpots = _waterSpots;
        bb.herd = this;
        bb.targetPostion = transform.position;

        if (_useFSM)
        {
            zebraPrefab.GetComponent<FSMC_Executer>().enabled = true;
            zebraPrefab.GetComponent<BehaviourTreeRunner>().enabled = false;
        }
        else
        {
            zebraPrefab.GetComponent<BehaviourTreeRunner>().enabled = true;
            zebraPrefab.GetComponent<FSMC_Executer>().enabled = false;
        }

        for (int i = 0;  i < _amountToSpawn; i++) 
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

        RandomizeTarget();
        StartCoroutine(ChangeTarget());
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

        RecalculateHerdCenter();
    }

    public Vector3 GetHerdCenter()
    {
        return _herdCenter;
    }

    void RecalculateHerdCenter()
    {
        Vector3 center = Vector3.zero;

        foreach (GameObject zebra in _zebraList)
        {
            BB_Zebra bb = zebra.GetComponent<BB_Zebra>();
            center += zebra.transform.position;
        }

        center /= _zebraList.Count;
        center.y = 0.0f;

        _herdCenter = center;
    }

    IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(5.0f);

        RandomizeTarget();

        StartCoroutine(ChangeTarget());
    }

    void RandomizeTarget()
    {
        _herdTarget.x = Random.Range(_herdTargetRangeX.x, _herdTargetRangeX.y);
        _herdTarget.z = Random.Range(_herdTargetRangeZ.x, _herdTargetRangeZ.y);
    }
}
