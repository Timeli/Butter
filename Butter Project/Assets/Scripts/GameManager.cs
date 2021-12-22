using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerCondition _player;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private TeleportationFrom _teleportationFrom;

    private float _nextLevelZone = 10f;
    private float _deadZone = -15f;
    private bool _isActiveTeleport;
   
    private void FixedUpdate()
    {
        WatchPlayer();
    }

    private void WatchPlayer()
    {
        if (_player.Health <= 0 || _player.Position.y <= _deadZone)
        {
            ManageAfterDied();
        }
        if (_teleportationFrom.IsReached && _isActiveTeleport == false)
        {
            _teleportationFrom.MoveToNextLevel(_nextLevelZone);
            _isActiveTeleport = true;
        }
    }

    private void ManageAfterDied()
    {
        _endGameScreen.PanelAppear();
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
        
}
