using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        }

    }



}
