using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action ZeroHealthNotify;
    public event Action<int, Renderer> HealthAndGroundNotify;

    [SerializeField] private ButterControl _butterControl;
    [SerializeField] [Range(1, 35)] private int _health;

    private string _cube = "Cube";

    public int HealthCount => _health;


    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1))
        {
            if (hitInfo.collider.name.Equals(_cube))
            {
                DecreaseHealth(HealthByStep.GreenGround);

                Renderer ground = hitInfo.collider.GetComponent<Renderer>();
                HealthAndGroundNotify.Invoke(HealthCount, ground);
            }
        }
    }

    private void DecreaseHealth(HealthByStep healthByStep)
    {
        _health -= (int)healthByStep;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        ZeroHealthNotify?.Invoke();
    }


    public void AddHealth(int count)
    {

    }


    private void OnEnable()
    {
        _butterControl.StepNotify += CheckGround;
    }

    private void OnDisable()
    {
        _butterControl.StepNotify -= CheckGround;
    }
}

public enum HealthByStep
{
    GreenGround = 1,
    OrangeGround = 2
}
