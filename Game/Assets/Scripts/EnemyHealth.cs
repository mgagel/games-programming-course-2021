using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool gotHit;

    // Update is called once per frame
    void Update()
    {
        if (gotHit == true)
        {
            takeDamage();
        }
    }

    void takeDamage()
    {
        health--;

        if (health < 1)
        {
            Destroy(gameObject);
        }

        gotHit = false;
    }
}
