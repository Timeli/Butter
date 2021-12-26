using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground 
{
    private Material _material;
    private int _damage;

    public Ground(Material material, int damage)
    {
        _material = material;
        _damage = damage;
    }

    public Material Material => _material;
    public int Damage => _damage;
}

public class GroundList : IEnumerable
{
    private List<Ground> grounds = new List<Ground>();

    public int Count => grounds.Count;  

    public void AddGround(Ground ground)
    {
        grounds.Add(ground);
    }

    public int GetGroundDamage(Material material)
    {
        foreach (var ground in grounds)
            if (material.color == ground.Material.color)
                return ground.Damage;
        return 0;
    }

    public IEnumerator GetEnumerator()
    {
        return grounds.GetEnumerator();
    }
}