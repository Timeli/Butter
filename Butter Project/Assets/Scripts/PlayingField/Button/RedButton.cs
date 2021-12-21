using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    [SerializeField] private BridgeController _bridgeController;
    private Vector3 _pressingDepth = new Vector3(0, 0.10f, 0);

    private void OnTriggerEnter(Collider other)
    {
        _bridgeController.InitialCreateBridge();
        transform.position -= _pressingDepth;
    }
}
