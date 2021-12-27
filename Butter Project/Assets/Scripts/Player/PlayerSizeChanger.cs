using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeChanger : MonoBehaviour
{
    [SerializeField] private PlayerCondition _playerCondition;
    [SerializeField] private Material[] _material;
    [SerializeField] private Material[] _oilMaterial;

    private Vector3 _reductionSize;
    private float _startHeight = 2f;
    private int _growDuration = 30;

    private void Start()
    {
        _reductionSize = new Vector3(0, _startHeight / _playerCondition.Health, 0);
    }

    private void ChangeSize(int amount)
    {
        if (amount < 0)
            InitialMelt(amount); 
        else if (amount > 0)
            Grow();
    }

    private void InitialMelt(int amount)
    {
        StartCoroutine(Melt(amount));
        PaintFloor();
    }

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

    private void Grow()
    {
        StartCoroutine(GrowUp(_growDuration));
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

    private void PaintFloor()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1))
        {
            Renderer ground = hitInfo.collider.GetComponent<Renderer>();
            
            for (int i = 0; i < _material.Length; i++)
                if (_material[i].color == ground.material.color)
                    StartCoroutine(Paint(0.1f, ground, i));
        }
    }

    private IEnumerator Paint(float duration, Renderer ground, int numMaterial)
    {
        var dur = new WaitForSeconds(duration);
        yield return dur;
        ground.material = _oilMaterial[numMaterial];
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
