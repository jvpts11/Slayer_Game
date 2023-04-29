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
    [SerializeField] private Transform muzzle;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Rigidbody playerRB;
    [SerializeField] public Camera targetCamera;

    float timeSinceLastShot;

    public LayerMask whatIsEnemy;
    public CamShake cameraShaker;
    public TextMeshProUGUI bulletsText;

    private GameObject currentBullet;

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
                if (!gameObject.activeSelf) return;
                Vector3 bulletDirectionWithoutSpread = BulletDirection();

                float spreadX = UnityEngine.Random.Range(-gunData.bulletSpread, gunData.bulletSpread);
                float spreadY = UnityEngine.Random.Range(-gunData.bulletSpread, gunData.bulletSpread);

                Vector3 bulletDirectionWithSpread = bulletDirectionWithoutSpread + new Vector3(spreadY, spreadX, 0);

                Vector3 direction = cam.forward + new Vector3(spreadX, spreadY, 0);

                Debug.Log(gunData.currentAmmo);
                AudioManager.Instance.PlaySFX(gunData.soundName);
                Bullet(bulletDirectionWithSpread);

                if (Physics.Raycast(cam.position, direction, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    
                    damageable?.Damage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                ApplyRecoil(bulletDirectionWithSpread);
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
        if (gameObject.activeSelf) StartCoroutine(cameraShaker.Shake(gunData.camShakeDuration, gunData.camShakeMagnitude));
    }

    private IEnumerator Reload()
    {
        gunData.isRealoading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.isRealoading = false;
    }

    private void Bullet(Vector3 directionWithSpread)
    {
        Vector3 muzzlePosition = muzzle.position;

        GameObject currentBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * gunData.shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * gunData.upwardForce, ForceMode.Impulse);

        StartCoroutine(DestroyBullet(currentBullet, muzzlePosition));

    }

    private IEnumerator DestroyBullet(GameObject bullet, Vector3 startPosition)
    {
        while (Vector3.Distance(startPosition, bullet.transform.position) < gunData.maxDistance)
        {
            yield return null;
        }

        Destroy(bullet);
    }

    private void ApplyRecoil(Vector3 directionWithSpread)
    {
        playerRB.AddForce(-directionWithSpread.normalized * gunData.recoilForce, ForceMode.Impulse);
    }

    private Vector3 BulletDirection()
    {
        Ray ray = targetCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        Vector3 directionWithoutSpread = targetPoint - muzzle.position;
        return directionWithoutSpread;
    }
}
