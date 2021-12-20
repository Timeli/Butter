using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class ButterCondition : MonoBehaviour
{
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void ChangeHealth()
    {

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
