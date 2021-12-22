using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    [SerializeField] private BridgeController _bridgeController;
    [SerializeField] private Transform _button;

    private float _pressingDepth = 0.08f;
    private bool _pressed;

    private void OnTriggerEnter(Collider other)
    {
        if (_pressed == false)
        {
            _bridgeController.InitialCreateBridge();
            Vector3 _pressedButtonPos = new Vector3(_button.position.x,
                                                    _button.position.y - _pressingDepth,
                                                    _button.position.z);
            _button.position = _pressedButtonPos;
            _pressed = true;
        }
    }
}
