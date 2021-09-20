using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting_1 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public AudioSource shootsound;
    private BossMovement_1 bossMovement;
    private EnemyHealth bossHealth;
    private float baseShootCooldownTime = 2.0f;
    private float shootCooldownTime;
    private float shootTimer;
    public int maxHealth;


    void Start()
    {
        bossMovement = gameObject.GetComponent<BossMovement_1>();
        bossHealth = gameObject.GetComponent<EnemyHealth>();
        shootCooldownTime = baseShootCooldownTime;
        shootTimer = baseShootCooldownTime;
        maxHealth = bossHealth.health;
    }

    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        switch (bossMovement.attackPattern)
        {
            case 0:
                if (shootTimer>0)
                {
                    shootTimer -= Time.deltaTime;
                } else
                {
                    shootTimer = shootCooldownTime;
                    ShootBullet();
                }
                break;

            case 1:
                if (shootTimer>0)
                {
                    shootTimer -= Time.deltaTime;
                } else
                {
                    shootTimer = Mathf.Lerp(0.1f, baseShootCooldownTime, ((float) bossHealth.health)/((float) maxHealth));
                    ShootBullet();
                }
                break;

            case 2:
                if (bossMovement.laserMovement)
                {
                    ShootLaser();
                }
                break;
        }
    }

    void ShootBullet()
    {
        shootsound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootLaser()
    {

    }
}
