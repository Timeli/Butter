using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private PlayerAppearence _playerAppearence;
    [SerializeField] private GameObject _mainPanel;

    public void InitSceneLoad()
    {
        _mainPanel.SetActive(false);
        _playerAppearence.InitializePlayer();
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(2f);
        Scene scene = SceneManager.GetActiveScene();
        int nextScene = scene.buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame() => Application.Quit();
}
