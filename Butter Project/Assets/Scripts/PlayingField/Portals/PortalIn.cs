using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIn : MonoBehaviour
{
    [SerializeField] private Transform _teleporterOutPoint;
    private Vector3 _offset;

    private void OnTriggerEnter(Collider other)
    {
        _offset = new Vector3(0, other.transform.localScale.y / 2, 0);
        other.transform.position = _teleporterOutPoint.position + _offset;
    }
}
