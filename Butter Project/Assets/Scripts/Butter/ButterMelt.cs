using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ButterMelt : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Material _oilMaterial;

    private string _clean = "clean";
    private string _painted = "painted";
    private float _butterHight = 2f;
    private int _maxStep;
    private Vector3 _deltaH;


    private void Start()
    {
        _maxStep = _health.HealtCount;
        _deltaH = new Vector3(0, _butterHight / _maxStep, 0);
    }


    private void Melt(int healthByStep, Renderer kindOfGround)
    {
        transform.localScale -= _deltaH * healthByStep;

        if (kindOfGround.tag.Equals(_clean))
            StartCoroutine(PaintFloor(0.1f, kindOfGround));
    }


    private IEnumerator PaintFloor(float duration, Renderer ground)
    {
        yield return new WaitForSeconds(duration);
        ground.material = _oilMaterial;
        ground.tag = _painted;
    }


    private void OnEnable()
    {
        _health.HealtByStepNotify += Melt;
    }


    private void OnDisable()
    {
        _health.HealtByStepNotify -= Melt;
    }
}
