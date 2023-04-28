using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;

    float timeSinceLastShot;

    public LayerMask whatIsEnemy;
    public CamShake cameraShaker;
    public TextMeshProUGUI bulletsText;

    private void Awake()
    {
        gunData.currentAmmo = gunData.magSize;
    }

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
        bulletsText.SetText("Ammo: " + gunData.magSize + " / " + gunData.currentAmmo);
    }

    private void OnDisable() => gunData.isRealoading = false;

    private bool CanShoot() => !gunData.isRealoading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if(gunData.currentAmmo > 0) { 
            if(CanShoot())
            {
                float spreadX = UnityEngine.Random.Range(-gunData.bulletSpread, gunData.bulletSpread);
                float spreadY = UnityEngine.Random.Range(-gunData.bulletSpread, gunData.bulletSpread);

                Vector3 direction = cam.forward + new Vector3(spreadX, spreadY, 0);

                Debug.Log(gunData.currentAmmo);

                StartCoroutine(cameraShaker.Shake(gunData.camShakeDuration, gunData.camShakeMagnitude));

                FindObjectOfType<AudioManager>().Play("PistolSound");

                if (Physics.Raycast(cam.position, direction, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    
                    damageable?.Damage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    public void StartReload()
    {
        if(!gunData.isRealoading && this.gameObject.activeSelf)
        {
            StartCoroutine(Reload());
        }
    }

    private void OnGunShot()
    {
        
    }

    private IEnumerator Reload()
    {
        gunData.isRealoading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.isRealoading = false;
    }
}
