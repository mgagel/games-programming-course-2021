using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer characterSprite;
    public bool playerIsDead = false;
    public int maxhealth;
    public int health;
    public bool gotHit = false;
    public bool isOnHitInvulnerable = false;
    public Color flashColor;
    public Color regularColor;
    public float invulnerabilityDuration;
    private float remainingInvulnerabilityDuration;
    public float flashDuration;
    private float remainingFlashDuration;
    private bool isFlashing;
    public AudioSource deathsound;



    public TMP_Text healthtext;
    public TMP_Text deathtext;

    void Start()
    {
        healthtext.text = health.ToString();
        remainingInvulnerabilityDuration = invulnerabilityDuration;
        remainingFlashDuration = flashDuration;
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

        onHitInvulnerabilityFlashes();
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
        if (!isOnHitInvulnerable)
        {
            health--;
            healthtext.text = health.ToString();
            isOnHitInvulnerable = true;
            isFlashing = true;
            remainingInvulnerabilityDuration = invulnerabilityDuration;
            if (health < 1 && !deathsound.isPlaying)
            {
                deathsound.Play();
            }
        }

        gotHit = false;
    }

    void onHitInvulnerabilityFlashes()
    {
        if (isOnHitInvulnerable)
        {
            remainingInvulnerabilityDuration -= Time.deltaTime;

            if(remainingInvulnerabilityDuration > 0)
            {
                remainingFlashDuration -= Time.deltaTime;
                if (!isFlashing)
                {
                    characterSprite.color = regularColor;
                    if(remainingFlashDuration <= 0f)
                    {
                        isFlashing = true;
                        characterSprite.color = flashColor;
                        remainingFlashDuration = flashDuration;
                    }
                }
                else
                {
                    characterSprite.color = flashColor;
                    if(remainingFlashDuration <= 0f)
                    {
                        isFlashing = false;
                        characterSprite.color = regularColor;
                        remainingFlashDuration = flashDuration;
                    }
                }
            }
            else
            {
                isOnHitInvulnerable = false;
                isFlashing = false;
                characterSprite.color = regularColor;
                remainingFlashDuration = flashDuration;
            }
        }
    }

    public void fullheal()
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
