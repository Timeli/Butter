using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private int _healthPoint = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCondition player))
        {
            player.ChangeHealth(_healthPoint); 
            gameObject.SetActive(false);
        }
    }
}
