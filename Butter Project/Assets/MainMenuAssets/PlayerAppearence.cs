using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearence : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private int _divisor = 60;
    private float _sizeX = 1f;
    private float _sizeY = 2f;
    private float _sizeZ = 1f;

    private void Start()
    {
        _playerTransform.gameObject.SetActive(false);
    }

    public void InitializePlayer()
    {
        _playerTransform.gameObject.SetActive(true);
        StartCoroutine(PlayerChangeSize());
    }

    private IEnumerator PlayerChangeSize()
    {
        float deltaX = _sizeX / _divisor;
        float deltaY = _sizeY / _divisor;
        float deltaZ = _sizeZ / _divisor;

        while (_playerTransform.localScale.x < _sizeX)
        {
            _playerTransform.localScale = new Vector3(
            _playerTransform.localScale.x + deltaX,
            _playerTransform.localScale.y + deltaY,
            _playerTransform.localScale.z + deltaZ);

            yield return null;
        }
    }
}
