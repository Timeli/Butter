using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ButterMelt : MonoBehaviour
{
    [SerializeField] private Player _health;
    [SerializeField] private Material _oilMaterial;

    private string _clean = "clean";
    private string _painted = "painted";


    private void Melt(int currentHealth, Renderer ground)
    {
        transform.localScale -= HealthByStepCalculate(currentHealth);

        if (ground.tag.Equals(_clean))
            StartCoroutine(PaintFloor(0.1f, ground));
    }

    private IEnumerator PaintFloor(float duration, Renderer ground)
    {
        yield return new WaitForSeconds(duration);
        ground.material = _oilMaterial;
        ground.tag = _painted;
    }

    private Vector3 HealthByStepCalculate(int currentHealth)
    {
        Vector3 _deltaH = new Vector3(0, transform.localScale.y / currentHealth, 0);
        return _deltaH;
    }

    private void OnEnable()
    {
        _health.HealthAndGroundNotify += Melt;
    }

    private void OnDisable()
    {
        _health.HealthAndGroundNotify -= Melt;
    }
}
