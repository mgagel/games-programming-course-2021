using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemyMovement : MonoBehaviour
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

    public GameObject fovcone;

    public bool spottedPlayer = false;

    public SpriteRenderer conesprite;

    private Vector2 destinationcoordinats;
    private Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spottedPlayer == false)
        {
            FixMove();
        }
        else
        {
            movespeed = 4;
            Destroy(conesprite);
            FollowPlayer();
        }

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
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        //player gets hit
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<PlayerMovement>();

            float verticaldifference = Mathf.Abs(player.transform.position.y - transform.position.y);
            float horizontaldifference = Mathf.Abs(player.transform.position.x - transform.position.x);

            //enemy is left from player
            if (player.transform.position.x > transform.position.x && horizontaldifference > verticaldifference)
            {
                player.knockFromLeft = true;
            }
            //enemy is right of player
            else if (player.transform.position.x < transform.position.x && horizontaldifference > verticaldifference)
            {
                player.knockFromRight = true;
            }
            //enemy is above of player
            else if (player.transform.position.y < transform.position.y)
            {
                player.knockFromUp = true;
            }
            //enemy is below of player
            else if (player.transform.position.y > transform.position.y)
            {
                player.knockFromDown = true;
            }

            player.knockbackCount = player.knockbackLength;
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Companion")
        {
            //character loses health
            var health = collision.gameObject.GetComponent<Health>();
            health.gotHit = true;

            //enemy gets destroyed by exploding
            Destroy(gameObject);
        } else
        {
            //enemy gets destroyed by exploding
            Destroy(gameObject);
        }


    }
}
