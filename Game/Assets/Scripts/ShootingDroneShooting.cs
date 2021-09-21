using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDroneShooting : MonoBehaviour
{
    private Transform target;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public AudioSource shootsound;
    public float shootCooldownTime;
    private float shootTimer;
    private ShootingDroneMovement droneMovement;
    
    void Start()
    {
        droneMovement = gameObject.GetComponent<ShootingDroneMovement>();
        shootTimer = shootCooldownTime;
    }

    void Update()
    {
        if (droneMovement.inShootingDistance)
        {
            target = droneMovement.target;
            Shooting();
        }
    }

    void Shooting()
    {
        if (shootTimer>0)
        {
            shootTimer -= Time.deltaTime;
        } else
        {
            shootTimer = shootCooldownTime;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Vector3 targetDirection = (target.position - gameObject.transform.position);
        shootsound.Play();
        GameObject enemyBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(Vector3.forward, targetDirection));
        Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(targetDirection * bulletForce, ForceMode2D.Impulse);
    }


}