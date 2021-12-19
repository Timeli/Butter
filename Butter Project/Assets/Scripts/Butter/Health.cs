using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void zeroHealthHandler();
public delegate void healtByStepHandler(int healtByStep, Renderer ground);
public class Health : MonoBehaviour
{
    public event zeroHealthHandler ZeroHealthNotify;
    public event healtByStepHandler HealtByStepNotify;

    [SerializeField] private ButterControl _butterControl;
    [SerializeField] [Range(1, 35)] private int _health;

    private string _cube = "Cube";

    public int HealtCount => _health;


    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1))
        {
            if (hitInfo.collider.name.Equals(_cube))
            {
                DecreaseHealth(HealthByStep.GreenGround);

                Renderer ground = hitInfo.collider.GetComponent<Renderer>();
                HealtByStepNotify?.Invoke(_health, ground); ;
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
        _butterControl.Notify += CheckGround;
    }

    private void OnDisable()
    {
        _butterControl.Notify -= CheckGround;
    }
}

public enum HealthByStep
{
    GreenGround = 1,
    OrangeGround = 2
}
