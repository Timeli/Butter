using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private ButterCondition _butterCondition;
    private int _playerHealth;

    public int PlayerHealth => _playerHealth;
    public Vector3 PlayerPosition => transform.position;


    private void Awake()
    {
        _butterCondition = GetComponent<ButterCondition>();
    }

    private void ChangeHealth(int amount)
    {
        _playerHealth += amount;
    }

    private void OnEnable()
    {
        _butterCondition.HealthChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        _butterCondition.HealthChanged -= ChangeHealth;
    }
}
