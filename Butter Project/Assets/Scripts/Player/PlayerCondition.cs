using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField][Range(15, 35)] private int _startHealth;
    [SerializeField] private GroundChecker _groundChecker;

    public event Action<int, int> HealthChanged;
    private int _currentHealth;

    public int Health => _currentHealth;
    public Vector3 Position => transform.position;


    private void Start()
    {
        _currentHealth = _startHealth + 1;
    }

    public void ChangeHealth(int amount)
    {
        print(_currentHealth);
        if (amount < 0) 
            _currentHealth += amount;
        else if (amount > 0)
            _currentHealth = _startHealth + 1;

        HealthChanged?.Invoke(_currentHealth, amount);
    }

    private void OnEnable()
    {
        _groundChecker.GroundNotify += ChangeHealth;
    }

    private void OnDisable()
    {
        _groundChecker.GroundNotify -= ChangeHealth;
    }
}
