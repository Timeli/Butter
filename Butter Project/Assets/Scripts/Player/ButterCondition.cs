using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class ButterCondition : MonoBehaviour
{
    private GroundChecker _groundChecker;
    public event Action<int> HealthChanged;

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
    }

    public void ChangeHealth(int amount)
    {
        HealthChanged?.Invoke(amount);
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
