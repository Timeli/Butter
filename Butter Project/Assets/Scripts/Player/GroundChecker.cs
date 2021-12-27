using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerController _playerConroller;
    
    [SerializeField] private Material _greenGround;
    [SerializeField] private Material _oilGreenGround;
    [SerializeField] private Material _orangeGround;
    [SerializeField] private Material _oilOrangeGround;
    [SerializeField] private Material _redGround;
    [SerializeField] private Material _oilRedGround;

    private int _greenDamage = -1;
    private int _orangeDamage = -2;
    private int _redDamage = -3;
    
    private float _rayLength = 1f;
    private GroundList _grounds;

    public event Action<int> GroundNotify;

    private void Start()
    {
        _grounds = new GroundList();
        _grounds.AddGround(new Ground(_greenGround, _greenDamage));
        _grounds.AddGround(new Ground(_oilGreenGround, _greenDamage));
        _grounds.AddGround(new Ground(_orangeGround, _orangeDamage));
        _grounds.AddGround(new Ground(_oilOrangeGround, _orangeDamage));
        _grounds.AddGround(new Ground(_redGround, _redDamage));
        _grounds.AddGround(new Ground(_oilRedGround, _redDamage));
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, _rayLength))
        {
            int damage = DefineDamageByStep(hitInfo);
            GroundNotify?.Invoke(damage);
        }
        else
        {
            _playerConroller.enabled = false;
        }
    }

    private int DefineDamageByStep(RaycastHit hit)
    {
        Renderer ground = hit.collider.GetComponent<Renderer>();
        int damage = _grounds.GetGroundDamage(ground.material);
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

