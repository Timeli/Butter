using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ButterCondition))]
public class ButterSizeChanger : MonoBehaviour
{
    private ButterCondition _butterCondition;

    private void Awake()
    {
        _butterCondition = GetComponent<ButterCondition>();
    }

    private void ChangeSize(int amount)
    {

    }

    private void OnEnable()
    {
        _butterCondition.HealthChanged += ChangeSize;
    }

    private void OnDisable()
    {
        _butterCondition.HealthChanged -= ChangeSize;
    }
}
