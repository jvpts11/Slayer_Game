using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTarget : AbstractEnemy, IDamageable
{
    private void Start()
    {
        health = 100;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
