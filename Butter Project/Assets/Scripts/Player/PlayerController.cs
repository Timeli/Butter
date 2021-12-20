using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GeneralControl _control;
    public event Action StepNotify;

    private float _duration = 0.01f;
    private bool _isMove;


    private void Awake()
    {
        _control = new GeneralControl();
    }

    private void FixedUpdate()
    {
        var pointer = _control.Butter.Move.ReadValue<Vector2>();
        MoveButter(pointer);
    }

    private void MoveButter(Vector3 route)
    {
        if (_isMove == false && route != Vector3.zero)
        {
            _isMove = true;
            Vector3 direction = Vector3.zero;

            if (route == Vector3.left)        //вверх влево
                direction = Vector3.back;
            else if (route == Vector3.right)  //вниз вправо
                direction = Vector3.forward;
            else if (route == Vector3.up)     //вверх вправо
                direction = Vector3.left;
            else if (route == Vector3.down)   //вниз влево
                direction = Vector3.right;

            StartCoroutine(Move(_duration, direction));

        }
    }

    private IEnumerator Move(float dur, Vector3 direction)
    {
        Vector3 point = transform.position + direction;
        var duration = new WaitForSeconds(dur);

        while (transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position, point,
                                                     _speed * Time.fixedDeltaTime);
            yield return duration;
        }
        StepNotify?.Invoke();
        _isMove = false;
    }

    private void OnEnable()
    {
        _control.Enable();
    }

    private void OnDisable()
    {
        _control.Disable();
    }
}
