using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GunData gunData;
    
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        damageable?.Damage(gunData.damage);
    }
}
