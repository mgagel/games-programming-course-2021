using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;

    private Transform target;
    private Vector2 moveDirection;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool knockFromUp;
    public bool knockFromDown;
    public bool knockFromLeft;
    public bool knocked = false;
    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Companion").GetComponent<Transform>();
    }

    private void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        var companion = GameObject.FindGameObjectWithTag("Companion").GetComponent<Transform>();

        var distancetoplayer = Vector3.Distance(transform.position, player.position);
        var distancetocompanion = Vector3.Distance(transform.position, companion.position);

        if (distancetoplayer < distancetocompanion)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        } else
        {
            target = GameObject.FindGameObjectWithTag("Companion").GetComponent<Transform>();
        }

        if (target.position.x >= transform.position.x)
        {
            animator.SetBool("isWalkingRight", true);
        } else
        {
            animator.SetBool("isWalkingRight", false);
        }
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (knockbackCount <= 0 && knocked == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
            knockFromDown = false;
            knockFromUp = false;
            knockFromLeft = false;
            knockFromRight = false;
        } else if (knockbackCount <= 0 && knocked == true)
            //knockback just stopped
        {

            rb.velocity = Vector2.zero;
            knockFromDown = false;
            knockFromUp = false;
            knockFromLeft = false;
            knockFromRight = false;
            knocked = false;
        }
        else
        //enemy gets knocked back
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockback, 0f);
            }
            if (knockFromLeft)
            {
                rb.velocity = new Vector2(knockback, 0f);
            }
            if (knockFromUp)
            {
                rb.velocity = new Vector2(0f, -knockback);
            }
            if (knockFromDown)
            {
                rb.velocity = new Vector2(0f, knockback);
            }
            knockbackCount -= Time.deltaTime;

            
        }
    }
}
