using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        //if the shot object is an enemy and has the script Enemyhealth it will take damage
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().gotHit = true;

            //enemy gets knockbacked:
            var enemy = collision.gameObject.GetComponent<EnemyMovement>();

            float verticaldifference = Mathf.Abs(enemy.transform.position.y - transform.position.y);
            float horizontaldifference = Mathf.Abs(enemy.transform.position.x - transform.position.x);

            //bullet is left from enemy
            if (enemy.transform.position.x > transform.position.x && horizontaldifference > verticaldifference)
            {
                enemy.knockFromLeft = true;
            }
            //bullet is right of enemy
            else if (enemy.transform.position.x < transform.position.x && horizontaldifference > verticaldifference)
            {
                enemy.knockFromRight = true;
            }
            //bullet is above of enemy
            else if (enemy.transform.position.y < transform.position.y)
            {
                enemy.knockFromUp = true;
            }
            //bullet is below of enemy
            else if (enemy.transform.position.y > transform.position.y)
            {
                enemy.knockFromDown = true;
            }

            enemy.knockbackCount = enemy.knockbackLength;
            enemy.knocked = true;
        }
    }
}
