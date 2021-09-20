using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;
    public bool gotHit;
    public bool gotBigHit;

    private void Start()
    {
        int diff = PlayerPrefs.GetInt("difficulty");

        if (diff == 0)
        {
            health = 1;
        } else if (diff == 1)
        {
            health = 3;
        } else if (diff == 2)
        {
            health = 5;
        }
    }

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
