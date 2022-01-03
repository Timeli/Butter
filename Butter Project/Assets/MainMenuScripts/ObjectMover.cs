using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 _current;
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _randomSpeed;

    private float _minSpeed = 0.1f;
    private float _maxSpeed = 0.5f;

    private Vector3[] targets = { 
        Vector3.up, Vector3.down, 
        Vector3.left, Vector3.right, 
        Vector3.forward, Vector3.back
    };

    private void Start()
    {
        _current = transform.position;
        _randomSpeed = Random.Range(_minSpeed, _maxSpeed);
        _target = transform.position + targets[Random.Range(0, targets.Length)] * Random.Range(1, 3);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position != _target)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _randomSpeed * Time.fixedDeltaTime);
        }
        else
        {
            _target = _current;
            _current = transform.position;
        }
    }
}

