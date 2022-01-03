using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearence : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private float _divider = 50;

    public void InitializePlayer()
    {
        StartCoroutine(PlayerChangeSize());
    }

    private IEnumerator PlayerChangeSize()
    {
        for (int i = 0; i < _divider; i++)
        {
            _playerTransform.localScale = new Vector3(
             _playerTransform.localScale.x + 0.02f,
             _playerTransform.localScale.y + 0.04f,
             _playerTransform.localScale.z + 0.02f);
            yield return null;
        }
    }
}
