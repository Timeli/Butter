using System.Collections;
using UnityEngine;


public delegate void Sender();
public class ButterControl : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GeneralControl _control;
    private bool _isMove;

    public event Sender Onender;

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
        if (route != Vector3.zero && _isMove == false)
        {
            _isMove = true;
            Vector3 direction = Vector3.zero;

            if (route == Vector3.left)        //����� �����
                direction = Vector3.back;
            else if (route == Vector3.right)  //���� ������
                direction = Vector3.forward;
            else if (route == Vector3.up)     //����� ������
                direction = Vector3.left;
            else if (route == Vector3.down)   //���� �����
                direction = Vector3.right;

            StartCoroutine(Move(0.01f, direction));
        }
    }

    private IEnumerator Move(float dur, Vector3 vector)
    {
        var point = transform.position + vector;
        var duration = new WaitForSeconds(dur);

        while (transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position, point,
                                                     _speed * Time.fixedDeltaTime);
            yield return duration;
        }
        Onender?.Invoke();
        _isMove = false;
    }


    private void OnEnable()
    {
        _control.Butter.Enable();
    }

    private void OnDisable()
    {
        _control.Butter.Disable();
    }
}
