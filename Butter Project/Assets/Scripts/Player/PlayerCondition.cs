using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField][Range(15, 35)] private int _health;
    [SerializeField] private GroundChecker _groundChecker;

    public event Action<int, int> HealthChanged;

    private int PlayerHealth => _health;
    private Vector3 PlayerPosition => transform.position;


    public void ChangeHealth(int amount)
    {
        _health += amount;
        HealthChanged?.Invoke(_health, amount);
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
