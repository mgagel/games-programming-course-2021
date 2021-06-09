using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;

    private Transform target;
    private Vector2 moveDirection;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
    }
}
