using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChanger : MonoBehaviour
{
    [SerializeField] private GroundChecker _checker;
    [SerializeField] private Material[] _material;
    [SerializeField] private Material[] _oilMaterial;

    private void ChangeGround(Renderer ground)
    {
        for (int i = 0; i < _material.Length; i++)
            if (_material[i].color == ground.material.color)
                if (_oilMaterial[i] != null)
                    StartCoroutine(Paint(0.1f, ground, i));
                else
                    StartCoroutine(Destroy(1f, ground));
    }

    private IEnumerator Paint(float duration, Renderer ground, int numMaterial)
    {
        var dur = new WaitForSeconds(duration);
        yield return dur;
        ground.material = _oilMaterial[numMaterial];
    }

    private IEnumerator Destroy(float duration, Renderer ground)
    {
        var dur = new WaitForSeconds(duration);
        yield return dur;
        ground.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _checker.KindOfGround += ChangeGround;
    }

    private void OnDisable()
    {
        _checker.KindOfGround -= ChangeGround;
    }
}
