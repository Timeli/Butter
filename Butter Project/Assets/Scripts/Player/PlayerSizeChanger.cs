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
    private int _growDuration = 60;

    private void ChangeSize(int currentHealth, int amount)
    {
        if (amount < 0)
            Melt(currentHealth); 
        else if (amount > 0)
            Grow();
    }

    private void Melt(int currentHealth)
    {
        _reductionSize = new Vector3(0, transform.localScale.y / (currentHealth + 1), 0);

        if (transform.localScale.y < _reductionSize.y)
            transform.localScale = new Vector3(1, 0, 1);
        else
            transform.localScale -= _reductionSize; 
        
        PaintFloor();
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
        yield return new WaitForSeconds(duration);
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
