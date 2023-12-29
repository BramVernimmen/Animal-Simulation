using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimalStats : MonoBehaviour
{
    public int _maxHealth;
    public float _currentHealth;
    public float _hunger;
    public float _hungerTick;
    public float _thirst;
    public float _thirstTick;
    public float _maxSpeed;
    public float _minSpeed;
    public float _currentSpeed;
    public float _starveStrength;
    public float _healStrength;

    public bool _isHungry;
    public bool _isThirsty;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        _hunger = Mathf.Clamp(_hunger + _hungerTick * Time.deltaTime, 0.0f, 100.0f);
        if (_hunger >= 80.0f)
        {
            _isHungry = true;
        }
        else
        {
            _isHungry = false;
        }

        _thirst = Mathf.Clamp(_thirst + _thirstTick * Time.deltaTime, 0.0f, 100.0f);
        if (_thirst >= 80.0f)
        {
            _isThirsty = true;
        }
        else 
        { 
            _isThirsty = false; 
        }


        if (_isHungry)
        {
            _currentHealth -= _starveStrength * Time.deltaTime;
        }
        if (_isThirsty)
        {
            _currentHealth -= _starveStrength * Time.deltaTime;
        }

        if (_currentHealth < _maxHealth && !_isHungry && !_isThirsty && _currentHealth > 0.0f)
        {
            _currentHealth += _healStrength * Time.deltaTime;
        }
    }
}
