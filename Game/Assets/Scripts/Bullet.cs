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
            var enemyHealth = collision.collider.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.gotHit = true;
            }

            var isBoss1 = collision.collider.GetComponent<BossMovement_1>();
            if (!isBoss1)
            {
                //enemy gets knockbacked:
                var enemyMM = collision.collider.GetComponent<EnemyMovement>();
                if (enemyMM)
                {
                    float verticaldifference = Mathf.Abs(enemyMM.transform.position.y - transform.position.y);
                    float horizontaldifference = Mathf.Abs(enemyMM.transform.position.x - transform.position.x);

                    //bullet is left from enemy
                    if (enemyMM.transform.position.x > transform.position.x && horizontaldifference > verticaldifference)
                    {
                        enemyMM.knockFromLeft = true;
                    }
                    //bullet is right of enemy
                    else if (enemyMM.transform.position.x < transform.position.x && horizontaldifference > verticaldifference)
                    {
                        enemyMM.knockFromRight = true;
                    }
                    //bullet is above of enemy
                    else if (enemyMM.transform.position.y < transform.position.y)
                    {
                        enemyMM.knockFromUp = true;
                    }
                    //bullet is below of enemy
                    else if (enemyMM.transform.position.y > transform.position.y)
                    {
                        enemyMM.knockFromDown = true;
                    }

                    enemyMM.knockbackCount = enemyMM.knockbackLength;
                    enemyMM.knocked = true;
                }
            }
        }
    }
}
