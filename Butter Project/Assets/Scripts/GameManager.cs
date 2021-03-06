using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerCondition _player;
    [SerializeField] private ScreenEffects _screenEffects;
    [SerializeField] private MovingFrom _movingFrom;
    [SerializeField] private ExitAndRepeatPanel _exitAndRepeatPanel;

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
        if (_movingFrom.IsReached && _isActiveTeleport == false)
        {
            _movingFrom.MoveToNextLevel(_nextLevelZone);
            _isActiveTeleport = true;
            _screenEffects.InitialDimmingScreen();

        }
        if (_player.Position.y >= _nextLevelZone)
        {
            NextLevelLoad();
        }

    }

    private void ManageAfterDied()
    {
        _exitAndRepeatPanel.PanelAppear();
        Time.timeScale = 0;
    }

    private void NextLevelLoad()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextScene = scene.buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
        
}
