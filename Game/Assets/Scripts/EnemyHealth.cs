using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool gotHit;
    public bool gotBigHit;

    // Update is called once per frame
    void Update()
    {
        if (gotHit == true)
        {
            takeDamage(1);
        }
        if (gotBigHit == true)
        {
            takeDamage(3);
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            Destroy(gameObject);
        }

        gotHit = false;
        gotBigHit = false;
    }
}
