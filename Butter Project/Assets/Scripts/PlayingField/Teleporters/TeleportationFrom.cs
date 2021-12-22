using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationFrom : MonoBehaviour
{
    private bool _isReached;
    public bool IsReached => _isReached;

    private void OnCollisionEnter(Collision collision)
    {
        _isReached = true;
    }


    public void MoveToNextLevel()
    {
        print("Move");
    }
}
