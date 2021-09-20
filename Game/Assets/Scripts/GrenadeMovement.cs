using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMovement : MonoBehaviour
{
    public float throwForce;
    public float explosionTimer;
    private float timeUntilExplosion;
    public float rotationsPerSecond;
    public float explosionRadius;
    public bool fliesHorizontal;
    public int direction; //Vorzeichen (+1=oben oder rechts/-1=unten oder links)
    private Rigidbody2D rb;
    private Animator animator;
    private bool explodeNow = false;
    private bool destroyGameObject = false;
    private bool explosionInitiated = false;
    private float animationTimer = 0.5f;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 forceVektor;
        if (fliesHorizontal)
        {
            forceVektor = new Vector2(direction*throwForce, 0);
        } else
        {
            forceVektor = new Vector2(0, direction*throwForce);
        }
        rb.AddForce(forceVektor);

        timeUntilExplosion = explosionTimer;
    }

    void Update()
    {
        timeUntilExplosion -= Time.deltaTime;
        rotateGrenade(rotationsPerSecond);
        explode();
    }

    void rotateGrenade(float rotationsPerSecond)
    {
        float oldZRotation = this.gameObject.transform.eulerAngles.z;

        float addZRotation = 360 * (Mathf.Lerp(0f, rotationsPerSecond, (timeUntilExplosion/explosionTimer) )) * Time.deltaTime;

        gameObject.transform.Rotate(new Vector3(0,0, addZRotation), Space.Self);
    }

    void explode()
    {
        if (destroyGameObject)
        {
            animationTimer -= Time.deltaTime;
        }

        if (animationTimer<=0)
        {
            Destroy(gameObject);
        }
        
        if ( (timeUntilExplosion<=0 || explodeNow) && !explosionInitiated )
        {
            animator.Play("grenade-explosion");

            Vector2 explosionPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            var hitColliders = Physics2D.OverlapCircleAll(new Vector2(explosionPosition.x, explosionPosition.y), explosionRadius);

            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<EnemyHealth>();
                var friend = hitCollider.GetComponent<Health>();
                if (enemy)
                {
                    enemy.gotBigHit = true;
                }
                if (friend)
                {
                    friend.gotHit = true;
                }
            }

            explosionInitiated = true;
            destroyGameObject = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        explodeNow = true;
    }
}