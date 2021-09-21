using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDroneMovement : MonoBehaviour
{
    public int currentposition;
    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;

    //Sprites could be different depending on the positions so they can be adjusted for each Enemy of this type
    public SpriteRenderer spriteRenderer;
    public Sprite spritePos1toPos2;
    public Sprite spritePos2toPos3;
    public Sprite spritePos3toPos4;
    public Sprite spritePos4toPos1;

    //Once the Enemy starts following the player it will always look in the direction of the player, therefor the sprites have to be saved again
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    public float movespeed;
    public float spottingDistance;

    public bool spottedPlayer = false;
    public bool inShootingDistance = false;

    private Vector2 destinationcoordinats;
    public Transform target;
    private Transform playerTransform;
    private Transform companionTransform;

    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        companionTransform = GameObject.FindGameObjectWithTag("Companion").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (spottedPlayer == false)
        {
            FixMove();
        }
        else
        {
            FollowPlayer();
        }
    	SpotPlayer();
    }

    void Update()
    {
        if (spottedPlayer == false)
        {
            if (transform.position == position1.transform.position)
            {
                currentposition = 1;
                spriteRenderer.sprite = spritePos1toPos2;
            }
            if (transform.position == position2.transform.position)
            {
                currentposition = 2;
                spriteRenderer.sprite = spritePos2toPos3;
            }
            if (transform.position == position3.transform.position)
            {
                currentposition = 3;
                spriteRenderer.sprite = spritePos3toPos4;
            }
            if (transform.position == position4.transform.position)
            {
                currentposition = 4;
                spriteRenderer.sprite = spritePos4toPos1;
            }
        }
    }

    void SpotPlayer()
    {
        float distanceToPlayer = Vector2.Distance(gameObject.transform.position, playerTransform.position);
        float distanceToCompanion = Vector2.Distance(gameObject.transform.position, companionTransform.position);
        
        if (distanceToPlayer <= spottingDistance || distanceToCompanion <= spottingDistance)
        {
            spottedPlayer = true;
        }
    }

    void FixMove()
    {
        if (currentposition == 1)
        {
            destinationcoordinats = position2.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, destinationcoordinats, movespeed * Time.deltaTime);
        }
        else if (currentposition == 2)
        {
            destinationcoordinats = position3.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, destinationcoordinats, movespeed * Time.deltaTime);
        }
        else if (currentposition == 3)
        {
            destinationcoordinats = position4.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, destinationcoordinats, movespeed * Time.deltaTime);
        }
        else if (currentposition == 4)
        {
            destinationcoordinats = position1.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, destinationcoordinats, movespeed * Time.deltaTime);
        }
    }

    void FollowPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        float distanceToTarget = Vector2.Distance(gameObject.transform.position, target.position);

        if (distanceToTarget >= 12.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
            inShootingDistance = false;
        } else
        {
            inShootingDistance = true;
        }

        //change sprite depending on walkdirection:
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        float verticaldifference = Mathf.Abs(player.transform.position.y - transform.position.y);
        float horizontaldifference = Mathf.Abs(player.transform.position.x - transform.position.x);

        //enemy is left from player
        if (player.transform.position.x > transform.position.x && horizontaldifference > verticaldifference)
        {
            spriteRenderer.sprite = spriteRight;
        }
        //enemy is right of player
        else if (player.transform.position.x < transform.position.x && horizontaldifference > verticaldifference)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        //enemy is above of player
        else if (player.transform.position.y < transform.position.y)
        {
            spriteRenderer.sprite = spriteDown;
        }
        //enemy is below of player
        else if (player.transform.position.y > transform.position.y)
        {
            spriteRenderer.sprite = spriteUp;
        }
    }
}
