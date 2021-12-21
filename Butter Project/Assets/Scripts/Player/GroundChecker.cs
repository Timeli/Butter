using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerController _playerConroller;
    private float _rayLength = 1f;

    private readonly string _grinGround = "GreenGround";
    private readonly string _orangeGround = "OrangeGround";
    private readonly string _redGround = "RedGround";

    public event Action<int> GroundNotify;


    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, _rayLength))
        {
            int damage = DefineDamageByStep(hitInfo);
            GroundNotify?.Invoke(damage);
        }
    }

    private int DefineDamageByStep(RaycastHit hit)
    {
        int damage = 0;
        string groundName = hit.collider.name;

        if (groundName == _grinGround)
            damage = (int)KindOfGround.Green;
        else if (groundName == _orangeGround)
            damage = (int)KindOfGround.Orange;
        else if (groundName == _redGround)
            damage = (int)KindOfGround.Red;

        return damage;
    }

    private void OnEnable()
    {
        _playerConroller.StepNotify += CheckGround;
    }

    private void OnDisable()
    {
        _playerConroller.StepNotify -= CheckGround;
    }
}

public enum KindOfGround
{
    Green = -1,
    Orange = -2,
    Red = -3,
}