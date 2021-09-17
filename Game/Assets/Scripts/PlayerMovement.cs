using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool freezePlayer = false;
    public float movespeed;
    public Rigidbody2D rb;
    public Transform firePoint;
    public Transform companionTransform;

    public SpriteRenderer spriteRenderer;
    public Sprite playerfront;
    public Sprite playerleft;
    public Sprite playerright;
    public Sprite playerback;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool knockFromUp;
    public bool knockFromDown;
    public bool knockFromLeft;
    public bool isCarryingCompanion;
    public float pickupRange;


    private Vector2 moveDirection;

   

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        if (!freezePlayer)
        {
            Move();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetButtonDown("Jump"))
        {
            PickupOrLeaveCompanion();
        }
    }

    void PickupOrLeaveCompanion()
    {
        Vector3 distanceToPlayer = this.transform.position - companionTransform.position;
        if (isCarryingCompanion)
        {
            movespeed = 7f;
            isCarryingCompanion = false;
        }
        else
        {
            if (distanceToPlayer.magnitude <= pickupRange)
            {
                movespeed = 4f;
                isCarryingCompanion = true;
            }
        }
    }

    void Move()
    {
        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
            knockFromDown = false;
            knockFromUp = false;
            knockFromLeft = false;
            knockFromRight = false;
        } else
        //if player gets hit by enemy he gets pushed back:
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

        //when moving right
        if (moveDirection.x > 0)
        {
            spriteRenderer.sprite = playerright;

            //reposition firepoint
            Vector3 firePointOffset = new Vector3(0.8f, 0f, 0f);
            firePoint.position = this.transform.position + firePointOffset;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
            firePoint.rotation = Quaternion.Euler(rotationVector);
        }
        //when moving left
        else if (moveDirection.x < 0)
        {
            spriteRenderer.sprite = playerleft;

            //reposition firepoint
            Vector3 firePointOffset = new Vector3(-0.8f, 0f, 0f);
            firePoint.position = this.transform.position + firePointOffset;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 90;
            firePoint.rotation = Quaternion.Euler(rotationVector);
        }
        //when moving up
        else if (moveDirection.y > 0)
        {
            spriteRenderer.sprite = playerback;

            //reposition firepoint
            Vector3 firePointOffset = new Vector3(0f, 0.8f, 0f);
            firePoint.position = this.transform.position + firePointOffset;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            firePoint.rotation = Quaternion.Euler(rotationVector);
        }
        //when moving down
        else if (moveDirection.y < 0)
        {
            spriteRenderer.sprite = playerfront;

            //reposition firepoint
            Vector3 firePointOffset = new Vector3(0f, -1f, 0f);
            firePoint.position = this.transform.position + firePointOffset;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 180;
            firePoint.rotation = Quaternion.Euler(rotationVector);
        }
    }

}
