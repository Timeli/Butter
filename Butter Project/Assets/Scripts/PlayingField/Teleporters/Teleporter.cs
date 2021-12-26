using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _teleporterIn;
    [SerializeField] private Transform _teleporterOutPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = _teleporterOutPoint.position;
    }
}
