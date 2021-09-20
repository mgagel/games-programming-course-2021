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
    public float baseShootCooldownTime;
    private float shootCooldownTime;
    private float shootTimer;
    public int maxHealth;

    private float laserDistance = 20;
    public LineRenderer laserLineRenderer;


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
        UpdateShootCooldownTime();
        Shooting();
    }

    void Shooting()
    {
        switch (bossMovement.attackPattern)
        {
            case 0:
                laserLineRenderer.enabled = false;
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
                laserLineRenderer.enabled = false;
                if (shootTimer>0)
                {
                    shootTimer -= Time.deltaTime;
                } else
                {
                    shootTimer = shootCooldownTime*0.25f;
                    ShootBullet();
                }
                break;

            case 2:
                if (bossMovement.laserMovement)
                {
                    laserLineRenderer.enabled = true;
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

    void UpdateShootCooldownTime()
    {
        shootCooldownTime = Mathf.Lerp(baseShootCooldownTime*0.2f, baseShootCooldownTime, ((float) bossHealth.health)/((float) maxHealth));
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(firePoint.position, -transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, -transform.up);
            Draw2DRay(firePoint.position, hit.point);
            var player = hit.collider.GetComponent<Health>();
            if (player)
            {
                player.gotHit = true;
            }
        } else
        {
            Draw2DRay(firePoint.position, firePoint.transform.up * laserDistance);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        laserLineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        laserLineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, -1));
    }
}
