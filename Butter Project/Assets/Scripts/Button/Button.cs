using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private BridgeController _bridgeController;

    private void OnTriggerEnter(Collider other)
    {
        _bridgeController.InitialCreateBridge();
    }
}
