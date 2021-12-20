using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private Transform _bridgeStartPoint;
    [SerializeField] private Transform _bridgeEndPoint;

    private int _bridgeMoveSpeed = 120;


    public void InitialCreateBridge()
    {
        StartCoroutine(CreateBridge());
    }

    private IEnumerator CreateBridge()
    {
        Vector3 length = _bridgeStartPoint.position - _bridgeEndPoint.position;
        Vector3 _deltaPosition = length / _bridgeMoveSpeed;

        for (int i = 0; i < _bridgeMoveSpeed; i++)
        {
            _bridgeStartPoint.position -= _deltaPosition;
            yield return null;
        }
    }
}
