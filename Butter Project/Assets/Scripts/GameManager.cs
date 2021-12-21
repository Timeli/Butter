using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerCondition _player;
    [SerializeField] private Transform _finish;
   
    private void FixedUpdate()
    {
        WatchPlayer();
    }

    private void WatchPlayer()
    {
        if (_player.Health <= 0)
        {
            Debug.Log("GameOver");
        }
        if (_player.Position.x == _finish.position.x &&
            _player.Position.z == _finish.position.z)
        {
            Debug.Log("Finish");
        }
    }

}
