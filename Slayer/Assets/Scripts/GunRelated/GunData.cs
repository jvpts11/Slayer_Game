using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun",menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    public string soundName;

    [Header("Shooting")]
    public float damage;
    public float maxDistance;
    public float bulletSpread;

    [Header("Bullet")]
    public float shootForce;
    public float upwardForce;
    public float recoilForce;

    [Header("Camera Shake")]
    public float camShakeDuration;
    public float camShakeMagnitude;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;

    [HideInInspector]
    public bool isRealoading;
    public bool allowButtonShot;
}
