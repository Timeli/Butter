using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedButton : MonoBehaviour
{
    [SerializeField] private Transform _button;

    public UnityEvent OnButtonPressed;

    private float _pressingDepth = 0.08f;
    private bool _pressed;

    private void OnTriggerEnter(Collider other)
    {
        if (_pressed == false)
        {
            OnButtonPressed?.Invoke();
            Vector3 _pressedButtonPos = new Vector3(_button.position.x,
                                                    _button.position.y - _pressingDepth,
                                                    _button.position.z);
            _button.position = _pressedButtonPos;
            _pressed = true;
        }
    }


}
