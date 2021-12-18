using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ButterMelt : MonoBehaviour
{
    [SerializeField] private ButterControl _butterControl;
    [SerializeField] private Material _oilMaterial;
    [SerializeField] [Range(1, 30)] private int _maxStep;

    private Renderer _blockRenderer;
    private string _clean = "clean";
    private string _painted = "painted";
    private float _butterHight = 2f;
    private Vector3 _deltaH;


    private void Start()
    {

        _deltaH = new Vector3(0, _butterHight / _maxStep, 0);
    }


    private void PaintFloor()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1))
        {
            if (hitInfo.collider.tag.Equals(_clean))
            {
                _blockRenderer = hitInfo.collider.GetComponent<Renderer>();
                StartCoroutine(Paint(0.1f));
                Melt();
                hitInfo.collider.tag = _painted;
            }
        }
    }


    private void Melt()
    {
        transform.localScale -= _deltaH;
    }


    private IEnumerator Paint(float duration)
    {
        yield return new WaitForSeconds(duration);
        _blockRenderer.material = _oilMaterial;
    }


    private void OnEnable()
    {
        _butterControl.Onender += PaintFloor;
    }

    private void OnDisable()
    {
        _butterControl.Onender -= PaintFloor;
    }
}
