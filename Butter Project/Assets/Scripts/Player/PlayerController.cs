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

    private void MoveButter(Vector3 pointer)
    {
        if (_isMove == false && pointer != Vector3.zero)
        {
            _isMove = true;
            Vector3 direction = Vector3.zero;

            if (pointer == Vector3.left)        //A (🡬)
                direction = Vector3.back;
            else if (pointer == Vector3.right)  //S (🡯)
                direction = Vector3.forward;
            else if (pointer == Vector3.up)     //W (🡭)
                direction = Vector3.left;
            else if (pointer == Vector3.down)   //D (🡮)
                direction = Vector3.right;

            StartCoroutine(Move(_duration, direction));
        }
    }

    private IEnumerator Move(float duration, Vector3 direction)
    {
        Vector3 point = transform.position + direction;
        var dur = new WaitForSeconds(duration);

        while (transform.position != point)
        {
            //if the step is larger than the standard block(1f),
            //it means the teleport used
            if ((transform.position - point).magnitude > 1.1f)
                break;

            transform.position = Vector3.MoveTowards(transform.position, point,
                                                     _speed * Time.fixedDeltaTime);
            yield return dur;
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
