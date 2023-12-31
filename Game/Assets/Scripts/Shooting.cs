using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public AudioSource shootsound;
    public Animator animator;
    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !playerMovement.isWalking)
        {
            shootsound.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        animator.SetTrigger("shoot");
        shootsound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
