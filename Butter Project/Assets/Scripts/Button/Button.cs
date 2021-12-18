using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform _startPointToBridge;
    [SerializeField] private Transform _endPointToBridge;

    private Vector3 _deltaPosition;
    private int _bridgeSpeed = 120;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 length = _startPointToBridge.position - _endPointToBridge.position;
        _deltaPosition = length / _bridgeSpeed;
        InitialCreateBridge();
    }


    private void InitialCreateBridge()
    {
        StartCoroutine(CreateBridge());
    }


    private IEnumerator CreateBridge()
    {
        for (int i = 0; i < _bridgeSpeed; i++)
        {
            _startPointToBridge.position -= _deltaPosition;
            yield return null;
        }
    }
}
