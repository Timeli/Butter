using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerCondition _player;
    [SerializeField] private Transform _finish;
    [SerializeField] private EndGameScreen _endGameScreen;
   
    private void FixedUpdate()
    {
        WatchPlayer();
    }

    private void WatchPlayer()
    {
        if (_player.Health <= 0)
        {
            ManageAfterDied();
        }
        if (_player.Position.x == _finish.position.x &&
            _player.Position.z == _finish.position.z)
        {
            Debug.Log("Finish");
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
    }

    public void QuitGame() => Application.Quit();
        
}
