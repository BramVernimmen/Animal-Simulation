using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimalStats : MonoBehaviour
{
    public int _maxHealth;
    public int _health;
    public float _hunger;
    public float _hungerTick;
    public float _thirst;
    public float _thirstTick;
    public float _maxSpeed;
    public float _minSpeed;
    public float _currentSpeed;

    void Start()
    {
        _health = _maxHealth;
    }

    void Update()
    {
        _hunger = Mathf.Clamp(_hunger - _hungerTick * Time.deltaTime, 0.0f, 100000.0f);
        if (_hunger <= 0)
        {
            Debug.Log("hungry");
        }

        _thirst = Mathf.Clamp(_thirst - _thirstTick * Time.deltaTime, 0.0f, 100000.0f);
        if (_thirst <= 0)
        {
            Debug.Log("thirsty");
        }
    }
}
