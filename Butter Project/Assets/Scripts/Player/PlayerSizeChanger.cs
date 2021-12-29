using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeChanger : MonoBehaviour
{
    [SerializeField] private PlayerCondition _playerCondition;

    private Vector3 _reductionSize;
    private float _startHeight = 2f;
    private int _growDuration = 30;

    private void Start()
    {
        _reductionSize = new Vector3(0, _startHeight / _playerCondition.Health, 0);
    }

    private void ChangeSize(int amount)
    {
        if (amount <= 0)
            InitialMelt(amount); 
        else if (amount > 0)
            Grow();
    }

    private void InitialMelt(int amount) => StartCoroutine(Melt(amount));
    private void Grow() => StartCoroutine(GrowUp(_growDuration));
        
    private IEnumerator Melt(int amount)
    {
        var size = new Vector3(0, _reductionSize.y * -amount, 0) / 30;
        for (int i = 0; i < 30; i++)
        {
            if (_playerCondition.Health <= 0)
                transform.localScale = new Vector3(1, 0, 1);
            else
                transform.localScale -= size;
            yield return null;
        }
    }

    private IEnumerator GrowUp(int duration)
    {
        float deltaScaleY = (_startHeight - transform.localScale.y) / duration; 

        for (int i = 0; i < duration; i++)
        {
            transform.localScale = new Vector3(1, transform.localScale.y + deltaScaleY, 1);
            yield return null;
        }
    }


    private void OnEnable()
    {
        _playerCondition.HealthChanged += ChangeSize;
    }

    private void OnDisable()
    {
        _playerCondition.HealthChanged -= ChangeSize;
    }
}
