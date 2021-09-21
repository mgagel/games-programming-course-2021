using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public int normalModeHealth;
    public int health;
    public bool gotHit;
    public bool gotBigHit;

    private void Start()
    {
        var isBoss1 = gameObject.GetComponent<BossMovement_1>();
        int diff = PlayerPrefs.GetInt("difficulty");

        if (isBoss1)
        {
            if (diff == 0)
            {
                health = Mathf.RoundToInt((float) (normalModeHealth*0.5));
            } else if (diff == 1)
            {
                health = normalModeHealth;
            } else if (diff == 2)
            {
                health = Mathf.RoundToInt((float) (normalModeHealth*1.5));;
            }
        } else
        {
            if (diff == 0)
            {
                health = Mathf.RoundToInt((float) (normalModeHealth*(1/3)));
            } else if (diff == 1)
            {
                health = normalModeHealth;
            } else if (diff == 2)
            {
                health = Mathf.RoundToInt((float) (normalModeHealth*(5/3)));
            }
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
        var isBoss1 = gameObject.GetComponent<BossMovement_1>();

        if (health < 1)
        {
            Destroy(gameObject);

            if (isBoss1)
            {
                SceneManager.LoadScene("EndScene");

            }
        }

        gotHit = false;
        gotBigHit = false;
    }
}
