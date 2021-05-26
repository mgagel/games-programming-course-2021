using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    public Sprite playerfront;
    public Sprite playerleft;
    public Sprite playerright;
    public Sprite playerback;


    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
        Debug.Log("moveX: " + moveDirection.x);
        Debug.Log("moveY: " + moveDirection.y);

        //when moving right
        if (moveDirection.x > 0)
        {
            spriteRenderer.sprite = playerright;
        }
        //when moving left
        else if (moveDirection.x < 0)
        {
            spriteRenderer.sprite = playerleft;
        }
        //when moving up
        else if (moveDirection.y > 0)
        {
            spriteRenderer.sprite = playerback;
        }
        //when moving down
        else if (moveDirection.y < 0)
        {
            spriteRenderer.sprite = playerfront;
        }
    }
}
