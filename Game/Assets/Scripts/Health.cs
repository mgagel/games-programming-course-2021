using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool playerIsDead = false;
    public int maxhealth;
    public int health;
    public bool gotHit = false;

    public TMP_Text healthtext;
    public TMP_Text deathtext;

    void Start()
    {
        healthtext.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit == true)
        {
            takeDamage();
        }

        if (health < 1)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        gameObject.SetActive(false);
        Debug.Log("Dead");
        deathtext.enabled = true;
        playerMovement.freezePlayer = true;
        playerIsDead = true;
    }

    void takeDamage()
    {
        health--;
        healthtext.text = health.ToString();

        gotHit = false;
    }

    void fullheal()
    {
        health = maxhealth;
        healthtext.text = health.ToString();
    }

    void heal()
    {
        if (health < maxhealth)
        {
            health++;
            healthtext.text = health.ToString();
        }
    }
}