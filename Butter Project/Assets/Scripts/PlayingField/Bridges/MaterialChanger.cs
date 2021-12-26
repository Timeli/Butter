using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Transform _replacementBlocks;
    [SerializeField] private Material _replacementMaterial;
    
    private float _duration = 0.08f;
    private Renderer _renderer;

    public void InitialChangeMaterial()
    {
        StartCoroutine(ChangeMaterial(_duration));
    }

    private IEnumerator ChangeMaterial(float duration)
    {
        var dur = new WaitForSeconds(duration);
        for (int i = 0; i < _replacementBlocks.childCount; i++)
        {
            _renderer = _replacementBlocks.GetChild(i).GetComponent<Renderer>();
            _renderer.material = _replacementMaterial;
            yield return dur;
        }
    }
}
