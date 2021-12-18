using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform _bridge;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);   
    }

    private void InitialBridge(float _duration)
    {

    }

    private IEnumerator MoveBridge()
}
