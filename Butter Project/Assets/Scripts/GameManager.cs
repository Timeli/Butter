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
    [SerializeField] private FinishGameScreen _finishGameScreen;

    private float _nextLevelZone = 10f;
    private float _deadZone = -15f;
    private bool _isActiveTeleport;

    private int _countScene; 

    private void Start()
    {
        _countScene = SceneManager.sceneCountInBuildSettings;
    }

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
        if (_countScene - 1 > scene.buildIndex)
        {
            int nextScene = scene.buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            _finishGameScreen.PanelAppear();
        }
            
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
        
}
