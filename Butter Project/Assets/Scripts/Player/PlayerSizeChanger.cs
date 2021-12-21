using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeChanger : MonoBehaviour
{
    [SerializeField] private Material _oilMaterial;
    [SerializeField] private PlayerCondition _playerCondition;

    private Vector3 _reductionSize;
    private string _clean = "clean";
    private string _painted = "painted";


    private void ChangeSize(int currentHealth, int amount)
    {
        if (amount < 0)
            Melt(currentHealth);
        else if (amount > 0)
            Grow();
    }

    private void Grow()
    {
        transform.localScale = new Vector3(1, 2, 1);
    }

    private void Melt(int currentHealth)
    {
        _reductionSize = new Vector3(0, transform.localScale.y / (currentHealth + 1), 0);
        transform.localScale -= _reductionSize;
        PaintFloor();

    }

    private void PaintFloor()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1))
        {
            if (hitInfo.collider.tag == _clean)
            {
                Renderer ground = hitInfo.collider.GetComponent<Renderer>();
                StartCoroutine(Paint(0.1f, ground));
            }
        }
    }

    private IEnumerator Paint(float duration, Renderer ground)
    {
        yield return new WaitForSeconds(duration);
        ground.material = _oilMaterial;
        ground.tag = _painted;
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
